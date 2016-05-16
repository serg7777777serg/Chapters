using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Chapters.Common
{
    abstract class Complex
    {
        public const double Pi = 3.141592653589793238462643383279502884197169399311481966593000573842001111842089549379151d;
        
        protected double Real { get; set; }
        protected double Imaginary { get; set; }
       
        public Complex(double r, double im)
        {
            Real = r;
            Imaginary = im;
            //Ro = ro;
            //Fi = fi;
        }
        
        //public Complex MultipleI { get { return new Complex(-this.Im, this.Re); } }
        //public Complex DivideI { get { return new Complex(this.Im, -this.Re); } }
        
        #region Методи предков System.(Object, IFormattable, IEquatable<Complex>)
        //public bool Equals(Complex other) { return this.Re.Equals(other.Re) && this.Im.Equals(other.Im); }
        //public override bool Equals(object obj)
        //{
        //    try { return this.Equals((Complex)obj); }
        //    catch { return false; }
        //}
        //public override int GetHashCode() { return this.Re.GetHashCode() + this.Im.GetHashCode(); }

        //public override string ToString()  /////////////////////////////////////////////////////////////////////////////            1, 6
        //{
        //    return this.Re.ToString() + (this.Im < 0 ? " " : " +") + this.Im.ToString() + 'i';
        //}
        //public string ToString(string format, System.IFormatProvider provider)     //////////////////////////////////////           1, 6
        //{
        //    return this.Re.ToString(format, provider) + (this.Im < 0 ? " " : " +") + this.Im.ToString(format, provider) + 'i';
        //}
        #endregion

        #region Trigonometric functions
        //public static Complex Exp(Complex z)
        //{
        //    return System.Math.Exp(z.Re) * (new Complex(System.Math.Cos(z.Im), System.Math.Sin(z.Im)));
        //}
        //public static Complex Log(Complex z) { return Log(z, 0); }
        //public static Complex Log(Complex z, int k)
        //{
        //    return new Complex(System.Math.Log(z.Abs), z.Arg + 2d * k * Pi);
        //}
        //public static Complex Log(Complex z, int kz, Complex a, int ka) { return Log(z, kz) / Log(a, ka); }

        //public static Complex Pow(Complex z, double n)   //////////////////////////////////////////////////////////////////      6
        //{
        //    return System.Math.Pow(z.Abs, n) * new Complex(System.Math.Cos(z.Arg * n), System.Math.Sin(z.Arg * n));
        //}
        //public static Complex Pow(Complex z, Complex n) { return Pow(z, n, 0); }
        ////public static Complex Pow(Complex z, Complex n, int k) { return Exp(n * Log(z, k)); }

        //public static Complex Sqrt(Complex z, int k) { return Pow(z, new Complex(0.5d, 0d), k); }
        //
        //public static Complex Sin(Complex z) { return Sinh(z.MultipleI).DivideI; }
        //public static Complex Cos(Complex z) { return Cosh(z.MultipleI); }
        //public static Complex Tan(Complex z) { return Tanh(z.MultipleI).DivideI; }
        //public static Complex Cot(Complex z) { return Coth(z.MultipleI).MultipleI; }
        //public static Complex Sec(Complex z) { return Sech(z.MultipleI); }
        //public static Complex Csc(Complex z) { return Csch(z.MultipleI).MultipleI; }
        //public static Complex Sinh(Complex z) { return Sinh2(z) / 2d; }
        //public static Complex Sinh2(Complex z) { return (Exp(z) - Exp(-z)); }
        //public static Complex Cosh(Complex z) { return Cosh2(z) / 2d; }
        //public static Complex Cosh2(Complex z) { return (Exp(z) + Exp(-z)); }
        //public static Complex Tanh(Complex z) { return Sinh2(z) / Cosh2(z); }
        //public static Complex Coth(Complex z) { return Cosh2(z) / Sinh2(z); }
        //public static Complex Sech(Complex z) { return 2d / Cosh2(z); }
        //public static Complex Csch(Complex z) { return 2d / Sinh2(z); }
        //
        //public static Complex Asin(Complex z, int kLog, int kSqrt) { return Asinh(z.MultipleI, kLog, kSqrt).DivideI; }
        //public static Complex Acos(Complex z, int kLog, int kSqrt) { return Acosh(z, kLog, kSqrt).DivideI; }
        //public static Complex Atan(Complex z, int kLog) { return Atanh(z.DivideI, kLog).MultipleI; }
        //public static Complex Acot(Complex z, int kLog) { return Atan(1d / z, kLog); }
        //public static Complex Asec(Complex z, int kLog, int kSqrt) { return Acos(1d / z, kLog, kSqrt); }
        //public static Complex Acsc(Complex z, int kLog, int kSqrt) { return Asin(1d / z, kLog, kSqrt); }
        //public static Complex Asinh(Complex z, int kLog, int kSqrt) { return Log(z + Sqrt(z * z + 1d, kSqrt), kLog); }
        //public static Complex Acosh(Complex z, int kLog, int kSqrt) { return Log(z + Sqrt(z * z - 1d, kSqrt), kLog); }
        //public static Complex Atanh(Complex z, int kLog) { return Log((1d + z) / (1d - z), kLog) / 2d; }
        //public static Complex Acoth(Complex z, int kLog) { return Atanh(1d / z, kLog); }
        //public static Complex Asech(Complex z, int kLog, int kSqrt) { return Acosh(1d / z, kLog, kSqrt); }
        //public static Complex Acsch(Complex z, int kLog, int kSqrt) { return Asinh(1d / z, kLog, kSqrt); }
        #endregion

    }
}
