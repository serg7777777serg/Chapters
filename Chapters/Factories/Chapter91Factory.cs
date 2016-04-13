using Chapters.Common;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Chapters
{
    class Chapter91Factory
    {
        public static string Input = @"Hello , World!!!3 , - wrote junior developer in his first ok program";
        public static string input2 = " ! !";

        

        public static object[] PerformTask(TaskNumber number)
        {
            using (var stream = @"Chapters.Embedded_resources.916-925.txt".ReadData())
            {
                var textData = stream.ReadToEnd();
                //var fileLines = textData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                switch (number)
                {
                    case TaskNumber.Task1:
                        var A1 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res1 = A1.Count(x => char.IsPunctuation(x));
                        return new object[] {res1};

                    case TaskNumber.Task2:
                        var A2 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res2 = A2.Count(x => x == '.' || x == '!');
                        return new object[] {res2};

                    case TaskNumber.Task3:
                        var A3 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var temp3 = A3.Where(x => x != ',').ToArray();
                        var res3 = StringAlgorithms.Create(Chapter9_1TaskType.FromCharsArray, temp3);
                        return new object[] {res3};

                    case TaskNumber.Task4:
                        var A4 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        A4.RemoveSpacesBeforePunctuation();
                        return new object[] {A4};

                    case TaskNumber.Task5:
                        var A5 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        A5.InsertNumberAfterSpaces(12345);
                        return new object[] {A5};

                    case TaskNumber.Task6:
                        var A6 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        A6.InsertNumberBeforeExclamation(123456);
                        return new object[] {A6};

                    case TaskNumber.Task7:
                        var A7 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res7 = A7.ExtractNumbers().Sum();
                        return new object[] {res7};

                    case TaskNumber.Task8:
                        var A8 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var temp8 = A8.Where(x => !char.IsDigit(x)).ToArray();
                        var res8 = StringAlgorithms.Create(Chapter9_1TaskType.FromCharsArray, temp8);
                        return new object[] {res8};

                    case TaskNumber.Task9:
                        var A9 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res9 = A9.ExtractNumbers().Where(x => x.IsSimple(y=>y)).Sum();
                        return new object[] {res9};

                    case TaskNumber.Task10:
                        var A10 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        A10.DeleteMaxLengthWords();
                        return new object[] {A10};

                    case TaskNumber.Task11:
                        var A11 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res11 = A11.ExtractNumbers().Where(x => x.IsSimple(y=>y)).Count();
                        return new object[] {res11};

                    case TaskNumber.Task12:
                        var A12 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        A12.InsertSpaceAfterPunctuation();
                        return new object[] {A12};

                    case TaskNumber.Task13:
                        var A13 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        A13.ReverseWords();
                        return new object[] {A13};

                    case TaskNumber.Task14:
                        var A14 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res14 = A14.MinWordCount();
                        return new object[] {res14};

                    case TaskNumber.Task15:
                        var A15 = StringAlgorithms.Create(Chapter9_1TaskType.FromString, Input);
                        var res15 = A15.VowelEndLetterCount();
                        return new object[] {res15};

                    case TaskNumber.Task16:
                        var A16 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A16.CountWordsInAOddLines() };

                    case TaskNumber.Task17:
                        var A17 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A17.CountSimplesInTheText() };

                    case TaskNumber.Task18:
                        var A18 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A18.CountPunctuationsInTheEvenLines() };

                    case TaskNumber.Task19:
                        var A19 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] {A19.CountSentencesInTheText() };

                    case TaskNumber.Task20:
                        var A20 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A20.CountPalindromeWordsInTheText() };

                    case TaskNumber.Task21:
                        var A21 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A21.RemovePalindromsNumbersIn3And7Lines() };

                    case TaskNumber.Task22:
                        var A22 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A22.FindLongestSentence() };

                    case TaskNumber.Task23:
                        var A23 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A23.FindFirstAndLastSentences() };

                    case TaskNumber.Task24:
                        var A24 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A24.ReverseSentences() };

                    case TaskNumber.Task25:
                        var A25 = StringAlgorithms.Create(Chapter9_1TaskType.FromFile, textData);
                        return new object[] { A25.FindMaxNumbersCount() };

                    default:
                        throw new ArgumentOutOfRangeException(number.GetType().Name, number, null);
                }
            }
        }
    }
}
