using System;
using System.Threading;

public class PhysicsSimulation
{
    static float DISTANCE_CONVERSION = 1;

    private int THREADS;

    public PhysicsSimulation(int threads)
	{
        this.THREADS = threads;
	}

    public void UpdateGravity(System.Collections.ArrayList all)
    {
        Thread[] threads = new Thread[THREADS];
        System.Collections.ArrayList group = new System.Collections.ArrayList();
        int groupSize = (int)Math.Ceiling((double)all.Count / THREADS);
        int i = 0;  //Count of something
        int c = 0;  //Count of threads
        int x = 0;  //Count of object in thread group
        foreach (Spheroid a in all) 
        {
            if(x < groupSize)
            {
                group.Add(a);
                x++;
            }
            else
            {
                GravityThread gravity = new GravityThread(all, group, DISTANCE_CONVERSION);
                threads[c] = new Thread(new ThreadStart(gravity.ThreadProc));
                threads[c].Start();
                c++;
                group = new System.Collections.ArrayList();
                x = 0;
            }
        }

        GravityThread lastGravity = new GravityThread(all, group, DISTANCE_CONVERSION);
        threads[c] = new Thread(new ThreadStart(lastGravity.ThreadProc));
        threads[c].Start();

        if (x < group.Count)
        {
            GravityThread gravity = new GravityThread(all, group, DISTANCE_CONVERSION);
            threads[c] = new Thread(new ThreadStart(gravity.ThreadProc));
            threads[c].Start();
        }
        try
        {
            for(int count = 0; count < THREADS-1; count++)
            {
                threads[count].Join();
            }
        }
        catch
        {
            
        }
    }

    public void UpdateMovement(System.Collections.ArrayList all, float timeDivisor)
    {
        for(int i = 0; i < all.Count; i++)
        {
            (all[i] as Spheroid).transform.position += (all[i] as Spheroid).physicalProperties.inertia * timeDivisor;
        }
    }
}
