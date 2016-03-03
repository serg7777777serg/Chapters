using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Chapters
{
    class Chapter8Factory
    {
        public static object[] PerformTask(TaskNumber number)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = @"Chapters.Embedded_resources.UserInputFile.bin";
            var resources = assembly.GetManifestResourceNames();

            switch (number)
            {
                case TaskNumber.Task1:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A1 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var A1Even = A1.Where(x => x%2 == 0);
                        var A1Odd = A1.Where(x => x%2 == 1);
                        var A1EvenMax = A1Even.Max();
                        var A1OddMin = A1Odd.Min();
                        return new object[] {A1Even.Count(), A1Odd.Count(), A1EvenMax, A1OddMin};
                    }

                case TaskNumber.Task2:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A2 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var temp2 = A2.Where(x => x%2 == 1).OrderBy(x => x).Select(x => (byte) (x*2)).ToArray();
                        return new object[] { temp2.Length };
                    }

                case TaskNumber.Task3:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A3 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var temp3 = A3.Where(x => x>0 && x%5==0).OrderByDescending(x => x);
                        return new object[] { temp3.Count() };
                    }

                case TaskNumber.Task4:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A4 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var A4PosSimple = A4.Where(x => x > 0 && BinaryFile.IsSimple(x)).Count();
                        var A4NegSimple = A4.Where(x => x < 0 && BinaryFile.IsSimple(x)).Count();
                        var A4ZeroCount = A4.Where(x => x == 0).Count();
                        return new object[] { A4PosSimple, A4NegSimple, A4ZeroCount };
                    }

                case TaskNumber.Task5:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A5 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        byte min = A5.Min();
                        var minIndex = A5.FindIndex(x => x==min);
                        var A5NotSimpleBeforeMin = A5.Where((x, i) => !BinaryFile.IsSimple(x) && i < minIndex).Count();
                        return new object[] { A5NotSimpleBeforeMin };
                    }

                case TaskNumber.Task6:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A6 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var max = A6.Max();
                        var maxIndex = A6.FindIndex(x => x == max);
                        var A6NotZeroAfterMax = A6.Where((x, i) => x != 0 && i > maxIndex).Count();
                        return new object[] { A6NotZeroAfterMax };
                    }

                case TaskNumber.Task7:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A7 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var _TMP = A7.Where((x, i) => x > 0).Aggregate(0, (x,y) => x+=y);
                        var positiveAvg = ((double)_TMP) / A7.Count();
                        var A7BiggerThanPositiveAvg = A7.Where(x => x > positiveAvg).Count();
                        return new object[] { A7BiggerThanPositiveAvg };
                    }

                case TaskNumber.Task8:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A8 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var min = A8.Min();
                        var max = A8.Max();
                        var minIndex = A8.FindIndex(x => x == min);
                        var maxIndex = A8.FindIndex(x => x == max);
                        var A8BeforeMinAfterMax = A8.Where((x, i) => i > maxIndex && i<minIndex).Count();
                        return new object[] { A8BeforeMinAfterMax };
                    }

                case TaskNumber.Task9:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A9 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var min = A9.Min();
                        var max = A9.Max();
                        var minIndex = A9.FindIndex(x => x == min);
                        var maxIndex = A9.FindIndex(x => x == max);
                        var A9BetweenMaxAndMin = minIndex < maxIndex ? A9.Where((x, i) => i > minIndex && i < maxIndex).Count() : A9.Where((x, i) => i < minIndex && i > maxIndex).Count();
                        return new object[] { A9BetweenMaxAndMin };
                    }

                case TaskNumber.Task10:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A10 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var A10EvenOdd = BinaryFile.Create(Chapter8TaskType.FromArray, A10.Where(x => x % 2 == 0).Concat(A10.Where(x => x % 2 == 1)).ToArray<byte>());
                        var max = A10EvenOdd.Max();
                        var min = A10EvenOdd.Min();
                        var maxOddIndex = A10EvenOdd.FindIndex(x => x%2==1 && x == max);
                        var minEvenIndex = A10EvenOdd.FindIndex(x => x%2 ==0 && x == min);
                        if (maxOddIndex != -1 && minEvenIndex != -1)
                            return new object[] { A10EvenOdd.Count(), maxOddIndex, minEvenIndex };
                        else return new object[] { 0, 0, 0 };
                    }

                case TaskNumber.Task11:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A11 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var Negative = A11.Where(x => x < 0);
                        var temp11 = A11.Where(x => BinaryFile.IsSimple(x));
                        if (!Negative.Any() || !temp11.Any())
                            return new object[] { 0,0,0,0,0,0 };
                        var maxNegative = Negative.Max();
                        var maxNegativeIndex = A11.FindIndex(x => x == maxNegative);

                        var maxSimple = temp11.Max();
                        var maxSimpleIndex = A11.FindIndex(x => x == maxSimple);

                        A11.Swap(maxNegativeIndex, maxSimpleIndex);
                        A11.WriteData(11);
                        var temp1 = A11[maxNegativeIndex];
                        var temp2 = A11[maxSimpleIndex];

                        return new object[] { maxNegative, maxNegativeIndex, maxSimple, maxSimpleIndex, temp1, temp2};
                    }

                case TaskNumber.Task12:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A12 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var avg = Math.Ceiling(A12.Average(x => x));
                        var res12 = A12.Where(x => BinaryFile.IsSimple(x) == true && x > avg).ToArray();
                        BinaryFile.Create(Chapter8TaskType.FromArray, res12).WriteData(12);
                        return new object[] { res12.Count()};
                    }

                case TaskNumber.Task13:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A13 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var min = A13.Min();
                        var index = A13.FindIndex(x => x==min);
                        var wasMin = false;
                        var isSequenceStart = false;
                        var _TMP = A13.Where((x, i) =>
                        {
                            if (wasMin)
                                isSequenceStart = true;

                            if (x == min)
                                wasMin = true;

                            return isSequenceStart && BinaryFile.IsSimple(x);
                        }).Aggregate(new Point(0, 0), (x, y) => {

                            x.X += 1;
                            x.Y += y;
                            return x;
                        });

                        return new object[] {((double) _TMP.Y)/_TMP.X};
                    }

                case TaskNumber.Task14:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A14 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var firstPerfectIndex = A14.FindIndex(x => BinaryFile.IsPerfect(x));
                        var lastNegativeIndex = A14.FindLastIndex(x => x<0);
                        if (firstPerfectIndex == -1 || lastNegativeIndex == -1)
                            return new object[] { 0,0,0,0,0,0};
                        var temp1 = A14[firstPerfectIndex];
                        var temp2 = A14[lastNegativeIndex];
                        
                        A14.Swap(firstPerfectIndex, lastNegativeIndex);
                        A14.WriteData(14);

                        var temp3 = A14[firstPerfectIndex];
                        var temp4 = A14[lastNegativeIndex];
                        return new object[] {temp1, firstPerfectIndex ,temp2, lastNegativeIndex, temp3, temp4};
                    }

                case TaskNumber.Task15:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A15 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var res15 = A15.Where(x => BinaryFile.IsSimple(x)).OrderByDescending(x=>x);
                        return new object[] { res15.Count() };
                    }

                case TaskNumber.Task16:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A16 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var res16 = A16.FindLastPerfectSequence();
                        BinaryFile.Create(Chapter8TaskType.FromArray, res16).WriteData(16);
                        return new object[] { res16.Count() };
                    }

                case TaskNumber.Task17:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A17 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var res17 = A17.Where(x=>x<0).Count();
                        return new object[] { res17 };
                    }

                case TaskNumber.Task18:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A18 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var differentValues = A18.Distinct();
                        var res18 = differentValues.Where(x=>BinaryFile.IsSimple(x)).ToArray();
                        var res181 = differentValues.Where(x=>BinaryFile.IsPerfect(x)).ToArray();
                        return new object[] { A18.Count(x => res18.Contains(x)), res18.Max(), A18.Count(x=> res181.Contains(x)), res181.Min() };
                    }

                case TaskNumber.Task19:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A19 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var max = A19.Max();
                        var index = A19.FindIndex(x => x == max);
                        var res19 = A19.Where((x, i) => i> index && BinaryFile.IsSimple(x));

                        return new object[] { res19.Count() };
                    }

                case TaskNumber.Task20:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A20 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var min = A20.Min();
                        var index = A20.FindIndex(x => x == min);
                        var res = A20.Where((x, i) => i < index && x % 3 == 0).Count();
                        
                        return new object[] { res };
                    }

                case TaskNumber.Task21:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A21 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var _TMP = A21.Where( (x, i) => x%2==0 ).Aggregate(new Point(0, 0), (x, y) => {

                            x.X += 1;
                            x.Y += y;
                            return x;
                        });
                        var avg = ((double) _TMP.Y)/_TMP.X;
                        var res21 = A21.Where(x => x > avg);
                        return new object[] { res21.Count() };
                    }


                case TaskNumber.Task22:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A22 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var differentValues = A22.Distinct();
                        var differentSimples = differentValues.Where(x => BinaryFile.IsSimple(x));
                        var differentPerfects = differentValues.Where(x => BinaryFile.IsPerfect(x));

                        var index = A22.FindLastIndex(x => differentSimples.Contains(x));
                        
                        var minPerfect = differentPerfects.Min();
                        var index2 = A22.FindIndex(x => x == minPerfect);

                        if (index == -1 || index2 == -1)
                            return new object[] {0, 0, 0};
                        var oldSLastimple = A22[index];
                        var oldMinPerfect = A22[index2];

                        A22.Swap(index, index2);
                        var newSLastimple = A22[index];
                        var newMinPerfect = A22[index2];
                        return new object[] { oldSLastimple, oldMinPerfect, newSLastimple, newMinPerfect};
                    }

                case TaskNumber.Task23:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A23 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var res23 = A23.FindLastNegativeSequence().Aggregate(0, (x, y) => x+=y);

                        return new object[] { res23 };
                    }

                case TaskNumber.Task24:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A24 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var res24 = A24.FindFirstSimpleSequenceProduction().Aggregate(0, (x, y) => x*=y);

                        return new object[] { res24};
                    }

                case TaskNumber.Task25:
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        var A25 = BinaryFile.Create(Chapter8TaskType.FromStream, stream);
                        var res25 = A25.Where(x=>BinaryFile.IsSimple(x)).Aggregate(0, (x, y) => x+=y);

                        return new object[] { res25 - A25.Max() };
                    }
                default:
                    throw new ArgumentOutOfRangeException(number.GetType().Name, number, null);
            }
        }
    }
}
