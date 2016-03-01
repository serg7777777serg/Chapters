using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapters
{
    class Chapter9Factory
    {
        public static string input = @"Hello, World!!!,- wrote junior developer in his first program";

        public static object[] PerformTask(TaskNumber number)
        {
            
            switch (number)
            {
                case TaskNumber.Task1:
                    var A1 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input); 
                    return new object[] { A1.PunctuationCount() };

                case TaskNumber.Task2:
                    var A2 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    return new object[] { A2.PointExclamationPointCount() };

                case TaskNumber.Task3:
                    var A3 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A3.RemoveAllCommas();
                    return new object[] { A3 };

                case TaskNumber.Task4:
                    var A4 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A4.RemoveSpacesBeforePunctuation();
                    return new object[] { A4 };

                case TaskNumber.Task5:
                    var A5 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A5.InsertNumberAfterSpaces(5555);
                    return new object[] { A5 };

                case TaskNumber.Task6:
                    var A6 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A6.InsertNumberBeforeExclamation(66666);
                    return new object[] { A6 };

                case TaskNumber.Task7:
                    var A7 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    return new object[] { A7.SumAllNumbers() };

                case TaskNumber.Task8:
                    var A8 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A8.RemoveNumbers();
                    return new object[] { A8 };

                case TaskNumber.Task9:
                    var A9 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    return new object[] { A9.SumAllSimpleNumbers() };

                case TaskNumber.Task10:
                    var A10 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A10.RemoveMaxLengthWord();
                    return new object[] { A10 };

                case TaskNumber.Task11:
                    var A11 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    return new object[] { A11.FindSimpleNumbers() };

                case TaskNumber.Task12:
                    var A12 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A12.InsertSpaceAfterPunctuation();
                    return new object[] { A12 };

                case TaskNumber.Task13:
                    var A13 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);
                    A13.ReverseWords();
                    return new object[] { A13 };
                    
                case TaskNumber.Task14:
                    var A14 = Chapters.Common.StringAlgorithms.Create(Chapter9TaskType.FromString, input);

                    return new object[] { };

                case TaskNumber.Task15:

                    return new object[] { };
                    
                case TaskNumber.Task16:

                    return new object[] { };

                case TaskNumber.Task17:

                    return new object[] { };

                case TaskNumber.Task18:

                    return new object[] { };

                case TaskNumber.Task19:

                    return new object[] { };

                case TaskNumber.Task20:

                    return new object[] { };

                case TaskNumber.Task21:

                    return new object[] { };

                case TaskNumber.Task22:

                    return new object[] { };

                case TaskNumber.Task23:

                    return new object[] { };
                    
                case TaskNumber.Task24:

                    return new object[] { };

                case TaskNumber.Task25:

                    return new object[] { };

                default:
                    throw new ArgumentOutOfRangeException(number.GetType().Name, number, null);
            }
        }
    }
}
