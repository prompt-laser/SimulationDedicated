using System;
using m_Math;

public class Spheroid : SimObject
{
    private PhysicalProperties PhysicalProperties;
    public PhysicalProperties physicalProperties { get => PhysicalProperties; }
    public float volume { get => (4/3) * (float)Math.PI * transform.scale.x * transform.scale.y * transform.scale.z; }

    public Spheroid(Transform transform)
    {
        this.transform = transform;
    }
    public Spheroid(Transform transform, PhysicalProperties properties)
    {
        this.transform = transform;
        PhysicalProperties = properties;
    }
    public Spheroid(Vector3 position, Vector3 scale)
    {
        transform.position = position;
        transform.scale = scale;
        PhysicalProperties = new PhysicalProperties((4 / 3) * (float)Math.PI * transform.scale.x * transform.scale.y * transform.scale.z);
    }

    public Spheroid(Vector3 position, Vector3 scale, PhysicalProperties properties)
    {
        transform.position = position;
        transform.scale = scale;
        PhysicalProperties = properties;
    }
    public Spheroid(Vector3 position, Vector3 scale, float density)
    {
        transform.position = position;
        transform.scale = scale;
        PhysicalProperties = new PhysicalProperties((4 / 3) * (float)Math.PI * transform.scale.x * transform.scale.y * transform.scale.z, density);
    }
}
