using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Chapters.Common;
using Chapters.Entity;
using Chapters.Factories;

namespace Chapters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 11000;
            #region Chapter 7

            #region 1
            ////1. C = 2(А + !В) - A*B
            //Console.WriteLine("{0}: create: 2nd matrix from the 1st, 3rd matrix from the 1st and 2nd",TaskNumber.Task1);
            //var res1 = Chapter7Factory.PerformTask(TaskNumber.Task1);
            //Console.WriteLine("1st matrix:\n{0}\n2nd matrix:\n{1}\n3rd matrix:\n{2}\n", res1[0], res1[1], res1[2]);

            var task701 = Tuple.Create(TaskNumber.Task1, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\nC H A P T E R 7\n");
                sb.AppendFormat("\n{0}: create: 2nd matrix from the 1st, 3rd matrix from the 1st and 2nd", TaskNumber.Task1);
                var res701 = Chapter7Factory.PerformTask(TaskNumber.Task1);
                sb.AppendFormat("\n1st matrix:\n{0}\n2nd matrix:\n{1}\n3rd matrix:\n{2}\n", res701[0], res701[1], res701[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 2
            //// 2. C(n) - source, A(n,n) = C[i]*C[j], B = A / max(A)
            //// Х(А + Е) = 3В - Е;
            //Console.WriteLine("{0}: create: 1st matrix A from array, 2nd matrix B from the 1st. Solve the matrix equation Х(А + Е) = 3В - Е", TaskNumber.Task2);
            //var res2 = Chapter7Factory.PerformTask(TaskNumber.Task2);
            //Console.WriteLine("1st matrix:\n{0}\n2nd matrix:\n{1}\nAnswer for equation\n{2}\n", res2[0], res2[1], res2[2]);

            var task702 = Tuple.Create(TaskNumber.Task2, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: create: 1st matrix A from array, 2nd matrix B from the 1st. Solve the matrix equation Х(А + Е) = 3В - Е", TaskNumber.Task2);
                var res702 = Chapter7Factory.PerformTask(TaskNumber.Task2);
                sb.AppendFormat("\n1st matrix:\n{0}\n2nd matrix:\n{1}\nAnswer for equation\n{2}\n", res702[0], res702[1], res702[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 3
            ////3. C(n), D(n) - source, A(n,n) = C[i]*D[j], B = A / min(A)
            //// (2A - E) X = B + E; X =  (_2A-E)^-1 * _BE = (!_2AE) * _BE 
            //Console.WriteLine("{0}: create: 1st matrix A from array, 2nd matrix B from the 1st. Solve the matrix equation (2A - E) X = B + E", TaskNumber.Task3);
            //var res3 = Chapter7Factory.PerformTask(TaskNumber.Task3);
            //Console.WriteLine("1st matrix:\n{0}\n2nd matrix:\n{1}\nAnswer for equation:\n{2}\n", res3[0], res3[1], res3[2]);

            var task703 = Tuple.Create(TaskNumber.Task3, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: create: 1st matrix A from array, 2nd matrix B from the 1st. Solve the matrix equation (2A - E) X = B + E", TaskNumber.Task3);
                var res703 = Chapter7Factory.PerformTask(TaskNumber.Task3);
                sb.AppendFormat("\n1st matrix:\n{0}\n2nd matrix:\n{1}\nAnswer for equation:\n{2}\n", res703[0], res703[1], res703[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 4
            ////4. IsOrtogonal matrix? (At = !A)
            //Console.WriteLine("{0}: A4 is ortogonal?", TaskNumber.Task4);
            //var res4 = Chapter7Factory.PerformTask(TaskNumber.Task4);
            //Console.WriteLine("Result: {0}\n", res4[0] );

            var task704 = Tuple.Create(TaskNumber.Task4, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: A4 is ortogonal?", TaskNumber.Task4);
                var res704 = Chapter7Factory.PerformTask(TaskNumber.Task4);
                sb.AppendFormat("\nResult: {0}\n", res704[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 5
            ////5. IsOrtogonal matrix H = E - ( v*(~v) / determinant(v)^2 )  ?
            //Console.WriteLine("{0}: H = E - ( v*(~v) / determinant(v)^2 ) is ortogonal?", TaskNumber.Task5);
            //var res5 = Chapter7Factory.PerformTask(TaskNumber.Task5);
            //Console.WriteLine("Result: {0}\n", res5[0]);

            var task705 = Tuple.Create(TaskNumber.Task5, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: H = E - ( v*(~v) / determinant(v)^2 ) is ortogonal?", TaskNumber.Task5);
                var res705 = Chapter7Factory.PerformTask(TaskNumber.Task5);
                sb.AppendFormat("\nResult: {0}\n", res705[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 6
            ////6. Are the source and source*source matrix equals?
            //Console.WriteLine("{0}: Check source == source*source ? source determinant - ?", TaskNumber.Task6);
            //var res6 = Chapter7Factory.PerformTask(TaskNumber.Task6);
            //Console.WriteLine("Determinant of source is {0}", res6[0]);
            //Console.WriteLine("source == source*source ? Result: {0}\n", res6[1]);

            var task706 = Tuple.Create(TaskNumber.Task6, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Check source == source*source ? source determinant - ?", TaskNumber.Task6);
                var res706 = Chapter7Factory.PerformTask(TaskNumber.Task6);
                sb.AppendFormat("\nDeterminant of source is {0}", res706[0]);
                sb.AppendFormat("\nsource == source*source ? Result: {0}\n", res706[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 7

            //Console.WriteLine("{0}: Check whether the vectors form a basis", TaskNumber.Task7);
            //var res7 = Chapter7Factory.PerformTask(TaskNumber.Task7);
            //Console.WriteLine("Result:\n{0}\n", res7[0]);

            var task707 = Tuple.Create(TaskNumber.Task7, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Check whether the vectors form a basis", TaskNumber.Task7);
                var res707 = Chapter7Factory.PerformTask(TaskNumber.Task7);
                sb.AppendFormat("\nResult:\n{0}\n", res707[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 8
            ////8. Find X vector as solved equation system
            //Console.WriteLine("{0}: ", TaskNumber.Task8);
            //var res8 = Chapter7Factory.PerformTask(TaskNumber.Task8);
            //Console.WriteLine("Equation system solving is\n{0}\nit's vector length is {1}\n", res8[0], res8[1]);

            var task708 = Tuple.Create(TaskNumber.Task8, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Solve equation system. Find angle between vectors", TaskNumber.Task8);
                var res708 = Chapter7Factory.PerformTask(TaskNumber.Task8);
                sb.AppendFormat("\nEquation system solving is\n{0}\nit's vector length is {1}\n", res708[0], res708[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 9
            ////9. Calculate scalar vectors product 
            //Console.WriteLine("{0}: Calculate scalar vectors product", TaskNumber.Task9);
            //var res9 = Chapter7Factory.PerformTask(TaskNumber.Task9);
            //Console.WriteLine("Scalar product of X and Y vectors is {0}\n", res9[0]);

            var task709 = Tuple.Create(TaskNumber.Task9, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Calculate scalar vectors product", TaskNumber.Task9);
                var res709 = Chapter7Factory.PerformTask(TaskNumber.Task9);
                sb.AppendFormat("\nScalar product of X and Y vectors is {0}\n", res709[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 10
            ////10. Slau solution product it's transporation
            //Console.WriteLine("{0}: Slau solution product it's transporation", TaskNumber.Task10);
            //var res10 = Chapter7Factory.PerformTask(TaskNumber.Task10);
            //Console.WriteLine("Slau solution product it's transporation is\n{0}\n", res10[0]);

            var task710 = Tuple.Create(TaskNumber.Task10, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Slau solution product it's transporation", TaskNumber.Task10);
                var res710 = Chapter7Factory.PerformTask(TaskNumber.Task10);
                sb.AppendFormat("\nSlau solution product it's transporation is\n{0}\n", res710[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 11
            ////11. Find the vector, calculating Slau. Find vector |2X-3| length
            //Console.WriteLine("{0}: Find the vector, calculating Slau. Find vector |2X-3| length", TaskNumber.Task11);
            //var res11 = Chapter7Factory.PerformTask(TaskNumber.Task11);
            //Console.WriteLine("Vector:\n{0}\n", res11[0]);
            //Console.WriteLine("Slau solution:\n{0}\n", res11[1]);
            //Console.WriteLine("Result: {0}\n", res11[2]);

            var task711 = Tuple.Create(TaskNumber.Task11, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Find the vector, calculating Slau. Find vector |2X-3| length", TaskNumber.Task11);
                var res711 = Chapter7Factory.PerformTask(TaskNumber.Task11);
                sb.AppendFormat("\nVector:\n{0}\n", res711[0]);
                sb.AppendFormat("\nSlau solution:\n{0}\n", res711[1]);
                sb.AppendFormat("\nResult: {0}\n", res711[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 12
            ////12. Calculate angle between vectors
            //Console.WriteLine("{0}: Calculate angle between vectors", TaskNumber.Task12);
            //var res12 = Chapter7Factory.PerformTask(TaskNumber.Task12);
            //Console.WriteLine("Result: {0}\n", res12[0]);

            var task712 = Tuple.Create(TaskNumber.Task12, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Calculate angle between vectors", TaskNumber.Task12);
                var res712 = Chapter7Factory.PerformTask(TaskNumber.Task12);
                sb.AppendFormat("\nResult: {0}\n", res712[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 13
            ////13. Calculate E - X*~X
            //Console.WriteLine("{0}: E - X*~X", TaskNumber.Task13);
            //var res13 = Chapter7Factory.PerformTask(TaskNumber.Task13);
            //Console.WriteLine("Result:\n{0}\n", res13[0]);


            var task713 = Tuple.Create(TaskNumber.Task13, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: E - X*~X", TaskNumber.Task13);
                var res713 = Chapter7Factory.PerformTask(TaskNumber.Task13);
                sb.AppendFormat("\nResult:\n{0}\n", res713[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 14
            ////14. Solve Slau ~A * X = ~Y
            //Console.WriteLine("{0}: Solve Slau ~A * X = ~Y", TaskNumber.Task14);
            //var res14 = Chapter7Factory.PerformTask(TaskNumber.Task14);
            //Console.WriteLine("Result:\n{0}\n", res14[0]);

            var task714 = Tuple.Create(TaskNumber.Task14, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Solve Slau ~A * X = ~Y", TaskNumber.Task14);
                var res714 = Chapter7Factory.PerformTask(TaskNumber.Task14);
                sb.AppendFormat("\nResult:\n{0}\n", res714[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 15
            ////15. Solve Slau 2(~A)^2 * X = ~Y
            //Console.WriteLine("{0}: Solve Slau 2(~A)^2 * X = ~Y", TaskNumber.Task15);
            //var res15 = Chapter7Factory.PerformTask(TaskNumber.Task15);
            //Console.WriteLine("Result:\n{0}\n", res15[0]);

            var task715 = Tuple.Create(TaskNumber.Task15, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Solve Slau 2(~A)^2 * X = ~Y", TaskNumber.Task15);
                var res715 = Chapter7Factory.PerformTask(TaskNumber.Task15);
                sb.AppendFormat("\nResult:\n{0}\n", res715[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 16
            ////16. Calculate determinant C (= ~B * A)
            //Console.WriteLine("{0}: Calculate determinant C (= ~B * A)", TaskNumber.Task16);
            //var res16 = Chapter7Factory.PerformTask(TaskNumber.Task16);
            //Console.WriteLine("Result: {0}\n", res16[0]);

            var task716 = Tuple.Create(TaskNumber.Task16, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Calculate determinant C (= ~B * A)", TaskNumber.Task16);
                var res716 = Chapter7Factory.PerformTask(TaskNumber.Task16);
                sb.AppendFormat("\nResult: {0}\n", res716[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 17
            //// 17. C(n) - source, A(n,n) = C[i]*C[j], Bij = Aij / sum(Aii), |2E - AB|
            //Console.WriteLine("{0}: C(n) - source, A(n,n) = C[i]*C[j], Bij = Aij / sum(Aii), |2E - AB|", TaskNumber.Task17);
            //var res17 = Chapter7Factory.PerformTask(TaskNumber.Task17);
            //Console.WriteLine("Result: {0}\n", res17[0]);

            var task717 = Tuple.Create(TaskNumber.Task17, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: C(n) - source, A(n,n) = C[i]*C[j], Bij = Aij / sum(Aii), |2E - AB|", TaskNumber.Task17);
                var res717 = Chapter7Factory.PerformTask(TaskNumber.Task17);
                sb.AppendFormat("\nResult: {0}\n", res717[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 18
            ////18.  I^2 == E ?, Slau I X = [1 1 1]
            //Console.WriteLine("{0}: I^2 == E ?, Slau I X = [1 1 1]", TaskNumber.Task18);
            //var res18 = Chapter7Factory.PerformTask(TaskNumber.Task18);
            //Console.WriteLine("I^2 == E ?: {0}", res18[0]);
            //Console.WriteLine("Slau I X = [1 1 1]. Result:\n{0}\n", res18[1]);

            var task718 = Tuple.Create(TaskNumber.Task18, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: I^2 == E ?, Slau I X = [1 1 1]", TaskNumber.Task18);
                var res718 = Chapter7Factory.PerformTask(TaskNumber.Task18);
                sb.AppendFormat("\nI^2 == E ?: {0}", res718[0]);
                sb.AppendFormat("\nSlau I X = [1 1 1]. Result:\n{0}\n", res718[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 19
            //Console.WriteLine("{0}: ~A == A ?, !A - ?, A * !A == E ?", TaskNumber.Task19);
            //var res19 = Chapter7Factory.PerformTask(TaskNumber.Task19);
            //Console.WriteLine("A * !A == E ? Result: {0}\n", res19[0]);

            var task719 = Tuple.Create(TaskNumber.Task19, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: ~A == A ?, !A - ?, A * !A == E ?", TaskNumber.Task19);
                var res719 = Chapter7Factory.PerformTask(TaskNumber.Task19);
                sb.AppendFormat("\n~A == A ? Result: {0}\n", res719[0]);
                sb.AppendFormat("\n!A - ? Result:\n{0}\n", res719[1]);
                sb.AppendFormat("\nA * !A == E ? Result: {0}\n", res719[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 20
            //Console.WriteLine("{0}: Check full ortogonality properties for 2 matrixes", TaskNumber.Task20);
            //var res20 = Chapter7Factory.PerformTask(TaskNumber.Task20);
            //Console.WriteLine("Abs of matrix determinant is 1. For A: {0}. For B: {1}", res20[0], res20[1] );
            //Console.WriteLine("Sum of squared elements of any column is 1. For A: {0}. For B: {0}", res20[2], res20[3]);
            //Console.WriteLine("Sum of producted elements of two any columns is 1. For A: {0}. For B: {1}\n", res20[4], res20[5]);

            var task720 = Tuple.Create(TaskNumber.Task20, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Check full ortogonality properties for 2 matrixes", TaskNumber.Task20);
                var res720 = Chapter7Factory.PerformTask(TaskNumber.Task20);
                sb.AppendFormat("\nAbs of matrix determinant is 1. For A: {0}. For B: {1}", res720[0], res720[1]);
                sb.AppendFormat("\nSum of squared elements of any column is 1. For A: {0}. For B: {0}", res720[2], res720[3]);
                sb.AppendFormat("\nSum of producted elements of two any columns is 1. For A: {0}. For B: {1}\n", res720[4], res720[5]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 21
            //Console.WriteLine("{0}: Check whether the vectors form a basis", TaskNumber.Task21);
            //var res21 = Chapter7Factory.PerformTask(TaskNumber.Task21);
            //Console.WriteLine("Result:\n{0}\n", res21[0]);

            var task721 = Tuple.Create(TaskNumber.Task21, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Check whether the vectors form a basis", TaskNumber.Task21);
                var res721 = Chapter7Factory.PerformTask(TaskNumber.Task21);
                sb.AppendFormat("\nResult:\n{0}", res721[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 22
            //Console.WriteLine("{0}: Solve Slau. Check ortogonality conditions: C*(~C)==E ? and (~C)*C == E?", TaskNumber.Task22);
            //var res22 = Chapter7Factory.PerformTask(TaskNumber.Task22);
            //Console.WriteLine("C*(~C)==E : {0}\n(~C)*C == E : {1}\n", res22[0], res22[1]);

            var task722 = Tuple.Create(TaskNumber.Task22, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Solve Slau. Check ortogonality conditions: C*(~C)==E ? and (~C)*C == E?", TaskNumber.Task22);
                var res722 = Chapter7Factory.PerformTask(TaskNumber.Task22);
                sb.AppendFormat("\nC*(~C)==E : {0}\n(~C)*C == E : {1}\n", res722[0], res722[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 23
            //Console.WriteLine("{0}: Max of sum abs rows - ? Max of sum abs columns - ? Determinant - ?", TaskNumber.Task23);
            //var res23 = Chapter7Factory.PerformTask(TaskNumber.Task23);
            //Console.WriteLine("Max of sum abs rows: {0}", res23[0]);
            //Console.WriteLine("Max of sum abs columns: {0}", res23[1]);
            //Console.WriteLine("Determinant: {0}\n", res23[2]);

            var task723 = Tuple.Create(TaskNumber.Task23, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Max of sum abs rows - ? Max of sum abs columns - ? Determinant - ?", TaskNumber.Task23);
                var res723 = Chapter7Factory.PerformTask(TaskNumber.Task23);
                sb.AppendFormat("\nMax of sum abs rows: {0}", res723[0]);
                sb.AppendFormat("\nMax of sum abs columns: {0}", res723[1]);
                sb.AppendFormat("\nDeterminant: {0}", res723[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 24
            //Console.WriteLine("{0}: Sqrt from sum of squared elements of matrix", TaskNumber.Task24);
            //var res24 = Chapter7Factory.PerformTask(TaskNumber.Task24);
            //Console.WriteLine("Result: {0}\n", res24[0]);


            var task724 = Tuple.Create(TaskNumber.Task24, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Sqrt from sum of squared elements of matrix", TaskNumber.Task24);
                var res724 = Chapter7Factory.PerformTask(TaskNumber.Task24);
                sb.AppendFormat("\nResult: {0}\n", res724[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 25
            //Console.WriteLine("{0}: Solve Slau by Gauss method", TaskNumber.Task25);
            //var res25 = Chapter7Factory.PerformTask(TaskNumber.Task25);
            //Console.WriteLine("Result:\n{0}", res25[0]);
            //Console.WriteLine("Check result A*X:\n{0}", res25[1]);

            var task725 = Tuple.Create(TaskNumber.Task25, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Solve Slau by Gauss method", TaskNumber.Task25);
                var res725 = Chapter7Factory.PerformTask(TaskNumber.Task25);

                sb.AppendFormat("\nResult:\n{0}", res725[0]);
                sb.AppendFormat("\nCheck result A*X:\n{0}", res725[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion
            #endregion


            #region Chapter 8

            #region 1

            var task801 = Tuple.Create(TaskNumber.Task1, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n\nC H A P T E R 8\n");
                sb.AppendFormat("\n{0}: Even array - ? Odd array - ? Max even - ? Min odd - ?", TaskNumber.Task1);
                var res801 = Chapter8Factory.PerformTask(TaskNumber.Task1);
                sb.AppendFormat("\nEven array - {0} elements, odd - {1}\nMax even element - {2}, min odd - {3}", res801[0], res801[1], res801[2], res801[3]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 2

            var task802 = Tuple.Create(TaskNumber.Task2, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Array of doubled odd numbers", TaskNumber.Task2);
                var res802 = Chapter8Factory.PerformTask(TaskNumber.Task2);
                sb.AppendFormat("\nCount of doubled odd numbers: {0}", res802[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 3

            var task803 = Tuple.Create(TaskNumber.Task3, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Array of doubled odd numbers", TaskNumber.Task3);
                var res803 = Chapter8Factory.PerformTask(TaskNumber.Task3);
                sb.AppendFormat("\nCount of doubled odd numbers: {0}", res803[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 4

            var task804 = Tuple.Create(TaskNumber.Task4, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Positive and negative simple elelements count - ? Zero elements count - ?", TaskNumber.Task4);
                var res804 = Chapter8Factory.PerformTask(TaskNumber.Task4);
                sb.AppendFormat("\nPositive simple count: {0}\nNegative count: {1}\nZero simple count: {2}", res804[0], res804[1], res804[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 5

            var task805 = Tuple.Create(TaskNumber.Task5, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Not simple elements before min - ?", TaskNumber.Task5);
                var res805 = Chapter8Factory.PerformTask(TaskNumber.Task5);
                sb.AppendFormat("\nResult (count): {0}", res805[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 6

            var task806 = Tuple.Create(TaskNumber.Task6, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Not zero elements after source max - ?", TaskNumber.Task6);
                var res806 = Chapter8Factory.PerformTask(TaskNumber.Task6);
                sb.AppendFormat("\nResult (count):{0}", res806[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 7

            var task807 = Tuple.Create(TaskNumber.Task7, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Elements bigger than average positive values - ?", TaskNumber.Task7);
                var res807 = Chapter8Factory.PerformTask(TaskNumber.Task7);
                sb.AppendFormat("\nResult (count):{0}", res807[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 8

            var task808 = Tuple.Create(TaskNumber.Task8, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Elements before min and after max", TaskNumber.Task8);
                var res808 = Chapter8Factory.PerformTask(TaskNumber.Task8);
                sb.AppendFormat("\nResult (count):{0}", res808[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 9

            var task809 = Tuple.Create(TaskNumber.Task9, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Elements between min and max", TaskNumber.Task9);
                var res809 = Chapter8Factory.PerformTask(TaskNumber.Task9);
                sb.AppendFormat("\nResult (count):{0}", res809[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 10

            var task810 = Tuple.Create(TaskNumber.Task10, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Group items by parity: even, odd then - ?", TaskNumber.Task10);
                var res810 = Chapter8Factory.PerformTask(TaskNumber.Task10);
                sb.AppendFormat("\nResult (count):{0}", res810[0]);
                sb.AppendFormat("\nMax odd index: {0}\nMin even index: {1}", res810[1], res810[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 11

            var task811 = Tuple.Create(TaskNumber.Task11, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Swap max negative and max simple values", TaskNumber.Task11);
                var res811 = Chapter8Factory.PerformTask(TaskNumber.Task11);
                sb.AppendFormat("\nBefore swap");
                sb.AppendFormat("\nMax negative value: {0}, max negative index: {1}", res811[0], res811[1]);
                sb.AppendFormat("\nMax simple value: {0}, max simple index: {1}", res811[2], res811[3]);
                sb.AppendFormat("\nAfter swap");
                sb.AppendFormat("\nMax negative value: {0}", res811[4]);
                sb.AppendFormat("\nMax simple value: {0}", res811[5]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 12

            var task812 = Tuple.Create(TaskNumber.Task12, new Func<object, string>(obj =>
             {
                 var stopWatch1 = Stopwatch.StartNew();

                 var sb = new StringBuilder();
                 sb.AppendFormat("\n{0}: Write into new file all numbers, bigger than average", TaskNumber.Task12);
                 var res812 = Chapter8Factory.PerformTask(TaskNumber.Task12);
                 sb.AppendFormat("\nResult (count): {0}", res812[0]);

                 stopWatch1.Stop();
                 sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                 return sb.ToString();
             }));

            #endregion

            #region 13

            var task813 = Tuple.Create(TaskNumber.Task13, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Average from simple numbers after min number", TaskNumber.Task13);
                var res813 = Chapter8Factory.PerformTask(TaskNumber.Task13);
                sb.AppendFormat("\nResult: {0}", res813[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 14

            var task814 = Tuple.Create(TaskNumber.Task14, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Swap first perfect and last negative values", TaskNumber.Task14);
                var res814 = Chapter8Factory.PerformTask(TaskNumber.Task14);
                sb.AppendFormat("\nBefore swap");
                sb.AppendFormat("\nFirst perfect value: {0}, first perfect index: {1}", res814[0], res814[1]);
                sb.AppendFormat("\nLast negative value: {0}, last negative index: {1}", res814[2], res814[3]);
                sb.AppendFormat("\nAfter swap");
                sb.AppendFormat("\nFirst perfect value: {0}", res814[4]);
                sb.AppendFormat("\nLast negative value: {0}", res814[5]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 15
            var task815 = Tuple.Create(TaskNumber.Task15, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Sort all simple numbers by descending", TaskNumber.Task15);
                var res815 = Chapter8Factory.PerformTask(TaskNumber.Task15);
                sb.AppendFormat("\nResult (count): {0}", res815[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 16

            var task816 = Tuple.Create(TaskNumber.Task16, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Last sequence of perfect numbers write to a text file", TaskNumber.Task16);
                var res816 = Chapter8Factory.PerformTask(TaskNumber.Task16);
                sb.AppendFormat("\nResult (count): {0}", res816[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 17
            var task817 = Tuple.Create(TaskNumber.Task17, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Negative numbers count", TaskNumber.Task17);
                var res817 = Chapter8Factory.PerformTask(TaskNumber.Task17);
                sb.AppendFormat("\nResult (count): {0}", res817[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 18

            var task818 = Tuple.Create(TaskNumber.Task18, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Arrays of simple and perfect values - ? Max simple and min perfect - ?", TaskNumber.Task18);
                var res818 = Chapter8Factory.PerformTask(TaskNumber.Task18);
                sb.AppendFormat("\nSimple (count): {0}, max: {1}", res818[0], res818[1]);
                sb.AppendFormat("\nPerfect (count): {0}, min: {1}", res818[2], res818[3]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 19

            var task819 = Tuple.Create(TaskNumber.Task19, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Simple numbers after max number - ?", TaskNumber.Task19);
                var res819 = Chapter8Factory.PerformTask(TaskNumber.Task19);
                sb.AppendFormat("\nResult (count): {0}", res819[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 20



            var task820 = Tuple.Create(TaskNumber.Task20, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Array with multiples of 3 values before min - ?", TaskNumber.Task20);
                var res820 = Chapter8Factory.PerformTask(TaskNumber.Task20);
                sb.AppendFormat("\nResult (count): {0}", res820[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 21

            var task821 = Tuple.Create(TaskNumber.Task21, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Numbers bigger than average of even numbers - ?", TaskNumber.Task21);
                var res821 = Chapter8Factory.PerformTask(TaskNumber.Task21);
                sb.AppendFormat("\nResult (count): {0}", res821[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 22

            var task822 = Tuple.Create(TaskNumber.Task22, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Swap last simple and min perfect numbers - ?", TaskNumber.Task22);
                var res822 = Chapter8Factory.PerformTask(TaskNumber.Task22);
                sb.AppendFormat("\nBefore swap");
                sb.AppendFormat("\nLast simple: {0}, min perfect: {1}", res822[0], res822[1]);
                sb.AppendFormat("\nAfter swap");
                sb.AppendFormat("\nLast simple: {0}, min perfect: {1}", res822[2], res822[3]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));


            #endregion

            #region 23
            var task823 = Tuple.Create(TaskNumber.Task23, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Sum of last negative sequence - ?", TaskNumber.Task23);
                var res823 = Chapter8Factory.PerformTask(TaskNumber.Task23);
                sb.AppendFormat("\nResult (sum): {0}", res823[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 24

            var task824 = Tuple.Create(TaskNumber.Task24, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Production of first perfect numbers sequence - ?", TaskNumber.Task24);
                var res824 = Chapter8Factory.PerformTask(TaskNumber.Task24);
                sb.AppendFormat("\nResult (production): {0}", res824[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 25
            var task825 = Tuple.Create(TaskNumber.Task25, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Substraction of simple numbers sum and max number - ?", TaskNumber.Task25);
                var res825 = Chapter8Factory.PerformTask(TaskNumber.Task25);
                sb.AppendFormat("\nResult (substraction): {0}", res825[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #endregion


            #region Chapter 9_1

            #region 1
            var task9101 = Tuple.Create(TaskNumber.Task1, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n\nC H A P T E R 9_1\n");
                sb.AppendFormat("\nSource string: {0}", Chapter91Factory.Input);

                sb.AppendFormat("\n{0}: Punctuation count - ?", TaskNumber.Task1);
                var res901 = Chapter91Factory.PerformTask(TaskNumber.Task1);
                sb.AppendFormat("\nResult - {0}", res901[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 2
            var task9102 = Tuple.Create(TaskNumber.Task2, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Point (.) and exclamation point (!) count - ?", TaskNumber.Task2);
                var res902 = Chapter91Factory.PerformTask(TaskNumber.Task2);
                sb.AppendFormat("\nResult - {0}", res902[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 3
            var task9103 = Tuple.Create(TaskNumber.Task3, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Delete all commas - ?", TaskNumber.Task3);
                var res901 = Chapter91Factory.PerformTask(TaskNumber.Task3);
                sb.AppendFormat("\nResult - {0}", res901[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 4
            var task9104 = Tuple.Create(TaskNumber.Task4, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Delete all spaces before punctuation - ?", TaskNumber.Task4);
                var res904 = Chapter91Factory.PerformTask(TaskNumber.Task4);
                sb.AppendFormat("\nResult - {0}", res904[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 5
            var task9105 = Tuple.Create(TaskNumber.Task5, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Insert number after each space - ?", TaskNumber.Task5);
                var res905 = Chapter91Factory.PerformTask(TaskNumber.Task5);
                sb.AppendFormat("\nResult - {0}", res905[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 6
            var task9106 = Tuple.Create(TaskNumber.Task6, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Insert number before each exclamation point (!) - ?", TaskNumber.Task6);
                var res906 = Chapter91Factory.PerformTask(TaskNumber.Task6);
                sb.AppendFormat("\nResult - {0}", res906[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 7
            var task9107 = Tuple.Create(TaskNumber.Task7, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Find sum of numbers in string - ?", TaskNumber.Task7);
                var res907 = Chapter91Factory.PerformTask(TaskNumber.Task7);
                sb.AppendFormat("\nResult - {0}", res907[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 8

            var task9108 = Tuple.Create(TaskNumber.Task8, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Remove all numbers from string - ?", TaskNumber.Task8);
                var res908 = Chapter91Factory.PerformTask(TaskNumber.Task8);
                sb.AppendFormat("\nResult - {0}", res908[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 9

            var task9109 = Tuple.Create(TaskNumber.Task9, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Find sum of simple numbers in string - ?", TaskNumber.Task9);
                var res909 = Chapter91Factory.PerformTask(TaskNumber.Task9);
                sb.AppendFormat("\nResult - {0}", res909[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 10
            var task9110 = Tuple.Create(TaskNumber.Task10, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Remove a word with max length - ?", TaskNumber.Task10);
                var res910 = Chapter91Factory.PerformTask(TaskNumber.Task10);
                sb.AppendFormat("\nResult - {0}", res910[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 11

            var task9111 = Tuple.Create(TaskNumber.Task11, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Wheter simple numbers are present - ?", TaskNumber.Task11);
                var res911 = Chapter91Factory.PerformTask(TaskNumber.Task11);
                sb.AppendFormat("\nResult - {0}", res911[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 12

            var task9112 = Tuple.Create(TaskNumber.Task12, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Insert space after punctuations - ?", TaskNumber.Task12);
                var res912 = Chapter91Factory.PerformTask(TaskNumber.Task12);
                sb.AppendFormat("\nResult - {0}", res912[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 13

            var task9113 = Tuple.Create(TaskNumber.Task13, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Invert words in string - ?", TaskNumber.Task13);
                var res913 = Chapter91Factory.PerformTask(TaskNumber.Task13);
                sb.AppendFormat("\nResult - {0}", res913[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 14

            var task9114 = Tuple.Create(TaskNumber.Task14, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Smallest words count - ?", TaskNumber.Task14);
                var res914 = Chapter91Factory.PerformTask(TaskNumber.Task14);
                sb.AppendFormat("\nResult - {0}", res914[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 15

            var task9115 = Tuple.Create(TaskNumber.Task15, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Words that end with a vowel letter count - ?", TaskNumber.Task15);
                var res915 = Chapter91Factory.PerformTask(TaskNumber.Task15);
                sb.AppendFormat("\nResult - {0}", res915[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 16

            var task9116 = Tuple.Create(TaskNumber.Task16, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Words count in odd strings - ?", TaskNumber.Task16);
                var res916 = Chapter91Factory.PerformTask(TaskNumber.Task16);
                sb.AppendFormat("\nResult - {0}", res916[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 17

            var task9117 = Tuple.Create(TaskNumber.Task17, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Simple numbers count in the strings - ?", TaskNumber.Task17);
                var res917 = Chapter91Factory.PerformTask(TaskNumber.Task17);
                sb.AppendFormat("\nResult - {0}", res917[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 18

            var task9118 = Tuple.Create(TaskNumber.Task18, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Punctuations count in the even strings - ?", TaskNumber.Task18);
                var res918 = Chapter91Factory.PerformTask(TaskNumber.Task18);
                sb.AppendFormat("\nResult - {0}", res918[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 19

            var task9119 = Tuple.Create(TaskNumber.Task19, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Sentences count in all strings - ?", TaskNumber.Task19);
                var res919 = Chapter91Factory.PerformTask(TaskNumber.Task19);
                sb.AppendFormat("\nResult - {0}", res919[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 20

            var task9120 = Tuple.Create(TaskNumber.Task20, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Palindrom-words count in all strings - ?", TaskNumber.Task20);
                var res920 = Chapter91Factory.PerformTask(TaskNumber.Task20);
                sb.AppendFormat("\nResult - {0}", res920[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 21

            var task9121 = Tuple.Create(TaskNumber.Task21, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Delete Palindrom-numbers in 3rd and 7th strings - ?", TaskNumber.Task21);
                var res921 = Chapter91Factory.PerformTask(TaskNumber.Task21);
                sb.AppendFormat("\nResult - {0}", res921[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 22

            var task9122 = Tuple.Create(TaskNumber.Task22, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Display longest sentence - ?", TaskNumber.Task22);
                var res922 = Chapter91Factory.PerformTask(TaskNumber.Task22);
                sb.AppendFormat("\nResult - {0}", res922[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 23

            var task9123 = Tuple.Create(TaskNumber.Task23, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Display 1st and last sentences - ?", TaskNumber.Task23);
                var res923 = Chapter91Factory.PerformTask(TaskNumber.Task23);
                sb.AppendFormat("\nResult:\n{0}", res923[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 24

            var task9124 = Tuple.Create(TaskNumber.Task24, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Display all sentence in a reverse order - ?", TaskNumber.Task24);
                var res924 = Chapter91Factory.PerformTask(TaskNumber.Task24);
                sb.AppendFormat("\nResult:\n{0}", res924[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #region 25

            var task9125 = Tuple.Create(TaskNumber.Task25, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: String contains the highest amount of numbers - ?", TaskNumber.Task25);
                var res925 = Chapter91Factory.PerformTask(TaskNumber.Task25);
                var data = (Tuple<string, int>)res925[0];
                sb.AppendFormat("\nResult - {0}", data.Item1);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));

            #endregion

            #endregion


            #region Chapter 9_2

            #region 1
            var task9201 = Tuple.Create(TaskNumber.Task1, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n\nC H A P T E R 9_2\n");
               
                sb.AppendFormat("\n{0}: Average illness - ? Order info by ascending - ?", TaskNumber.Task1);
                var res901 = Chapter92Factory.PerformTask(TaskNumber.Task1);
                sb.AppendFormat("\nResult:\n{0}", res901[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 2
            var task9202 = Tuple.Create(TaskNumber.Task2, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Minimal illness - ? Order info by ascending - ?", TaskNumber.Task2);
                var res902 = Chapter92Factory.PerformTask(TaskNumber.Task2);
                sb.AppendFormat("\nResult:\n{0}", res902[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 3
            var task9203 = Tuple.Create(TaskNumber.Task3, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Average population growing - ? Order info by alphabet ascending - ?", TaskNumber.Task3);
                var res903 = Chapter92Factory.PerformTask(TaskNumber.Task3);
                sb.AppendFormat("\nResult:\n{0}", res903[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 4
            var task9204 = Tuple.Create(TaskNumber.Task4, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Average population growing - ? Order population by descending - ?", TaskNumber.Task4);
                var res904 = Chapter92Factory.PerformTask(TaskNumber.Task4);
                sb.AppendFormat("\nResult:\n{0}", res904[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 5
            var task9205 = Tuple.Create(TaskNumber.Task5, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Average graduation - ? Delete students info with average score less than 3.5 - ?", TaskNumber.Task5);
                var res905 = Chapter92Factory.PerformTask(TaskNumber.Task5);
                sb.AppendFormat("\nResult:\n{0}", res905[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 6
            var task9206 = Tuple.Create(TaskNumber.Task6, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Order last names in alphabet order - ?", TaskNumber.Task6);
                var res906 = Chapter92Factory.PerformTask(TaskNumber.Task6);
                sb.AppendFormat("\nResult:\n{0}", res906[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 7
            var task9207 = Tuple.Create(TaskNumber.Task7, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Order banks names in alphabet order with credit counts - ?", TaskNumber.Task7);
                var res907 = Chapter92Factory.PerformTask(TaskNumber.Task7);
                sb.AppendFormat("\nResult:\n{0}", res907[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 8
            var task9208 = Tuple.Create(TaskNumber.Task8, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Order banks names in alphabet order with credit counts > 1000 - ?", TaskNumber.Task8);
                var res908 = Chapter92Factory.PerformTask(TaskNumber.Task8);
                sb.AppendFormat("\nResult:\n{0}", res908[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 9
            var task9209 = Tuple.Create(TaskNumber.Task9, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Max journeys count - ?", TaskNumber.Task9);
                var res909 = Chapter92Factory.PerformTask(TaskNumber.Task9);
                sb.AppendFormat("\nResult:\n{0}", res909[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 10
            var task9210 = Tuple.Create(TaskNumber.Task10, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Average journeys count - ?", TaskNumber.Task10);
                var res910 = Chapter92Factory.PerformTask(TaskNumber.Task10);
                sb.AppendFormat("\nResult:\n{0}", res910[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 11
            var task9211 = Tuple.Create(TaskNumber.Task11, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Total - ? Count of incomings - ? Count of consumptions - ?", TaskNumber.Task11);
                var res911 = Chapter92Factory.PerformTask(TaskNumber.Task11)[0] as Tuple<List<Client>, double, int, int>;
                sb.AppendFormat("\nResult:\nTotal: {0}\nIncomings: {1}\nConsumptions: {2}", res911.Item2, res911.Item3, res911.Item4);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 12
            var task9212 = Tuple.Create(TaskNumber.Task12, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Three first max mining - ?", TaskNumber.Task12);
                var res912 = Chapter92Factory.PerformTask(TaskNumber.Task12);
                sb.AppendFormat("\nResult:\n{0}", res912[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 13
            var task9213 = Tuple.Create(TaskNumber.Task13, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Total mining sum - ?", TaskNumber.Task13);
                var res913 = Chapter92Factory.PerformTask(TaskNumber.Task13);
                sb.AppendFormat("\nResult:\n{0}", res913[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 14
            var task9214 = Tuple.Create(TaskNumber.Task14, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Employees: dirty money - ?", TaskNumber.Task14);
                var res914 = Chapter92Factory.PerformTask(TaskNumber.Task14);
                sb.AppendFormat("\nResult:\n{0}", res914[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 15
            var task9215 = Tuple.Create(TaskNumber.Task15, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Employees: Count of pensioners, young professionals - ?", TaskNumber.Task15);
                var res915 = Chapter92Factory.PerformTask(TaskNumber.Task15);
                sb.AppendFormat("\nResult:\nSorted data:\n{0}\nCount: {1}", res915[0], res915[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 16
            var task9216 = Tuple.Create(TaskNumber.Task16, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Employees: count of pensioners men and women - ?", TaskNumber.Task16);
                var res916 = Chapter92Factory.PerformTask(TaskNumber.Task16);
                sb.AppendFormat("\nResult:\n{0}", res916[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 17
            var task9217 = Tuple.Create(TaskNumber.Task17, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Employees: count engineers-pensioners - ?", TaskNumber.Task17);
                var res917 = Chapter92Factory.PerformTask(TaskNumber.Task17);
                sb.AppendFormat("\nResult:\n{0}", res917[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 18
            var task9218 = Tuple.Create(TaskNumber.Task18, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Scientists: young count with Ph.D degree - ? Below age 40 without Ph.D degree - ?", TaskNumber.Task18);
                var res918 = Chapter92Factory.PerformTask(TaskNumber.Task18);
                sb.AppendFormat("\nResult:\nCount: {0}\nBelow age 40 without Ph.D degree:\n{1}", res918[0], res918[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 19
            var task9219 = Tuple.Create(TaskNumber.Task19, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Employees: Income Tax and To Pay Off-? Count with minimal salary-? Sort data by position-?", TaskNumber.Task19);
                var res919 = Chapter92Factory.PerformTask(TaskNumber.Task19);
                sb.AppendFormat("\nResult:\nIncome Tax and To Pay Off:\n{0}\nCount with minimal salary: {1}\nSort data by position:\n{2}\n", res919[0], res919[1], res919[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 20
            var task9220 = Tuple.Create(TaskNumber.Task20, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Employees: To payoff - ? Count with max salary - ? Sort data by last name - ?", TaskNumber.Task20);
                var res920 = Chapter92Factory.PerformTask(TaskNumber.Task20);
                sb.AppendFormat("\nResult:\nTo payoff:\n{0}\nCount with max salary: {1},\nSort by last name:\n{2}", res920[0], res920[1], res920[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 21
            var task9221 = Tuple.Create(TaskNumber.Task21, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Tea: Total count - ? Total sum - ? Order by descending of sum", TaskNumber.Task21);
                var res921 = Chapter92Factory.PerformTask(TaskNumber.Task21);
                sb.AppendFormat("\nResult:\nTotal count: {0}\nTotal sum: {1}\nOrdered by descending of sum:\n{2}\n", res921[0], res921[1], res921[2]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 22
            var task9222 = Tuple.Create(TaskNumber.Task22, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Tea: Order by type (sort) - ?", TaskNumber.Task22);
                var res922 = Chapter92Factory.PerformTask(TaskNumber.Task22);
                sb.AppendFormat("\nResult:\n{0}", res922[0]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 23
            var task9223 = Tuple.Create(TaskNumber.Task23, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Tea: Sort by manufacturer name - ? Display manufacturer name with max sales - ?", TaskNumber.Task23);
                var res923 = Chapter92Factory.PerformTask(TaskNumber.Task23);
                sb.AppendFormat("\nResult:\nSorted:\n{0}\nMax sales:\n{1}", res923[0], res923[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 24
            var task9224 = Tuple.Create(TaskNumber.Task24, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Tea: Order by type and wrapper - ? Display wrapper with max sales sum - ?", TaskNumber.Task24);
                var res924 = Chapter92Factory.PerformTask(TaskNumber.Task24);
                sb.AppendFormat("\nResult:\nOredered by type and wrapping:\n{0}\nWrapper with max sales sum: {1}", res924[0], res924[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #region 25
            var task9225 = Tuple.Create(TaskNumber.Task25, new Func<object, string>(obj =>
            {
                var stopWatch1 = Stopwatch.StartNew();

                var sb = new StringBuilder();
                sb.AppendFormat("\n{0}: Tea: Order by saled tea count - ? Calculate total sum - ?", TaskNumber.Task25);
                var res925 = Chapter92Factory.PerformTask(TaskNumber.Task25);
                sb.AppendFormat("\nResult:\nOrdered:\n{0}\nTotal sum: {1}", res925[0], res925[1]);

                stopWatch1.Stop();
                sb.AppendFormat("\n" + stopWatch1.Elapsed.TotalSeconds + "seconds");

                return sb.ToString();
            }));
            #endregion

            #endregion

          

            var tasks = new[] {

                task701, task702, task703, task704, task705, task706, task707, task708, task709, task710, task711, task712, task713, task714, task715, task716, task717, task718, task719, task720, task721, task722, task723, task724, task725,
                task801, task802, task803, task804, task805, task806, task807, task808, task809, task810, task811, task812, task813, task814, task815, task816, task817, task818, task819, task820, task821, task822, task823, task824, task825,
                task9101, task9102, task9103, task9104, task9105, task9106, task9107, task9108, task9109, task9110, task9111, task9112, task9113, task9114, task9115, task9116, task9117, task9118, task9119, task9120, task9121, task9122, task9123, task9124, task9125,
                task9201, task9202, task9203, task9204, task9205, task9206, task9207, task9208, task9209, task9210, task9211, task9212, task9213, task9214, task9215, task9216, task9217, task9218, task9219, task9220, task9221, task9222, task9223, task9224, task9225

            }.ToList();

            var bag = new List<string>(tasks.Count);
            for (var i = 0; i < tasks.Count; i++)
                bag.Add(null);

            var syncRoot = new object();
            var elemsTotal = tasks.Count;
            var stopWatch = Stopwatch.StartNew();
            Parallel.For((long)0, elemsTotal, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount * 2 }, i =>
             {
                 var index = (int)i;
                 var item = tasks[index];
                 var result = item.Item2(null);
                 lock (syncRoot)
                 {
                     bag[index] = result;
                     if (bag.Where((x, j) => j < i).All(x => !string.IsNullOrEmpty(x)))
                         for (var j = index; j < elemsTotal; j++)
                             if (!string.IsNullOrEmpty(bag[j]))
                             {
                                 Console.WriteLine(bag[j]);
                             }
                             else
                             {
                                 break;
                             }
                 }
             });
            stopWatch.Stop();
            Console.WriteLine("\nTotal: " + stopWatch.Elapsed.TotalSeconds + "seconds");

            //Console.ReadKey();
            //Structures<object> s = new Structures<object>();

            Console.ReadLine();
        }
    }
}
