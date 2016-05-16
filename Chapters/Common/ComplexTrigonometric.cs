using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    class ComplexTrigonometric : Complex
    {
        private double Ro { get; set; }
        private double Fi { get; set; }

        public ComplexTrigonometric(double ro, double fi) : base(ro, fi)
        {
            Ro = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            Fi = Math.Atan2(Imaginary, Real);
        }

        public static ComplexTrigonometric operator /(ComplexTrigonometric z1, ComplexTrigonometric z2)
        {
            return new ComplexTrigonometric(z1.Ro / z2.Ro * Math.Cos(z1.Fi - z2.Fi), z1.Ro / z2.Ro * Math.Sin(z1.Fi - z2.Fi));
        }
        public static ComplexTrigonometric operator *(ComplexTrigonometric z1, ComplexTrigonometric z2)
        {
            return new ComplexTrigonometric(z1.Ro * z2.Ro * Math.Cos(z1.Fi + z2.Fi), z1.Ro * z2.Ro * Math.Sin(z1.Fi + z2.Fi));
        }
        public static ComplexTrigonometric operator +(ComplexTrigonometric z1, ComplexTrigonometric z2)
        {
            return new ComplexTrigonometric(z1.Ro * Math.Cos(z1.Fi) + z2.Ro * Math.Cos(z2.Fi), z1.Ro * Math.Sin(z1.Fi) + z2.Ro * Math.Sin(z2.Fi));
        }
        public static ComplexTrigonometric operator -(ComplexTrigonometric z1, ComplexTrigonometric z2)
        {
            return new ComplexTrigonometric(z1.Ro * Math.Cos(z1.Fi) - z2.Ro * Math.Cos(z2.Fi), z1.Ro * Math.Sin(z1.Fi) - z2.Ro * Math.Sin(z2.Fi));
        }

        public ComplexTrigonometric Pow(int n)
        {
            return new ComplexTrigonometric(Math.Pow(Ro, n) * Math.Cos(n * Fi), Math.Pow(Ro, n) * Math.Sin(n * Fi));
        }

        public override string ToString()
        {
            return string.Format("{0} (cos{1}+ i sin{1})", Ro, Fi);
        }

        public static ComplexTrigonometric Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new ComplexTrigonometric(double.Parse((param as string[])[0]), double.Parse((param as string[])[1]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
