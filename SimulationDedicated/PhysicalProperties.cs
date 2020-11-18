using System;
using m_Math;

public class PhysicalProperties
{
    private float Density;
    private float Volume;
    private Vector3 Inertia;

    public float density { get => Density; set => Density = value; }
    public float volume { get => Volume; }
    public float mass { get => volume * density; }
    public Vector3 inertia { get => Inertia; }

    public PhysicalProperties(float volume)
    {
        Volume = volume;
        Density = 1;
        Inertia = new Vector3(0, 0, 0);
    }

    public PhysicalProperties(float volume, float density)
    {
        Density = density;
        Volume = volume;
        Inertia = new Vector3(0, 0, 0);
    }

    public void AddForce(Vector3 force)
    {
        Inertia += force;
    }
}
