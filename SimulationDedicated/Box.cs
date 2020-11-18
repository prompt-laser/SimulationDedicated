using System;
using m_Math;

public class Box : SimObject
{
    private PhysicalProperties PhysicalProperties;

    public PhysicalProperties physicalProperties { get => PhysicalProperties; }

    public Box(Transform transform)
    {
        this.transform = transform;
        PhysicalProperties = new PhysicalProperties((transform.scale.x * 2) * (transform.scale.y * 2) * (transform.scale.z * 2));
    }

    public Box(Transform transform, PhysicalProperties properties)
    {
        this.transform = transform;
        PhysicalProperties = properties;
    }

    public Box(Vector3 position, Vector3 scale)
    {
        transform.position = position;
        transform.scale = scale;
        PhysicalProperties = new PhysicalProperties((transform.scale.x * 2) * (transform.scale.y * 2) * (transform.scale.z * 2));
    }

    public Box(Vector3 position, Vector3 scale, PhysicalProperties properties)
    {
        transform.position = position;
        transform.scale = scale;
        PhysicalProperties = properties;
    }

    public Box(Vector3 position, Vector3 scale, float density)
    {
        transform.position = position;
        transform.scale = scale;
        PhysicalProperties = new PhysicalProperties((transform.scale.x * 2) * (transform.scale.y * 2) * (transform.scale.z * 2),density);
    }
}
