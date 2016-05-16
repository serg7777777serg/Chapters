using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    class ComplexAlgebraic : Complex, IEnumerable<ComplexAlgebraic>
    {
        private double Ro { get; set; }
        private double Fi { get; set; }

        private ComplexAlgebraic(double r = 0, double im = 0): base(r,im)
        {
            Real = r;
            Imaginary = im;
        }

        

        public const double Pi = 3.141592653589793238462643383279502884197169399311481966593000573842001111842089549379151d;
        public double Abs    ///           6
        {
            get { return Math.Sqrt(SqrAbs); }
            // set { this *= value / this.Abs; }
        }
        public double SqrAbs ///           1
        {
            get { return Real * Real + Imaginary * Imaginary; }
            // set { this *= System.Math.Sqrt(value / this.SqrAbs); }
        }
        public double Arg
        {
            get { return Math.Atan2(Imaginary, Real); }
            set
            {
                double abs = Abs;
                Real = abs * Math.Cos(value);
                Imaginary = abs * Math.Sin(value);
            }
        }
        public static ComplexAlgebraic Pow(ComplexAlgebraic z, double n)   ///         6
        {
            return Math.Pow(z.Abs, n) * new ComplexAlgebraic(Math.Cos(z.Arg * n), Math.Sin(z.Arg * n));
        }

        public IEnumerable<ComplexAlgebraic> Root(uint n)
        {
            //ComplexAlgebraic[] res = new ComplexAlgebraic[n];
            for (int i = 0; i < n; i++)
                yield return new ComplexAlgebraic(Math.Pow(Ro, 1 / n) * Math.Cos((Fi + 2 * Pi * i) / n), Math.Pow(Ro, 1 / n) * Math.Sin((Fi + 2 * Pi * i) / n));
           // return res;
        }

        public static ComplexAlgebraic Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new ComplexAlgebraic(double.Parse((param as string[])[0]), double.Parse((param as string[])[1]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }

        #region Binaries algebraic
        public static ComplexAlgebraic operator +(ComplexAlgebraic z1, ComplexAlgebraic z2) { return new ComplexAlgebraic(z1.Real + z2.Real, z1.Imaginary + z2.Imaginary); }
        public static ComplexAlgebraic operator -(ComplexAlgebraic z1, ComplexAlgebraic z2) { return z1 + -z2; }
        public static ComplexAlgebraic operator *(ComplexAlgebraic z1, ComplexAlgebraic z2) { return new ComplexAlgebraic(z1.Real * z2.Real - z1.Imaginary * z2.Imaginary, z1.Real * z2.Imaginary + z1.Imaginary * z2.Real); }
        public static ComplexAlgebraic operator /(ComplexAlgebraic z1, ComplexAlgebraic z2) { return z1 * ~z2 / z2.SqrAbs; }
        public static ComplexAlgebraic operator %(ComplexAlgebraic z1, ComplexAlgebraic z2) { return new ComplexAlgebraic(z1.Real % z2.Real, z1.Imaginary % z2.Imaginary); }
        public static ComplexAlgebraic operator +(ComplexAlgebraic z1, double d2) { return z1 + new ComplexAlgebraic(d2, 0d); }
        public static ComplexAlgebraic operator -(ComplexAlgebraic z1, double d2) { return z1 + -d2; }
        public static ComplexAlgebraic operator *(ComplexAlgebraic z1, double d2) { return new ComplexAlgebraic(z1.Real * d2, z1.Imaginary * d2); }
        public static ComplexAlgebraic operator %(ComplexAlgebraic z1, double d2) { return z1 % new ComplexAlgebraic(d2, 0d); }
        public static ComplexAlgebraic operator /(ComplexAlgebraic z1, double d2) { return z1 * (1d / d2); }
        public static ComplexAlgebraic operator +(double d1, ComplexAlgebraic z2) { return z2 + d1; }
        public static ComplexAlgebraic operator -(double d1, ComplexAlgebraic z2) { return -z2 + d1; }
        public static ComplexAlgebraic operator *(double d1, ComplexAlgebraic z2) { return z2 * d1; }
        public static ComplexAlgebraic operator /(double d1, ComplexAlgebraic z2) { return new ComplexAlgebraic(d1, 0d) / z2; }
        public static ComplexAlgebraic operator %(double d1, ComplexAlgebraic z2) { return new ComplexAlgebraic(d1, 0d) % z2; }
        public static bool operator ==(ComplexAlgebraic z1, ComplexAlgebraic z2) { return z1.Equals(z2); }
        public static bool operator !=(ComplexAlgebraic z1, ComplexAlgebraic z2) { return !z1.Equals(z2); }
        #endregion

        #region Unaries
        public static ComplexAlgebraic operator ~(ComplexAlgebraic z) { return new ComplexAlgebraic(z.Real, -z.Imaginary); }
        public static ComplexAlgebraic operator !(ComplexAlgebraic z) { return ~z; }
        public static ComplexAlgebraic operator ++(ComplexAlgebraic z) { return new ComplexAlgebraic(++z.Real, z.Imaginary); }
        public static ComplexAlgebraic operator --(ComplexAlgebraic z) { return new ComplexAlgebraic(--z.Real, z.Imaginary); }
        public static ComplexAlgebraic operator +(ComplexAlgebraic z) { return z; }
        public static ComplexAlgebraic operator -(ComplexAlgebraic z) { return new ComplexAlgebraic(-z.Real, -z.Imaginary); }
        public static explicit operator ComplexAlgebraic(double d) { return new ComplexAlgebraic(d, 0d); }
        #endregion

        public override string ToString()
        {
            return string.Format("{0} {2}{1}i", Real, Imaginary, Imaginary < 0 ? "" : "+");
        }

        public IEnumerator<ComplexAlgebraic> GetEnumerator()
        {
            foreach (var t in this)
                yield return t;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
