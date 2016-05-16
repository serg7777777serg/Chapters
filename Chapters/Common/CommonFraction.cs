using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    class CommonFraction : IEquatable<CommonFraction> //23, 18, 12, 7, 2
    {
        private int Numerator { get; set; }
        private int Denominator { get; set;  }

        private CommonFraction(int n=1, int d=1)
        {
            Numerator = n;
            Denominator = d;
        }

        #region Unary
        public static CommonFraction operator -(CommonFraction A)
        {
            A.Numerator *= -1;
            return A;
        }
        public static CommonFraction operator ++(CommonFraction A)
        {
            A.Numerator += A.Denominator;
            return A;
        }
        public static CommonFraction operator --(CommonFraction A)
        {
            A.Numerator -= A.Denominator;
            return A;
        }
        #endregion

        #region Binary
        public static CommonFraction operator *(CommonFraction A, CommonFraction B)
        {
            return new CommonFraction(A.Numerator*B.Numerator, A.Denominator*B.Denominator);
        }
        public static CommonFraction operator /(CommonFraction A, CommonFraction B)
        {
            return new CommonFraction(A.Numerator*B.Denominator, A.Denominator*B.Numerator);
        }
        public static CommonFraction operator +(CommonFraction A, CommonFraction B)
        {
            return new CommonFraction(A.Numerator * B.Denominator + B.Numerator * A.Denominator, A.Denominator * B.Denominator);
        }
        public static CommonFraction operator -(CommonFraction A, CommonFraction B)
        {
            return new CommonFraction(A.Numerator * B.Denominator - B.Numerator * A.Denominator, A.Denominator * B.Denominator);
        }
        #endregion

        #region Equalities, comparations
        public static bool operator ==(CommonFraction A, CommonFraction B)
        {
            return A.ToDecimal() == B.ToDecimal();
        }
        public static bool operator !=(CommonFraction A, CommonFraction B)
        {
            return A.ToDecimal() != B.ToDecimal();
        }
        public static bool operator >(CommonFraction A, CommonFraction B)
        {
            return A.ToDecimal() > B.ToDecimal(); // ? A : B;
        }
        public static bool operator <(CommonFraction A, CommonFraction B)
        {
            return A.ToDecimal() < B.ToDecimal();// ? A : B;
        }
        public static bool operator >=(CommonFraction A, CommonFraction B)
        {
            return A.ToDecimal() >= B.ToDecimal();
        }
        public static bool operator <=(CommonFraction A, CommonFraction B)
        {
            return A.ToDecimal() <= B.ToDecimal();
        }

        #endregion


        public override string ToString()
        {
            return ToDecimal() > 0 ? string.Format("{0}/{1}", Math.Abs(Numerator), Math.Abs(Denominator)) : string.Format("-{0}/{1}", Math.Abs(Numerator), Math.Abs(Denominator));
        }

        private int gcd(int a, int b)
        { return b == 0 ? a : gcd(b, a % b); } //наибольший общий делитель

        public CommonFraction Reduct()
        {
            var temp = gcd(Numerator, Denominator);
            return new CommonFraction(Numerator / temp, Denominator / temp);
        }
        public CommonFraction Invert()
        {
            return new CommonFraction(this.Denominator, this.Numerator);
        }
        public CommonFraction Pow(int value)
        {
            return new CommonFraction((int)Math.Pow(Numerator,value), (int)Math.Pow(Denominator,value));
        }

        private double ToDecimal()
        {
            return (double) Numerator / Denominator;
        }
        public double ToDecimalRound()
        {
            return Math.Round(ToDecimal(),5);
        }

        public bool Equals(CommonFraction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return (double)Numerator / Denominator == (double)other.Numerator / other.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(CommonFraction) && Equals((CommonFraction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator * 397) ^ Denominator;
            }
        }

        public static CommonFraction Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new CommonFraction(int.Parse((param as string[])[0]), int.Parse((param as string[])[1]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
