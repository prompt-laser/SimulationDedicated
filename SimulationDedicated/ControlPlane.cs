using System;
using m_Math;

public class ControlPlane
{
    DateTime lastUpdate;
    public DateTime LastUpdate { get => lastUpdate; set => lastUpdate = value; }

    DateTime lastOutput;

    string output;

    System.Collections.ArrayList controlledObjects;
    public System.Collections.ArrayList Objects { get => controlledObjects; }

    Spheroid selectedObject;

    Random rand;

    bool STRESSTEST = false;
    bool run;

    PhysicsSimulation physics;

    public ControlPlane(System.Collections.ArrayList objects, int workerThreads)
	{
        lastUpdate = DateTime.Now;
        lastOutput = DateTime.Now;
        output = "";
        rand = new Random();

        controlledObjects = objects;
        physics = new PhysicsSimulation(workerThreads);

        run = true;
    }


    public void Start()
    {
        while (run)
        {
            float seconds = (float)(DateTime.Now - lastUpdate).TotalSeconds;
            lastUpdate = DateTime.Now;
            physics.UpdateGravity(controlledObjects);
            physics.UpdateMovement(controlledObjects, seconds);
            WriteOuput();
            GetInput();
        }
    }

public void GetInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyPress = Console.ReadKey();
            if (!keyPress.Key.Equals(ConsoleKey.Backspace) && !keyPress.Key.Equals(ConsoleKey.Enter))
            {
                output += keyPress.KeyChar;
            }
            else if (output.Length != 0 && keyPress.Key == ConsoleKey.Backspace)
            {
                output = output.Remove(output.Length - 1);
                Console.SetCursorPosition(output.Length + 1, Console.CursorTop);
                Console.Write(" ");
            }
            else if (keyPress.Key.Equals(ConsoleKey.Enter))
            {
                Console.WriteLine(output + " ");

                if (output.Length > 0)
                {
                    String[] pieces = output.Split(" ");
                    if (pieces[0].ToLower() == "tps" || pieces[0].ToLower() == "ticks")
                    {
                        TPS();
                    }
                    else if (pieces[0].ToLower() == "object")
                    {
                        try
                        {
                            if (pieces[1].ToLower() == "count")
                            {
                                COUNTOBJECTS();
                            }
                            else if (pieces[1].ToLower() == "select")
                            {
                                try
                                {
                                    TRACK(pieces[2]);
                                }
                                catch
                                {
                                    ERROR("This command requires the integer value of the object you wish to select");
                                }
                            }
                            else if (pieces[1].ToLower() == "remove")
                            {
                                REMOVE();
                            }
                            else if (pieces[1].ToLower() == "add")
                            {
                                ADD();
                            }
                        }
                        catch
                        {
                            ERROR("INVALID COMMAND");
                        }
                    }else if(pieces[0].ToLower() == "stresstest")
                    {
                        STRESSTEST = true;
                    }
                    else if(pieces[0].ToLower() == "stop")
                    {
                        run = false;
                        Console.WriteLine("Stopping simulation");
                    }
                    else
                    {
                        ERROR("UNKNOWN COMMAND");
                    }
                }

                output = "";
                Console.Write(">");
            }
            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write(output + "");
        }
        if (STRESSTEST)
        {
            if (1 / (DateTime.Now - lastUpdate).TotalSeconds > 20 && (DateTime.Now - lastOutput).TotalSeconds > .5)
            {
                ADD();
            }
            else
            {
                STRESSTEST = false;
            }
        }
    }

    public void WriteOuput()
    {
        if((DateTime.Now - lastOutput).TotalSeconds > 1)
        {
            if (selectedObject != null)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine(selectedObject.transform.position + " moving at " + selectedObject.physicalProperties.inertia.magnitude);
                lastOutput = DateTime.Now;
                Console.Write(">" + output);
            }
        }
    }

    public void ERROR(string message)
    {
        Console.WriteLine(message);
    }

    public void COUNTOBJECTS()
    {
        Console.WriteLine(controlledObjects.Count);
    }

    public void TRACK(string value)
    {
        try
        {
            int selectedIndex = int.Parse(value);
            selectedObject = controlledObjects.ToArray()[selectedIndex - 1] as Spheroid;
        }
        catch
        {
            if (value.ToLower() == "none")
            {
                selectedObject = null;
            }
            else
            {
                ERROR("This command requires the integer value of the object you wish to select");
                return;
            }
        }
    }

    public void ADD()
    {
        Spheroid m_Spheroid = new Spheroid(
                    new Vector3(rand.Next(-100, 100), rand.Next(-100, 100), rand.Next(-100, 100)),
                    new Vector3(rand.Next(10, 20), rand.Next(10, 20), rand.Next(10, 20)),
                    rand.Next(1, 9));
        Console.WriteLine(m_Spheroid.transform.position + "=>" + m_Spheroid.physicalProperties.volume + ":" + m_Spheroid.physicalProperties.mass);
        controlledObjects.Add(m_Spheroid);
    }

    public void REMOVE()
    {
        controlledObjects.Remove(selectedObject);
        selectedObject = null;
    }

    public void TPS()
    {
        Console.WriteLine(1 / (DateTime.Now - lastUpdate).TotalSeconds);
    }
}
