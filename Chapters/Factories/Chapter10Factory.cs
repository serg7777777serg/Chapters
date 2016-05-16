using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapters.Common;
using Chapters.Entity;
using System.Threading;

namespace Chapters.Factories
{
    class Chapter10Factory
    {

        public static object[] PerformTask(TaskNumber number)
        {
            var complexData = new[] { "2", "-5" };

            //var A1_6_11_16_20_24 = new Lazy<Complex>(() =>
            //{
            //    var complexData = new[] { "2", "-5" };
            //    return Complex.Create(Chapter10TaskType.FromString, complexData);
            //});
            var A2_7_12_18_23 = new Lazy<CommonFraction>(() =>
            {
                var fractionData = new[] {"6", "18"};
                return CommonFraction.Create(Chapter10TaskType.FromString, fractionData);
            }).Value;
            var A3_8_13_17 = new Lazy<Vector>(() =>
            {
                var vectorData = new[] {"2", "3", "4"};
                return Vector.Create(Chapter10TaskType.FromString, vectorData);
            }).Value;
            var A5_10 = new Lazy<Straight>(() =>
            {
                var straightData = new[] {"70","26","11","15"};
                return Straight.Create(Chapter10TaskType.FromString, straightData);
            }).Value;

            switch (number)
            {
                case TaskNumber.Task1:
                case TaskNumber.Task6:
                    var A1_6 = ComplexAlgebraic.Create(Chapter10TaskType.FromString, complexData);
                    var tempAlgebraic = ComplexAlgebraic.Create(Chapter10TaskType.FromString, new string[] { "7", "11" });

                    var root = A1_6.Root(2).ToList();
                    var display = A1_6.ToString();
                    var sum = A1_6 + tempAlgebraic;
                    var substract = A1_6-tempAlgebraic;
                    var composition = A1_6*tempAlgebraic;
                    var devision = A1_6/tempAlgebraic;
                    var abs = A1_6.Abs;
                    var pow = ComplexAlgebraic.Pow(A1_6, 5.0);
                    
                    return new object[] { display, tempAlgebraic, root, sum, substract, composition, devision, abs, pow };

                case TaskNumber.Task11:
                case TaskNumber.Task20:
                    var A11_20 = ComplexTrigonometric.Create(Chapter10TaskType.FromString, complexData);
                    var tempTrigonometric = ComplexTrigonometric.Create(Chapter10TaskType.FromString, new string[] { "7", "11" });

                    return new object[] { A11_20.ToString(), tempTrigonometric, A11_20.Pow(5).ToString(), A11_20+tempTrigonometric, A11_20-tempTrigonometric, A11_20*tempTrigonometric, A11_20/tempTrigonometric };

                case TaskNumber.Task16:
                case TaskNumber.Task24:
                    var A16_24 = ComplexExponential.Create(Chapter10TaskType.FromString, complexData);
                    var tempExponential = ComplexExponential.Create(Chapter10TaskType.FromString, new string[] { "7", "11" });

                    return new object[] { A16_24.ToString(), tempExponential, A16_24+tempExponential, A16_24-tempExponential, A16_24*tempExponential, A16_24/tempExponential};

                case TaskNumber.Task2:
                case TaskNumber.Task7:
                case TaskNumber.Task12:
                case TaskNumber.Task18:
                case TaskNumber.Task23:
                    var tempFraction = new Lazy<CommonFraction>(() =>
                    {
                        var fractionData = new[] { "4", "10" };
                        return CommonFraction.Create(Chapter10TaskType.FromString, fractionData);
                    }).Value;
                    var sumFractions = A2_7_12_18_23 + tempFraction;
                    var substractFractions = A2_7_12_18_23 - tempFraction;
                    var compositionFraction = A2_7_12_18_23 * tempFraction;
                    var devideFractions = A2_7_12_18_23 / tempFraction;
                    var tt = A2_7_12_18_23.Invert().ToString();
                    return new object[]
                    {
                        A2_7_12_18_23.ToString(), tempFraction.ToString(), A2_7_12_18_23.ToDecimalRound(), A2_7_12_18_23.Reduct().ToString(), tt,
                        sumFractions, substractFractions, compositionFraction, devideFractions, A2_7_12_18_23 > tempFraction, A2_7_12_18_23 < tempFraction,
                        A2_7_12_18_23.Pow(3).ToString()
                    };

                case TaskNumber.Task3:
                case TaskNumber.Task8:
                case TaskNumber.Task13:
                case TaskNumber.Task17:
                    var tempVector = new Lazy<Vector>(() =>
                    {
                        var vectorData = new[] { "5", "7", "3" };
                        return Vector.Create(Chapter10TaskType.FromString, vectorData);
                    }).Value;

                    return new object[]
                    {
                        A3_8_13_17.ToString(), tempVector.ToString(), A3_8_13_17.Length, A3_8_13_17+tempVector, A3_8_13_17%tempVector,
                        A3_8_13_17*tempVector, A3_8_13_17.DirectionCosines(), A3_8_13_17/tempVector, A3_8_13_17|tempVector
                    };

                case TaskNumber.Task5:
                case TaskNumber.Task10:
                    var tempStraight = new Lazy<Straight>(() =>
                    {
                        var straightData = new[] { "15", "40", "21", "3" };
                        return Straight.Create(Chapter10TaskType.FromString, straightData);
                    }).Value;

                    return new object[] { A5_10.ToString(), tempStraight, A5_10 | tempStraight, A5_10%tempStraight, A5_10.CrossPoints, A5_10!=tempStraight };
                    
                case TaskNumber.Task15:
                case TaskNumber.Task21:                    
                case TaskNumber.Task25:
                    var A15_21_25 = new Lazy<MyDateTime>(() =>
                    {
                        var MyDateTimeData = new[] { "2016", "05", "01", "12", "01", "00" };
                        return MyDateTime.Create(Chapter10TaskType.FromString, MyDateTimeData);
                    }).Value;
                    var tempMyDateTime = new Lazy<MyDateTime>(() =>
                    {
                        var MyDateTimeData = new[] { "2014", "12", "09", "09", "20", "00" };
                        return MyDateTime.Create(Chapter10TaskType.FromString, MyDateTimeData);
                    }).Value;
                    var sumTime = A15_21_25 + tempMyDateTime;
                    var substractTime = A15_21_25 - tempMyDateTime;
                    return new object[] {A15_21_25.ToString(), tempMyDateTime.ToString(), A15_21_25.DayPart(), A15_21_25.Season(), sumTime, substractTime, A15_21_25>tempMyDateTime, A15_21_25<tempMyDateTime, A15_21_25+18 };

                default:
                    throw new ArgumentOutOfRangeException(number.GetType().Name, number, null);
            }
        }
    }
}