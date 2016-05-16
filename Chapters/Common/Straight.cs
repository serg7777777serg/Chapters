using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    class Straight
    {
        private Straight(int x1 = 0, int x2 = 0, int y1 = 0, int y2 = 0)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        private int X1 { get; set; }
        private int X2 { get; set; }
        private int Y1 { get; set; }
        private int Y2 { get; set; }
        private double A { get { return (double)(Y2 - Y1) / (X2 - X1); } }
        private double B { get { return Y2 - A * X2; } }

        public static bool operator |(Straight Y, Straight Z) { return Y.A == Z.A; }
        public static double operator %(Straight Y, Straight Z) { return Math.Atan2((Z.A-Y.A), (1+ Y.A*Z.A)); }
        public static bool operator !=(Straight Y, Straight Z) { return Y.A * Z.A == -1; }
        public static bool operator ==(Straight Y, Straight Z) { return Y.A == Z.A && Y.B == Z.B; }

        public double[] CrossPoints { get { return new double[2] {  (B-2*B) / A, B}; } }
        public override string ToString()
        {
            return string.Format("{0}x {1} {2}", A, B>0 ? "+":"", B);
        }

        public static Straight Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new Straight(int.Parse((param as string[])[0]), int.Parse((param as string[])[1]), int.Parse((param as string[])[2]), int.Parse((param as string[])[3]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
