using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    class Vector
    {
        private int X { get; set; }
        private int Y { get; set; }
        private int Z { get; set; }

        private Vector(int x=0, int y=0, int z=0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("Coordinates: ({0},{1},{2})\n", X,Y,Z);
        }

        public double Length
        {
            get { return Math.Sqrt(X*X + Y*Y + Z*Z); }
        }

        public string DirectionCosines()
        {
            return string.Format( "{0}, {1}, {2}", X / Length, Y / Length, Z / Length);
        }

        public static Vector operator +(Vector A, Vector B)
        {
            return new Vector(A.X+B.X,A.Y+B.Y,A.Z+B.Z);
        }

        public static int operator %(Vector A, Vector B)
        {
            return A.X*B.X + A.Y*B.Y + A.Z*B.Z;
        }
        public static bool operator ==(Vector A, Vector B)
        {
            return A.X==B.X && A.Y==B.Y && A.Z==B.Z;
        }
        public static bool operator !=(Vector A, Vector B)
        {
            return A.X != B.X || A.Y != B.Y || A.Z != B.Z;
        }
        public static Vector operator *(Vector A, Vector B)
        {
            return new Vector(A.Y*B.Z-A.Z*B.Y, A.Z*B.X-A.X*B.Z, A.X*B.Y-A.Y*B.X);
        }
        public static Vector operator *(int k, Vector B)
        {
            return new Vector(k*B.X, k*B.Y, k*B.Z);
        }
        public static Vector operator *(Vector B, int k)
        {
            return new Vector(k * B.X, k * B.Y, k * B.Z);
        }
        public static double operator /(Vector A, Vector B)
        { // transform from radian (180/pi) to angles
            return Math.Acos((A % B) / (A.Length * B.Length)) * (180 / Complex.Pi);
        }

        public static bool operator |(Vector A, Vector B)
        {
            if ((A.X == 0 && B.X == 0) || (A.Y == 0 && B.Y == 0) || (A.Z == 0 && B.Z == 0))
            {
                if (A.X != 0 && B.X != 0)
                {
                    var k = B.X/A.X;
                    return k*A == B;
                }
                if (A.Y != 0 && B.Y != 0)
                {
                    var k = B.Y / A.Y;
                    return k * A == B;
                }
                if (A.Z != 0 && B.Z != 0)
                {
                    var k = B.Z / A.Z;
                    return k * A == B;
                }
            }
            if (A.X/B.X == A.Y/B.Y && A.Y/B.Y == A.Z/B.Z)
                return true;
            if (A*B == new Vector())
                return true;

            return false;
        }

        public static Vector Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new Vector(int.Parse((param as string[])[0]), int.Parse((param as string[])[1]), int.Parse((param as string[])[2]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
