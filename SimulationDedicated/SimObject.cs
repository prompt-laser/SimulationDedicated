using System;
using System.Collections.Generic;
using m_Math;

public class SimObject
{
    private Transform t;
    
    public Transform transform { get => t; set => t = value; }

    //Constructors
	public SimObject()
	{
        t = new Transform();
	}

    public SimObject(Transform inputTransform)
    {
        t = inputTransform;
    }

    public SimObject(Vector3 position, Vector3 scale)
    {
        t = new Transform(position, scale);
    }
}
