using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Chapters
{
    public class BinaryFile : IEnumerable<byte>
    {
        #region Private fields
        private byte[] source { get; set; }
        #endregion

        #region Constructors

        private BinaryFile()
        {}

        private BinaryFile(byte[] _source)
        {
            source = new byte[_source.Length];
            for (var i = 0; i < _source.Length; i++)
                source[i] = _source[i];
        }

        private BinaryFile(Stream _source)
        {
            source = new byte[_source.Length];
            _source.Read(source, 0, source.Length);
        }


        public static BinaryFile Create(Chapter8TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter8TaskType.FromArray:
                    return new BinaryFile(param as byte[]);
                case Chapter8TaskType.FromStream:
                    return new BinaryFile(param as Stream);

                case Chapter8TaskType.One:
                    return null;
                case Chapter8TaskType.Two:
                    return null;
                case Chapter8TaskType.Three:
                    var arg = param as Tuple<double[], double[]>;
                    return null;
                case Chapter8TaskType.Sixteen:
                    return null;
                case Chapter8TaskType.Seventeen:
                    return null;

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
        #endregion

        #region Properties

        public byte[] data
        {
            get { return source; } 
        }

        public int Length
        {
            get { return source.Length; }
        }

        public byte this[int i]
        {
            get { return source[i]; }
            set { source[i] = value; }
        }

        #endregion

        #region Overloaded operators

        public static BinaryFile operator *(BinaryFile A, byte koef)
        {
            return OpMultiply(A, koef);
        }

        private static BinaryFile OpMultiply(BinaryFile A, byte koef)
        {
            var result = Create(Chapter8TaskType.FromArray, A.data);

            for (var i = 0; i < result.Length; i++)
                    result[i] = (byte)(result[i] * koef);

            return result;
        }

        #endregion

        #region Interface implementations


        IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
        {
            foreach (var d in source)
                yield return d;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Public methods

        public static bool IsSimple(int p)
        {
            if (p <= 1)
                return false;

            for (var i = 2; i <= Math.Ceiling(Math.Sqrt(p)); i++)
                if (p % i == 0)
                    return false;

            return true;
        }

        public void Swap(int first, int second)
        {
            var temp = this[first];
            this[first] = this[second];
            this[second] = temp;
        }

       
        public int FindIndex(Predicate<byte> predicate)
        {
            for (var i = 0; i < source.Length; ++i)
                if (predicate(source[i]))
                    return i;

            return -1;
        }

        public int FindLastIndex(Predicate<byte> predicate)
        {
            for (var i = source.Length - 1; i >=0 ; --i)
                if (predicate(source[i]))
                    return i;

            return -1;
        }

        public async void WriteData(byte number)
        {
            // Set a variable to the My Documents path.
            var mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            // Open a streamwriter to a new text file named "UserInputFile.txt"and write the contents of 
            // the stringbuilder to it.
            using (var outfile = new StreamWriter(mydocpath + String.Format("\\ResultFile{0}.txt", number), true))
            {
                foreach (var s in data)
                    await outfile.WriteLineAsync(s.ToString());
            }
        }

        public static bool IsPerfect(int p)
        {
            if (p <= 1)
                return false;

            var sum = 0;
            for (var i = 1; i < p; i++)
                if (p%i == 0)
                    sum += i;

            if (sum == p)
                return true;

            return false;

        }
        #endregion

        public byte[] FindLastPerfectSequence()
        {
            if(Length==0)
                return new byte[] {0};
            var flag = false;
            var index=0;
            var res = new byte[Length];
            for (var i = Length - 1; i >= 0; i--)
            {
                if (IsPerfect(source[i]))
                    if (!flag)
                    {
                        index = i;
                        flag = true;
                    }
                    else
                    {
                        if (flag)
                        {          
                            for (var j = index; j > i; j--)
                                res[index - j] = source[j];
                            break;
                        }
                    }
            }
            return res.Where(x=>x!=0).ToArray<byte>();
        }

        public byte[] FindLastNegativeSequence()
        {
            if (Length == 0)
                return new byte[] { 0 };
            var flag = false;
            var index = 0;
            var res = new byte[Length];
            for (var i = Length - 1; i >= 0; i--)
            {
                if (source[i]<0)
                    if (!flag)
                    {
                        index = i;
                        flag = true;
                    }
                    else
                    {
                        if (flag)
                        {
                            for (var j = index; j > i; j--)
                                res[index - j] = source[j];
                            break;
                        }
                    }
            }
            return res.Where(x => x != 0).ToArray<byte>();
        }

        public byte[] FindFirstSimpleSequenceProduction()
        {
            if (Length == 0)
                return new byte[] { 0 };
            var flag = false;
            var index = 0;
            var res = new byte[Length];
            for (var i = 0; i < Length; i++)
            {
                if (IsPerfect(source[i]))
                    if (!flag)
                    {
                        index = i;
                        flag = true;
                    }
                    else
                    {
                        if (flag)
                        {
                            for (var j = index; j > i; j--)
                                res[index - j] = source[j];
                            break;
                        }
                    }
            }
            return res.Where(x => x != 0).ToArray<byte>();
        }

    }
}
