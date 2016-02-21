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

namespace Chapters
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //#region Chapter 7
            //#region 1
            ////1. C = 2(А + !В) - A*B
            //Console.WriteLine("{0}: create: 2nd matrix from the 1st, 3rd matrix from the 1st and 2nd",TaskNumber.Task1);
            //var res1 = Chapter7Factory.PerformTask(TaskNumber.Task1);
            //Console.WriteLine("1st matrix:\n{0}\n2nd matrix:\n{1}\n3rd matrix:\n{2}\n", res1[0], res1[1], res1[2]);
            //#endregion

            //#region 2
            //// 2. C(n) - source, A(n,n) = C[i]*C[j], B = A / max(A)
            //// Х(А + Е) = 3В - Е;
            //Console.WriteLine("{0}: create: 1st matrix A from array, 2nd matrix B from the 1st. Solve the matrix equation Х(А + Е) = 3В - Е", TaskNumber.Task2);
            //var res2 = Chapter7Factory.PerformTask(TaskNumber.Task2);
            //Console.WriteLine("1st matrix:\n{0}\n2nd matrix:\n{1}\nAnswer for equation\n{2}\n", res2[0], res2[1], res2[2]);
            //#endregion

            //#region 3
            ////3. C(n), D(n) - source, A(n,n) = C[i]*D[j], B = A / min(A)
            //// (2A - E) X = B + E; X =  (_2A-E)^-1 * _BE = (!_2AE) * _BE 
            //Console.WriteLine("{0}: create: 1st matrix A from array, 2nd matrix B from the 1st. Solve the matrix equation (2A - E) X = B + E", TaskNumber.Task3);
            //var res3 = Chapter7Factory.PerformTask(TaskNumber.Task3);
            //Console.WriteLine("1st matrix:\n{0}\n2nd matrix:\n{1}\nAnswer for equation:\n{2}\n", res3[0], res3[1], res3[2]);
            //#endregion

            //#region 4
            ////4. IsOrtogonal matrix? (At = !A)
            //Console.WriteLine("{0}: A4 is ortogonal?", TaskNumber.Task4);
            //var res4 = Chapter7Factory.PerformTask(TaskNumber.Task4);
            //Console.WriteLine("Result: {0}\n", res4[0] );
            //#endregion

            //#region 5
            ////5. IsOrtogonal matrix H = E - ( v*(~v) / determinant(v)^2 )  ?
            //Console.WriteLine("{0}: H = E - ( v*(~v) / determinant(v)^2 ) is ortogonal?", TaskNumber.Task5);
            //var res5 = Chapter7Factory.PerformTask(TaskNumber.Task5);
            //Console.WriteLine("Result: {0}\n", res5[0]);
            //#endregion

            //#region 6
            ////6. Are the source and source*source matrix equals?
            //Console.WriteLine("{0}: Check source == source*source ? source determinant - ?", TaskNumber.Task6);
            //var res6 = Chapter7Factory.PerformTask(TaskNumber.Task6);
            //Console.WriteLine("Determinant of source is {0}", res6[0]);
            //Console.WriteLine("source == source*source ? Result: {0}\n", res6[1]);
            //#endregion

            //#region 7
            ////7. 
            //Console.WriteLine("{0}: Check whether the vectors form a basis", TaskNumber.Task7);
            //var res7 = Chapter7Factory.PerformTask(TaskNumber.Task7);
            //Console.WriteLine("Result:\n{0}\n", res7[0]);
            //#endregion

            //#region 8
            ////8. Find X vector as solved equation system
            //Console.WriteLine("{0}: ", TaskNumber.Task8);
            //var res8 = Chapter7Factory.PerformTask(TaskNumber.Task8);
            //Console.WriteLine("Equation system solving is\n{0}\nit's vector length is {1}\n", res8[0], res8[1]);
            //#endregion

            //#region 9
            ////9. Calculate scalar vectors product 
            //Console.WriteLine("{0}: Calculate scalar vectors product", TaskNumber.Task9);
            //var res9 = Chapter7Factory.PerformTask(TaskNumber.Task9);
            //Console.WriteLine("Scalar product of X and Y vectors is {0}\n", res9[0]);
            //#endregion

            //#region 10
            ////10. Slau solution product it's transporation
            //Console.WriteLine("{0}: Slau solution product it's transporation", TaskNumber.Task10);
            //var res10 = Chapter7Factory.PerformTask(TaskNumber.Task10);
            //Console.WriteLine("Slau solution product it's transporation is\n{0}\n", res10[0]);
            //#endregion

            //#region 11
            ////11. Find the vector, calculating Slau. Find vector |2X-3| length
            //Console.WriteLine("{0}: Find the vector, calculating Slau. Find vector |2X-3| length", TaskNumber.Task11);
            //var res11 = Chapter7Factory.PerformTask(TaskNumber.Task11);
            //Console.WriteLine("Vector:\n{0}\n", res11[0]);
            //Console.WriteLine("Slau solution:\n{0}\n", res11[1]);
            //Console.WriteLine("Result: {0}\n", res11[2]);
            //#endregion

            //#region 12
            ////12. Calculate angle between vectors
            //Console.WriteLine("{0}: Calculate angle between vectors", TaskNumber.Task12);
            //var res12 = Chapter7Factory.PerformTask(TaskNumber.Task12);
            //Console.WriteLine("Result: {0}\n", res12[0]);
            //#endregion

            //#region 13
            ////13. Calculate E - X*~X
            //Console.WriteLine("{0}: E - X*~X", TaskNumber.Task13);
            //var res13 = Chapter7Factory.PerformTask(TaskNumber.Task13);
            //Console.WriteLine("Result:\n{0}\n", res13[0]);
            //#endregion

            //#region 14
            ////14. Solve Slau ~A * X = ~Y
            //Console.WriteLine("{0}: Solve Slau ~A * X = ~Y", TaskNumber.Task14);
            //var res14 = Chapter7Factory.PerformTask(TaskNumber.Task14);
            //Console.WriteLine("Result:\n{0}\n", res14[0]);
            //#endregion

            //#region 15
            ////15. Solve Slau 2(~A)^2 * X = ~Y
            //Console.WriteLine("{0}: Solve Slau 2(~A)^2 * X = ~Y", TaskNumber.Task15);
            //var res15 = Chapter7Factory.PerformTask(TaskNumber.Task15);
            //Console.WriteLine("Result:\n{0}\n", res15[0]);
            //#endregion

            //#region 16
            ////16. Calculate determinant C (= ~B * A)
            //Console.WriteLine("{0}: Calculate determinant C (= ~B * A)", TaskNumber.Task16);
            //var res16 = Chapter7Factory.PerformTask(TaskNumber.Task16);
            //Console.WriteLine("Result: {0}\n", res16[0]);

            //#endregion

            //#region 17
            //// 17. C(n) - source, A(n,n) = C[i]*C[j], Bij = Aij / sum(Aii), |2E - AB|
            //Console.WriteLine("{0}: C(n) - source, A(n,n) = C[i]*C[j], Bij = Aij / sum(Aii), |2E - AB|", TaskNumber.Task17);
            //var res17 = Chapter7Factory.PerformTask(TaskNumber.Task17);
            //Console.WriteLine("Result: {0}\n", res17[0]);
            //#endregion

            //#region 18
            ////18.  I^2 == E ?, Slau I X = [1 1 1]
            //Console.WriteLine("{0}: I^2 == E ?, Slau I X = [1 1 1]", TaskNumber.Task18);
            //var res18 = Chapter7Factory.PerformTask(TaskNumber.Task18);
            //Console.WriteLine("I^2 == E ?: {0}", res18[0]);
            //Console.WriteLine("Slau I X = [1 1 1]. Result:\n{0}\n", res18[1]);
            //#endregion

            //#region 19
            //Console.WriteLine("{0}: ~A == A ?, !A - ?, A * !A == E ?", TaskNumber.Task19);
            //var res19 = Chapter7Factory.PerformTask(TaskNumber.Task19);
            //Console.WriteLine("A * !A == E ? Result: {0}\n", res19[0]);
            //#endregion

            //#region 20
            //Console.WriteLine("{0}: Check full ortogonality properties for 2 matrixes", TaskNumber.Task20);
            //var res20 = Chapter7Factory.PerformTask(TaskNumber.Task20);
            //Console.WriteLine("Abs of matrix determinant is 1. For A: {0}. For B: {1}", res20[0], res20[1] );
            //Console.WriteLine("Sum of squared elements of any column is 1. For A: {0}. For B: {0}", res20[2], res20[3]);
            //Console.WriteLine("Sum of producted elements of two any columns is 1. For A: {0}. For B: {1}\n", res20[4], res20[5]);
            //#endregion

            //#region 21
            //Console.WriteLine("{0}: Check whether the vectors form a basis", TaskNumber.Task21);
            //var res21 = Chapter7Factory.PerformTask(TaskNumber.Task21);
            //Console.WriteLine("Result:\n{0}\n", res21[0]);
            //#endregion

            //#region 22
            //Console.WriteLine("{0}: Solve Slau. Check ortogonality conditions: C*(~C)==E ? and (~C)*C == E?", TaskNumber.Task22);
            //var res22 = Chapter7Factory.PerformTask(TaskNumber.Task22);
            //Console.WriteLine("C*(~C)==E : {0}\n(~C)*C == E : {1}\n", res22[0], res22[1]);
            //#endregion

            //#region 23
            //Console.WriteLine("{0}: Max of sum abs rows - ? Max of sum abs columns - ? Determinant - ?", TaskNumber.Task23);
            //var res23 = Chapter7Factory.PerformTask(TaskNumber.Task23);
            //Console.WriteLine("Max of sum abs rows: {0}", res23[0]);
            //Console.WriteLine("Max of sum abs columns: {0}", res23[1]);
            //Console.WriteLine("Determinant: {0}\n", res23[2]);
            //#endregion

            //#region 24
            //Console.WriteLine("{0}: Sqrt from sum of squared elements of matrix", TaskNumber.Task24);
            //var res24 = Chapter7Factory.PerformTask(TaskNumber.Task24);
            //Console.WriteLine("Result: {0}\n", res24[0]);
            //#endregion

            //#region 25
            //Console.WriteLine("{0}: Solve Slau by Gauss method", TaskNumber.Task25);
            //var res25 = Chapter7Factory.PerformTask(TaskNumber.Task25);
            //Console.WriteLine("Result:\n{0}", res25[0]);
            //Console.WriteLine("Check result A*X:\n{0}", res25[1]);
            //#endregion
            //#endregion

            
            #region Chapter 8
            
            #region 1
           
            var task1 = Tuple.Create(TaskNumber.Task1, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Even array - ? Odd array - ? Max even - ? Min odd - ?", TaskNumber.Task1);
                var res81 = Chapter8Factory.PerformTask(TaskNumber.Task1);
                sb.AppendFormat("\nEven array - {0} elements, odd - {1}\nMax even element - {2}, min odd - {3}", res81[0], res81[1], res81[2], res81[3]);

                return sb.ToString();
            }));


            #endregion

            #region 2
            
            var task2 = Tuple.Create(TaskNumber.Task2, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Array of doubled odd numbers", TaskNumber.Task2);
                var res82 = Chapter8Factory.PerformTask(TaskNumber.Task2);
                sb.AppendFormat("\nCount of doubled odd numbers: {0}", res82[0]);
                
                return sb.ToString();
            }));
            
            #endregion

            #region 3

            var task3 = Tuple.Create(TaskNumber.Task3, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Array of doubled odd numbers", TaskNumber.Task3);
                var res83 = Chapter8Factory.PerformTask(TaskNumber.Task3);
                sb.AppendFormat("\nCount of doubled odd numbers: {0}", res83[0]);
                
                return sb.ToString();
            }));

            #endregion

            #region 4

            var task4 = Tuple.Create(TaskNumber.Task4, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Positive and negative simple elelements count - ? Zero elements count - ?", TaskNumber.Task4);
                var res84 = Chapter8Factory.PerformTask(TaskNumber.Task4);
                sb.AppendFormat("\nPositive simple count: {0}\nNegative count: {1}\nZero simple count: {2}", res84[0], res84[1], res84[2]);

                return sb.ToString();
            }));

            #endregion

            #region 5

            var task5 = Tuple.Create(TaskNumber.Task5, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Not simple elements before min - ?", TaskNumber.Task5);
                var res85 = Chapter8Factory.PerformTask(TaskNumber.Task5);
                sb.AppendFormat("\nResult (count): {0}", res85[0]);

                return sb.ToString();
            }));

            #endregion

            #region 6

            var task6 = Tuple.Create(TaskNumber.Task6, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Not zero elements after source max - ?", TaskNumber.Task6);
                var res86 = Chapter8Factory.PerformTask(TaskNumber.Task6);
                sb.AppendFormat("\nResult (count):{0}", res86[0]);

                return sb.ToString();
            }));

            #endregion

            #region 7

            var task7 = Tuple.Create(TaskNumber.Task7, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Elements bigger than average positive values - ?", TaskNumber.Task7);
                var res87 = Chapter8Factory.PerformTask(TaskNumber.Task7);
                sb.AppendFormat("\nResult (count):{0}", res87[0]);
                
                return sb.ToString();
            }));

            #endregion

            #region 8

            var task8 = Tuple.Create(TaskNumber.Task8, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Elements before min and after max", TaskNumber.Task8);
                var res88 = Chapter8Factory.PerformTask(TaskNumber.Task8);
                sb.AppendFormat("\nResult (count):{0}", res88[0]);
               
                return sb.ToString();
            }));


            #endregion

            #region 9

            var task9 = Tuple.Create(TaskNumber.Task9, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Elements between min and max", TaskNumber.Task9);
                var res89 = Chapter8Factory.PerformTask(TaskNumber.Task9);
                sb.AppendFormat("\nResult (count):{0}", res89[0]);
                
                return sb.ToString();
            }));

            #endregion

            #region 10

            var task10 = Tuple.Create(TaskNumber.Task10, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Group items by parity: even, odd then - ?", TaskNumber.Task10);
                var res810 = Chapter8Factory.PerformTask(TaskNumber.Task10);
                sb.AppendFormat("\nResult (count):{0}", res810[0]);
                sb.AppendFormat("\nMax odd index: {0}\nMin even index: {1}", res810[1], res810[2]);
                
                return sb.ToString();
            }));



            
            #endregion

            #region 11

            var task11 = Tuple.Create(TaskNumber.Task11, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Swap max negative and max simple values", TaskNumber.Task11);
                var res811 = Chapter8Factory.PerformTask(TaskNumber.Task11);

                sb.AppendFormat("\nBefore swap");
                sb.AppendFormat("\nMax negative value: {0}, max negative index: {1}", res811[0], res811[1]);
                sb.AppendFormat("\nMax simple value: {0}, max simple index: {1}", res811[2], res811[3]);
                sb.AppendFormat("\nAfter swap");
                sb.AppendFormat("\nMax negative value: {0}", res811[4]);
                sb.AppendFormat("\nMax simple value: {0}", res811[5]);

                return sb.ToString();
            }));

            #endregion

            #region 12

            var task12 = Tuple.Create(TaskNumber.Task12, new Func<object,string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Write into new file all numbers, bigger than average", TaskNumber.Task12);
                var res812 = Chapter8Factory.PerformTask(TaskNumber.Task12);
                sb.AppendFormat("\nResult (count): {0}", res812[0]);

                return sb.ToString();
            }));

            #endregion

            #region 13

            var task13 = Tuple.Create(TaskNumber.Task13, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Average from simple numbers after min number", TaskNumber.Task13);
                var res813 = Chapter8Factory.PerformTask(TaskNumber.Task13);
                sb.AppendFormat("\nResult: {0}", res813[0]);

                return sb.ToString();
            }));

            #endregion

            #region 14

            var task14 = Tuple.Create(TaskNumber.Task14, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Swap first perfect and last negative values", TaskNumber.Task14);
                var res814 = Chapter8Factory.PerformTask(TaskNumber.Task14);

                sb.AppendFormat("\nBefore swap");
                sb.AppendFormat("\nFirst perfect value: {0}, first perfect index: {1}", res814[0], res814[1]);
                sb.AppendFormat("\nLast negative value: {0}, last negative index: {1}", res814[2], res814[3]);
                sb.AppendFormat("\nAfter swap");
                sb.AppendFormat("\nFirst perfect value: {0}", res814[4]);
                sb.AppendFormat("\nLast negative value: {0}", res814[5]);
                
                return sb.ToString();
            }));


            #endregion

            #region 15
            var task15 = Tuple.Create(TaskNumber.Task15, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Sort all simple numbers by descending", TaskNumber.Task15);
                var res815 = Chapter8Factory.PerformTask(TaskNumber.Task15);
                sb.AppendFormat("\nResult (count): {0}", res815[0]);

                return sb.ToString();
            }));
            #endregion

            #region 16

            //Console.WriteLine("\n{0}: Last sequence of perfect numbers write to a text file", TaskNumber.Task16);
            //var res816 = Chapter8Factory.PerformTask(TaskNumber.Task16);
            //Console.WriteLine("\nResult (count): {0}", res816[0]);

            var task16 = Tuple.Create(TaskNumber.Task16, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Last sequence of perfect numbers write to a text file", TaskNumber.Task16);
                var res816 = Chapter8Factory.PerformTask(TaskNumber.Task16);
                sb.AppendFormat("\nResult (count): {0}", res816[0]);

                return sb.ToString();
            }));
            #endregion

            #region 17
            var task17 = Tuple.Create(TaskNumber.Task17, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Negative numbers count", TaskNumber.Task17);
                var res817 = Chapter8Factory.PerformTask(TaskNumber.Task17);
                sb.AppendFormat("\nResult (count): {0}", res817[0]);

                return sb.ToString();
            }));
            #endregion

            #region 18

            var task18 = Tuple.Create(TaskNumber.Task18, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Arrays of simple and perfect values - ? Max simple and min perfect - ?", TaskNumber.Task18);
                var res818 = Chapter8Factory.PerformTask(TaskNumber.Task18);
                sb.AppendFormat("\nSimple (count): {0}, max: {1}", res818[0], res818[1]);
                sb.AppendFormat("\nPerfect (count): {0}, min: {1}", res818[2], res818[3]);

                return sb.ToString();
            }));

            #endregion

            #region 19

            var task19 = Tuple.Create(TaskNumber.Task19, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Simple numbers after max number - ?", TaskNumber.Task19);
                var res819 = Chapter8Factory.PerformTask(TaskNumber.Task19);
                sb.AppendFormat("\nResult (count): {0}", res819[0]);

                return sb.ToString();
            }));

            #endregion

            #region 20

            //Console.WriteLine("\n{0}: Array with multiples of 3 values before min - ?", TaskNumber.Task20);
            //var res820 = Chapter8Factory.PerformTask(TaskNumber.Task20);
            //Console.WriteLine("\nResult (count): {0}", res820[0]);

            var task20 = Tuple.Create(TaskNumber.Task20, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Array with multiples of 3 values before min - ?", TaskNumber.Task20);
                var res820 = Chapter8Factory.PerformTask(TaskNumber.Task20);
                sb.AppendFormat("\nResult (count): {0}", res820[0]);

                return sb.ToString();
            }));

            #endregion

            #region 21

            var task21 = Tuple.Create(TaskNumber.Task21, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Numbers bigger than average of even numbers - ?", TaskNumber.Task21);
                var res821 = Chapter8Factory.PerformTask(TaskNumber.Task21);
                sb.AppendFormat("\nResult (count): {0}", res821[0]);

                return sb.ToString();
            }));

            #endregion

            #region 22

            var task22 = Tuple.Create(TaskNumber.Task22, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Swap last simple and min perfect numbers - ?", TaskNumber.Task22);
                var res822 = Chapter8Factory.PerformTask(TaskNumber.Task22);
                sb.AppendFormat("\nResult (count): {0}", res822[0]);

                return sb.ToString();
            }));


            #endregion

            #region 23
            var task23 = Tuple.Create(TaskNumber.Task23, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Sum of last negative sequence - ?", TaskNumber.Task23);
                var res823 = Chapter8Factory.PerformTask(TaskNumber.Task23);
                sb.AppendFormat("\nResult (sum): {0}", res823[0]);

                return sb.ToString();
            }));

            #endregion

            #region 24

            var task24 = Tuple.Create(TaskNumber.Task24, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Production of first perfect numbers sequence - ?", TaskNumber.Task24);
                var res824 = Chapter8Factory.PerformTask(TaskNumber.Task24);
                sb.AppendFormat("\nResult (production): {0}", res824[0]);

                return sb.ToString();
            }));

            #endregion

            #region 25
            var task25 = Tuple.Create(TaskNumber.Task25, new Func<object, string>(obj =>
            {
                var sb = new StringBuilder();

                sb.AppendFormat("\n{0}: Substraction of simple numbers sum and max number - ?", TaskNumber.Task25);
                var res825 = Chapter8Factory.PerformTask(TaskNumber.Task25);
                sb.AppendFormat("\nResult (substraction): {0}", res825[0]);

                return sb.ToString();
            }));

            #endregion


            #endregion

            var tasks = new[] { task1, task2, task3, task4, task5, task6, task7, task8, task9, task10, task11, task12, task13, task14, task15, task16, task17, task18, task19, task20, task21, task22, task23, task24, task25}.ToList();

            var bag = new List<string>(tasks.Count);
            for (var i = 0; i < tasks.Count; i++)
                bag.Add(null);

            var syncRoot = new object();
            var elemsTotal = tasks.Count;
            var stopWatch = Stopwatch.StartNew();
            Parallel.For((long) 0, elemsTotal, new ParallelOptions() {MaxDegreeOfParallelism = Environment.ProcessorCount*2} , i =>
            {
                var index = (int) i;
                var item = tasks[index];
                var result = item.Item2(null);
                lock (syncRoot)
                {
                    bag[index] = result;
                    if (bag.Where((x, j) => j < i).All(x => !string.IsNullOrEmpty(x)))
                        for(var j = index; j < elemsTotal; j++)
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
            Console.WriteLine(stopWatch.Elapsed.TotalSeconds + "seconds");

            Console.ReadKey();
        }
    }
}
