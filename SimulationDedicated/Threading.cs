using System;
using m_Math;

public class GravityThread
{
    private System.Collections.ArrayList all;
    private System.Collections.ArrayList g;
    private float DISTANCE_CONVERSION;
    public float TIME_DIVISOR;

    public GravityThread(System.Collections.ArrayList collection, System.Collections.ArrayList group, float distanceConversion)
    {
        all = collection;
        g = group;
        DISTANCE_CONVERSION = distanceConversion;
    }

    public void ThreadProc()
    {
        Vector3 force = new Vector3(0, 0, 0);
        foreach (Spheroid a in g)
        {
            if (a != null)
            {
                try
                {
                    foreach (Spheroid again in all)
                    {
                        if (!a.Equals(again))
                        {
                            float distance = (a.transform.position - again.transform.position).magnitude * DISTANCE_CONVERSION;
                            force += (.000000000066743f * ((a.physicalProperties.mass * again.physicalProperties.mass) / (float)Math.Pow(distance, 2))) * ((again.transform.position - a.transform.position).normalized) / a.physicalProperties.mass;
                        }
                    }
                    if (!float.IsNaN(force.magnitude))
                    {
                        a.physicalProperties.AddForce(force);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
