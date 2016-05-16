using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    class ComplexExponential : Complex
    {
        private double Ro { get; set; }
        private double Fi { get; set; }

        public ComplexExponential(double ro, double fi) : base(ro, fi)
        {
            Ro = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            Fi = Math.Atan2(Imaginary, Real);
        }

        public static ComplexExponential operator /(ComplexExponential z1, ComplexExponential z2)
        {
            return new ComplexExponential(z1.Ro / z2.Ro, z1.Fi - z2.Ro);
        }
        public static ComplexExponential operator *(ComplexExponential z1, ComplexExponential z2)
        {
            return new ComplexExponential(z1.Ro * z2.Ro, z1.Fi + z2.Fi);
        }
        public static ComplexExponential operator +(ComplexExponential z1, ComplexExponential z2)
        {
            return new ComplexExponential(z1.Ro + z2.Ro, z1.Fi + z2.Fi);
        }
        public static ComplexExponential operator -(ComplexExponential z1, ComplexExponential z2)
        {
            return new ComplexExponential(z1.Ro - z2.Ro, z1.Fi - z2.Fi);
        }
        public override string ToString()
        {
            return string.Format("{0} e^ {1})", Ro, Fi > 0 ? ("i" + Fi) : ("-i" + (Fi-2*Fi)));
        }

        public static ComplexExponential Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new ComplexExponential(double.Parse((param as string[])[0]), double.Parse((param as string[])[1]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
