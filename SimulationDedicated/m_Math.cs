using System;

namespace m_Math
{

    public class Vector3
    {
        private float xPos;
        private float yPos;
        private float zPos;

        public float x { get => xPos; }
        public float y { get => yPos; }
        public float z { get => zPos; }

        public float magnitude { get => (float)Math.Sqrt(Math.Pow(xPos, 2) + Math.Pow(yPos, 2) + Math.Pow(zPos, 2)); }
        public Vector3 normalized { get => (new Vector3(x, y, z) / magnitude); }

        //Constructors
        public Vector3(float X, float Y, float Z)
        {
            xPos = X;
            yPos = Y;
            zPos = Z;
        }

        //Operators
        public static Vector3 operator +(Vector3 first, Vector3 second)
        {
            return new Vector3(first.x + second.x, first.y + second.y, first.z + second.z);
        }

        public static Vector3 operator -(Vector3 first, Vector3 second)
        {
            return new Vector3(first.x - second.x, first.y - second.y, first.z - second.z);
        }

        public static Vector3 operator *(Vector3 input, float multiplier)
        {
            return new Vector3(input.x * multiplier, input.y * multiplier, input.z * multiplier);
        }

        public static Vector3 operator *(float multiplier, Vector3 input)
        {
            return new Vector3(input.x * multiplier, input.y * multiplier, input.z * multiplier);
        }

        public static Vector3 operator /(Vector3 input, float divisor)
        {
            return new Vector3(input.x / divisor, input.y / divisor, input.z / divisor);
        }

        //Helpers
        public override String ToString()
        {
            return "( " + x + ", " + y + ", " + z + " )";
        }
    }
}