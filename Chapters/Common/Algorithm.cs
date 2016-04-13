using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Chapters.Entity;

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

        public static bool IsPalindrome(this object something)
        {
            var s = something.ToString();
            for (int i = 0; i < s.Length / 2; i++)
                if (char.ToLower(s[i]) != char.ToLower(s[s.Length - i - 1]))
                    return false;

            return true;
        }

        public static DateTime GetRandomDate(this Random rnd, DateTime from, DateTime to)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
            return (from + randTimeSpan).Date;
        }

        public static T GetRandomElement<T>(this Random rnd, IEnumerable<T> sequence)
        {
            return sequence.ElementAt(rnd.Next(0, sequence.Count()));
        }

        public static void Serialize(this object obj, string path)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                formatter.Serialize(fs, obj);
        }

        public static IEnumerable<T> Deserialize<T>(this Stream stream)
        {
            return (List<T>) new BinaryFormatter().Deserialize(stream);
        }

        public static StreamReader ReadData(this string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return new StreamReader(assembly.GetManifestResourceStream(name));
        }

    }
}
