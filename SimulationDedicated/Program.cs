using System;
using m_Math;
using System.Threading;

namespace SimulationDedicated
{
    class Program
    {
        static void Main(string[] args)
        {
            int THREADS = 2;
            int OBJECTS = 2;
            if (args.Length != 0)
            {
                for(int i = 0; i < args.Length; i++)
                {
                    if(args[i] == "--threads")
                    {
                        i++;
                        if (int.Parse(args[i]) > THREADS)
                        {
                            THREADS = int.Parse(args[i]);
                        }
                    }

                    if(args[i] == "--objects")
                    {
                        i++;
                        OBJECTS = int.Parse(args[i]);
                    }
                }
            }

            Console.WriteLine("Using {0} threads", THREADS);
            Console.WriteLine("Creating {0} objects", OBJECTS);
            Thread.Sleep(1000);

            Random rand = new Random();
            System.Collections.ArrayList objs = new System.Collections.ArrayList();
            PhysicsSimulation m_Physics = new PhysicsSimulation(THREADS);
            for (int i = 0; i < OBJECTS; i++)
            {
                Spheroid m_Spheroid = new Spheroid(
                    new Vector3(rand.Next(-100, 100), rand.Next(-100, 100), rand.Next(-100, 100)),
                    new Vector3(1, 1, 1),
                    rand.Next(1, 9));
                objs.Add(m_Spheroid);
            }
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(">");

            ControlPlane control = new ControlPlane(objs, THREADS);
            control.Start();
        }
    }
}
