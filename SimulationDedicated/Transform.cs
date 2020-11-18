using System;
using m_Math;

public class Transform
{
    private Vector3 Position;
    private Vector3 Scale;

    public Vector3 position { get => Position; set => Position = value; }
    public Vector3 scale { get => Scale; set => Scale = value; }

    //Constructors
	public Transform()
	{
        Position = new Vector3(0, 0, 0);
        Scale = new Vector3(1, 1, 1);
	}

    public Transform(Vector3 position)
    {
        Position = position;
        Scale = new Vector3(1, 1, 1);
    }

    public Transform(Vector3 position, Vector3 scale)
    {
        Position = position;
        Scale = scale;
    }
}
