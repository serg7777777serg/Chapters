using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    public static class Algorithm
    {
        public static bool IsSimple<T>(this T d, Func<T, int> predicate)
        {
            int p = predicate(d);
            if (p <= 1)
                return false;

            for (var i = 2; i <= Math.Ceiling(Math.Sqrt(p)); i++)
                if (p % i == 0)
                    return false;

            return true;
        }

        public static bool IsPerfect<T>(this T d, Func<T, int> predicate)
        {
            int p = predicate(d);
            if (p <= 1)
                return false;

            var sum = 0;
            for (var i = 1; i < p; i++)
                if (p % i == 0)
                    sum += i;

            if (sum == p)
                return true;

            return false;

        }

        public static bool IsPalindrome(this string s)
        {
            for (int i = 1, j = s.Length - 1; i < j; i++, j--)
                if (char.ToLower(s[i]) != char.ToLower(s[j]))
                    return false;
            return true;
        }
    }
}
