using System;

namespace Chapters
{
    public class Chapter7Factory
    {
        public static object[] PerformTask(TaskNumber number)
        {
            switch (number)
            {
                case TaskNumber.Task1:
                    var aSource = new[,] { { 2, 4, 3 }, { 1.0, 3, 4 }, { 7, 4, 5 } };
                    var A = Matrix.Create(Chapter7TaskType.FromMatrix, aSource);
                    var B = Matrix.Create(Chapter7TaskType.One, aSource);
                    var C = 2 * (A + (!B)) - (~A) * B;
                    return new object[] {A, B, C};

                case TaskNumber.Task2:
                    var A2 = Matrix.Create(Chapter7TaskType.Two, new[] { 1.0, 2, 3 });
                    var B2 = A2.MatrixDevideMaxOrMinElement(true);
                    var AE = A2 + Matrix.Create(Chapter7TaskType.EGen, A2.Rows);
                    var _3B_E = 3 * B2 - Matrix.Create(Chapter7TaskType.EGen, B2.Rows);
                    // X * AE = _3B_E   =>  X = B * A^-1;
                    var X2 = _3B_E * (!AE);
                    return new object[] {A2,B2,X2};

                case TaskNumber.Task3:
                    var A3 = Matrix.Create(Chapter7TaskType.Three, Tuple.Create(new[] { 1.0, 2.0, 3.0 }, new[] { 4.0, 5.0, 6.0 }));
                    var B3 = A3.MatrixDevideMaxOrMinElement(false);
                    var _2A_E = 2 * A3 - Matrix.Create(Chapter7TaskType.EGen, A3.Rows);
                    var _BE = B3 + Matrix.Create(Chapter7TaskType.EGen, B3.Rows);
                    var X3 = (!_2A_E) * _BE;
                    return new object[] {A3,B3,X3};

                case TaskNumber.Task4:
                    double[,] a4Source = { { 1.0, 0.42, 0.54, 0.66 }, { 0.42, 1.0, 0.32, 0.44 }, { 0.54, 0.32, 1.0, 0.22 }, { 0.66, 0.44, 0.22, 1 } };
                    var A4 = Matrix.Create(Chapter7TaskType.FromMatrix, a4Source);
                    var res4 = A4.IsOrtogonal();
                    return new object[] {res4};

                case TaskNumber.Task5:
                    double[] a5source = { 1.0, 0.0, 1.0, 1.0 };
                    var A5 = ~(Matrix.Create(Chapter7TaskType.FromArray, a5source));
                    var H5 = A5 * (~A5) / Math.Pow(A5.VectorLength(), 2);
                    var res5 = H5.IsOrtogonal();
                    return new object[] {res5};

                case TaskNumber.Task6:
                    double[,] a6source = { { -26, -18, -27 }, { 21.0, 15, 21 }, { 12, 8, 13 } };
                    var A6 = Matrix.Create(Chapter7TaskType.FromMatrix, a6source);
                    var det6 = A6.Determinant();
                    var res6 = (A6 * A6) == A6;
                    return new object[] {det6, res6};

                case TaskNumber.Task7:
                    var a7source = new[,] { { 1.0, 2, 5, 1 }, { -2, -1.0, -2, -1 }, { 1.0, 1.0, -3, 1 }, { 1.0, -1.0, 1.0, -1 } };
                    var A7 = Matrix.Create(Chapter7TaskType.FromMatrix, a7source);
                    var X7 = Matrix.Create(Chapter7TaskType.FromArray, new[] { 1.0, -1.0, 3.0, -1.0 });
                    var tt = ~X7;
                    var res7 = A7.Determinant() != 0 ? (!A7) * tt : Matrix.Create(Chapter7TaskType.FromArray, 0);
                    return new object[] {res7};

                case TaskNumber.Task8:
                    double[,] a8source = { { 3.75, -0.28, 0.17 }, { 2.11, -0.11, -0.12 }, { 0.22, -3.17, 1.81 } };
                    double[] b8source = { 0.75, 1.11, 0.05 };
                    var A8 = Matrix.Create(Chapter7TaskType.FromMatrix, a8source);
                    var res8 = Matrix.Create(Chapter7TaskType.FromArray, A8.Slau(b8source).Item2);
                    return new object[] {res8, res8.VectorLength()};

                case TaskNumber.Task9:
                    var a9source = new[,] { { 5.7, -7.8, -5.6, -8.3 }, { 6.6, 13.1, -6.3, 4.3 }, { 14.7, -2.8, 5.6, -12.1 }, { 8.5, 12.7, -23.7, 5.7 } };
                    var b9source = new[] { 2.7, -5.5, 8.6, 14.7 };
                    var y9source = new double[] { 1, 1, 2, -3 };
                    var A9 = Matrix.Create(Chapter7TaskType.FromMatrix, a9source);
                    var Y9 = Matrix.Create(Chapter7TaskType.FromArray, y9source);
                    var res9 = Matrix.Create(Chapter7TaskType.FromArray, A9.Slau(b9source).Item2);
                    return new object[] { res9.ScalarProduct(Y9) };

                case TaskNumber.Task10:
                    var a10source = new[,] { { 4.4, -2.5, 19.2, -10.8 }, { 5.5, -9.3, -14.2, 13.2 }, { 7.1, -11.5, 5.3, -6.7 }, { 14.2, 23.4, -8.8, 5.3 } };
                    var b10source = new[] { 4.3, 6.8, -1.8, 7.2 };
                    var A10 = Matrix.Create(Chapter7TaskType.FromMatrix, a10source);
                    var X10 = Matrix.Create(Chapter7TaskType.FromArray, A10.Slau(b10source).Item2);
                    var res10 = X10 * (~X10);
                    return new object[] {res10};

                case TaskNumber.Task11:
                    var a11source = new[,] { { 0.34, 0.71, 0.63 }, { 0.71, -0.65, -0.18 }, { 1.17, -2.35, 0.75 } };
                    var b11source = new[] { 2.08, 1.17, 1.28 };
                    var A11 = Matrix.Create(Chapter7TaskType.FromMatrix, a11source);
                    var X11 = Matrix.Create(Chapter7TaskType.FromArray, A11.Slau(b11source).Item2);
                    var res11 = (2 * X11 - 3).VectorLength();
                    return new object[] {A11, X11, res11};

                case TaskNumber.Task12:
                    var a12source = new[,] { { 1.24, 0.62, -0.95 }, { 2.15, -1.18, 0.57 }, { 1.72, -0.83, 1.57 } };
                    var b12source = new[] { 1.43, 2.43, 3.88 };
                    var y12source = new[] { -1.0, 5.0, -3.0 };
                    var A12 = Matrix.Create(Chapter7TaskType.FromMatrix, a12source);
                    var X12 = Matrix.Create(Chapter7TaskType.FromArray, A12.Slau(b12source).Item2);
                    var Y12 = Matrix.Create(Chapter7TaskType.FromArray, y12source);
                    var res12 = X12.VectorAngle(Y12);
                    return new object[] {res12};

                case TaskNumber.Task13:
                    var a13source = new[,] { { 8.2, -3.2, 14.2, 14.8 }, { 5.6, -12, 15, -6.4 }, { 5.7, 3.6, -12.4, -2.3 }, { 6.8, 13.2, -6.3, -8.7 } };
                    var b13source = new[] { -8.4, 4.5, 3.3, 14.3 };
                    var A13 = Matrix.Create(Chapter7TaskType.FromMatrix, a13source);
                    var X13 = Matrix.Create(Chapter7TaskType.FromArray, A13.Slau(b13source).Item2);
                    var temp13 = X13 * (~X13);
                    var res13 = Matrix.Create(Chapter7TaskType.EGen, temp13.Rows) - temp13;
                    return new object[] {res13};

                case TaskNumber.Task14:
                    var a14source = new double[,] { { 2, 1, 5, 2 }, { 5, 2, 2, 6 }, { 2, 2, 1, 2 }, { 1, 3, 3, 1 } };
                    var b14source = new double[] { 3, 1, 2, 1 };
                    var A14 = ~(Matrix.Create(Chapter7TaskType.FromMatrix, a14source));
                    var res14 = Matrix.Create(Chapter7TaskType.FromArray, A14.Slau(b14source).Item2);
                    return new object[] {res14};

                case TaskNumber.Task15:
                    var a15source = new double[,] { { 2, 1, 5, 2 }, { 5, 2, 2, 6 }, { 2, 2, 1, 2 }, { 1, 3, 3, 1 } };
                    var b15source = new double[] { 3, 1, 2, 1 };
                    var temp15 = ~(Matrix.Create(Chapter7TaskType.FromMatrix, a15source));
                    var A15 = 2 * (temp15 * temp15);
                    var res15 = Matrix.Create(Chapter7TaskType.FromArray, A15.Slau(b15source).Item2);
                    return new object[] {res15};

                case TaskNumber.Task16:
                    var a16source = new double[,] { { 2, 1, 5, 2 }, { 5, 2, 2, 6 }, { 2, 2, 1, 2 }, { 1, 3, 3, 1 } };
                    var A16 = Matrix.Create(Chapter7TaskType.FromMatrix, a16source);
                    var B16 = Matrix.Create(Chapter7TaskType.Sixteen, a16source);
                    var C16 = (~B16) * A16;
                    var res16 = C16.Determinant();
                    return new object[] {res16};

                case TaskNumber.Task17:
                    var A17 = Matrix.Create(Chapter7TaskType.Two, new double[] { 1, 2, 3 });
                    var B17 = Matrix.Create(Chapter7TaskType.Seventeen, A17.ToArray());
                    var temp17 = A17 * B17;
                    var res17 = (2 * Matrix.Create(Chapter7TaskType.EGen, temp17.Rows) - temp17).Determinant();
                    return new object[] {res17};

                case TaskNumber.Task18:
                    var a18source = new double[,] { { -26, -18, -27 }, { 21, 15, 21 }, { 12, 8, 13 } };
                    var b18source = new double[] { 1, 1, 1 };
                    var A18 = Matrix.Create(Chapter7TaskType.FromMatrix, a18source);
                    var I18 = 2 * Matrix.Create(Chapter7TaskType.EGen, A18.Rows) - A18;
                    var temp18 = (I18 * I18);
                    var res18 = temp18 == Matrix.Create(Chapter7TaskType.EGen, temp18.Rows);
                    var X18 = Matrix.Create(Chapter7TaskType.FromArray, I18.Slau(b18source).Item2);
                    return new object[] {res18, X18};

                case TaskNumber.Task19:
                    var a19source = new[,] { { 1, 0.42, 0.54, 0.66 }, { 0.42, 1, 0.32, 0.44 }, { 0.54, 0.32, 1, 0.22 }, { 0.66, 0.44, 0.22, 1 } };
                    var A19 = Matrix.Create(Chapter7TaskType.FromMatrix, a19source);
                    var issim =  A19.IsSimmetrical();
                    var invMatrix = !A19;
                    var res19 = (A19 * invMatrix) == A19;
                    return new object[] {issim, invMatrix, res19};

                case TaskNumber.Task20:
                    var a20source = new[,] { { -2, 3.01, 0.12, -0.11 }, { 2.92, -0.17, 0.11, 0.22 }, { 0.66, 0.52, 3.17, 2.11 }, { 3.01, 0.42, -0.27, -0.15 } };
                    var b20source = new[,] { { -2, 2.92, 0.66, 3.01 }, { 2.92, -2, 0.11, 0.22 }, { 0.66, 0.11, -2, 2.11 }, { 3.01, 0.22, 2.11, -2 } };
                    var A20 = Matrix.Create(Chapter7TaskType.FromMatrix, a20source);
                    var B20 = Matrix.Create(Chapter7TaskType.FromMatrix, b20source);
                    var a20det = Math.Abs(A20.Determinant());
                    var b20det = Math.Abs(B20.Determinant());
                    var a20sq = A20.SumSquaredElementOfAnyColumnIsOne();
                    var b20sq = B20.SumSquaredElementOfAnyColumnIsOne();
                    var a20sum = A20.SumProductedElementsOfTwoColumnsIsOne();
                    var b20sum = B20.SumProductedElementsOfTwoColumnsIsOne();
                    return new object[] {a20det, b20det, a20sq, b20sq, a20sum, b20sum};

                case TaskNumber.Task21:
                    var a21source = new[,] { { 0.25, 0.33, 1.25, -0.667 }, { 0.333, 0.25, -0.667, 1.333 }, { 0.2, 0.167, 2.2, 1.25 }, { 0.1, 0.143, 3.1, -0.75 } };
                    var x21source = new double[] { 1, 1, 1, 1 };
                    var A21 = Matrix.Create(Chapter7TaskType.FromMatrix, a21source);
                    var res21 = A21.Determinant() != 0 ? Matrix.Create(Chapter7TaskType.FromArray, A21.Slau(x21source).Item2) : Matrix.Create(Chapter7TaskType.FromArray, 0);
                    Console.WindowWidth = res21.Cols * 22;
                    return new object[] {res21};

                case TaskNumber.Task22:
                    var a22source = new[,] { { 0.42, 0.26, 0.33, -0.22 }, { 0.74, -0.55, 0.28, -0.65 }, { 0.88, 0.42, -0.33, 0.75 }, { 0.92, 0.82, -0.62, 0.75 } };
                    var b22source = new double[] { 1, 1, 1, 0 };
                    var A22 = Matrix.Create(Chapter7TaskType.FromMatrix, a22source);
                    var X22 = Matrix.Create(Chapter7TaskType.FromArray, A22.Slau(b22source).Item2);
                    var C22 = X22 * (~X22);
                    var temp22 = (C22 * (~C22)) == Matrix.Create(Chapter7TaskType.EGen, C22.Rows);
                    var tempp22 = (~C22) * C22 == Matrix.Create(Chapter7TaskType.EGen, C22.Rows);
                    return new object[] {temp22, tempp22};

                case TaskNumber.Task23:
                    var a23source = new[,] { { 0.75, 0.18, 0.63, -0.32 }, { 0.92, 0.38, -0.14, 0.56 }, { 0.63, -0.42, 0.18, 0.37 }, { -0.65, 0.52, 0.47, 0.27 } };
                    var A23 = ~(Matrix.Create(Chapter7TaskType.FromMatrix, a23source));
                    var a23sumr = A23.MaxSumRowElementsModules();
                    var a23sumc = A23.MaxSumColElementsModules();
                    var a23det = A23.Determinant();
                    return new object[] {a23sumr, a23sumc, a23det};

                case TaskNumber.Task24:
                    var a24source = new[,] { { -1.09, 7.56, 3.45, 0.78 }, { 3.33, 4.45, -0.21, 3.44 }, { 2.33, -4.45, 0.17, 2.21 }, { 4.03, 1, 3.05, 0.11 } };
                    var A24 = !(Matrix.Create(Chapter7TaskType.FromMatrix, a24source));
                    var res24 = A24.SqrtSumSquaredElements();
                    return new object[] {res24};

                case TaskNumber.Task25:
                    var a25source = new[,] { { 8.2, -3.2, 14.2, 14.8 }, { 5.6, -12, 15, -6.4 }, { 5.7, 3.6, -12.4, -2.3 }, { 6.8, 13.2, -6.3, -8.7 } };
                    var b25source = new[] { -8.4, 4.5, 3.3, 14.3 };
                    var A25 = Matrix.Create(Chapter7TaskType.FromMatrix, a25source);
                    var res25 = Matrix.Create(Chapter7TaskType.FromArray, A25.Slau(b25source).Item2);     
                    var check25 = A25 * (~res25);
                    return new object[] {res25, check25};

                default:
                    throw new ArgumentOutOfRangeException(number.GetType().Name, number, null);
            }
        }

    }
}
