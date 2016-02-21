using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Chapters
{
    public class Matrix:IEnumerable<double>
    {
        #region Constructors

        private Matrix(){}

        private Matrix(double[,] _source)
        {
            var rows = _source.GetLength(0);
            var cols = _source.GetLength(1);
            source = new double[rows, cols];
            Array.Copy(_source, source, rows * cols);
        }

       
        private Matrix(double[] _source)
        {
            source = new double[1, _source.Length];
            for (var i = 0; i < _source.Length; i++)
                source[0, i] = _source[i];
        }

        private Matrix(int rows, int columns)
        {
            source = new double[rows, columns];
        }


        public static Matrix Create(Chapter7TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter7TaskType.FromArray:
                    return new Matrix(param as double[]);
                case Chapter7TaskType.FromMatrix:
                    return new Matrix(param as double[,]);
                case Chapter7TaskType.FromDimensions:
                    var size = param as Size? ?? new Size();
                    return new Matrix(size.Height, size.Width);
                case Chapter7TaskType.EGen:
                    return EGeneration(param as int? ?? 0);

                case Chapter7TaskType.One:
                    return new Matrix(param as double[,]).B1Calculate();
                case Chapter7TaskType.Two:
                    return ToMatrix(param as double[]);
                case Chapter7TaskType.Three:
                    var arg = param as Tuple<double[], double[]>;
                    return Transform2ArraysToMatrix(arg.Item1, arg.Item2);
                case Chapter7TaskType.Sixteen:
                    return new Matrix(param as double[,]).B16Calculate();
                case Chapter7TaskType.Seventeen:
                    return new Matrix(param as double[,]).B17Calculate();

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }


        #endregion

        #region Interface implementations


        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            foreach (var d in source)
                yield return d;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties
        private double[,] source { get; set; }
        public int Rows { get { return source.GetLength(0); } }
        public int Cols { get { return source.GetLength(1); } }
        public double this[int i, int j]
        {
            get { return source[i, j]; }
            set { source[i, j] = value; }
        }
        #endregion

        #region Overload operators

        public static Matrix operator *(Matrix A, Matrix B)
        {
            return EliminateError(OpMultiply(A, B));
        }

        public static Matrix operator *(Matrix A, double koef)
        {
            return EliminateError(OpMultiply(A, koef));
        }

        public static Matrix operator /(Matrix A, double koef)
        {
            return EliminateError(OpMultiply(A,1/koef));
        }

        public static Matrix operator *(double koef, Matrix A)
        {
            return EliminateError(OpMultiply(A, koef));
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            return OpAddition(A, B, (x, y) => x + y);
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            return OpAddition(A, B, (x, y) => x - y);
        }

        public static Matrix operator -(Matrix A, double koef)
        {
            return OpAddition(A, koef, (x, y) => x - y);
        }

        public static Matrix operator !(Matrix A)
        {
            return EliminateError(A.Inverse());
        }

        public static Matrix operator ~(Matrix A)
        {
            //Transporation
            return OpOnesComplement(A);
        }

        public static bool operator ==(Matrix A, Matrix B)
        {
            return A.IsEquals(B);
        }

        public static bool operator !=(Matrix A, Matrix B)
        {
            return !A.IsEquals(B);
        }
        #endregion

        #region Methods


        #region Overrided methods
        public override string ToString()
        {
            var sb = new StringBuilder();
            var rows = source.GetLength(0);
            var cols = source.GetLength(1);

            var maxLength = int.MinValue;
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                {
                    var len = source[i, j].ToString().Length;
                    if (len > maxLength)
                        maxLength = len;
                }

            var tmp = new List<int>();
            maxLength += 2;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var elem = source[i, j].ToString();
                    var pad = (maxLength - elem.Length) / 2;
                    var resuElem = elem.PadRight(pad + elem.Length).PadLeft(maxLength);
                    sb.AppendFormat("|{0}", resuElem);
                }
                sb.Append("|\r\n");

                if (i == 0)
                    tmp = sb.ToString().Select((x, n) => Tuple.Create(x, n)).Where(x => x.Item1 == '|').Select(x => x.Item2).ToList();

                for (var m = 0; m < 2; m++)
                {
                    if (i == rows - 1 && m == 1)
                        continue;

                    var k = 0;
                    for (var j = 0; j <= tmp.Last(); j++)
                    {
                        if (j == tmp[k])
                        {
                            sb.Append('|');
                            k++;
                        }
                        else
                            sb.Append(' ');
                    }
                    sb.AppendLine();

                    if (m == 0)
                    {
                        sb.Append('-', tmp.Last() + 1);
                        sb.AppendLine();
                    }
                }
            }

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return IsEquals(obj as Matrix);
        }

        #endregion


        #region Public methods

        public double Determinant()
        {
            return DeterminantWorker(source);
        }

        public Matrix Copy(int nRows, int nCols, int startRow = 0, int startCol = 0)
        {
            var res = new Matrix(nRows, nCols);
            for (var i = startRow; i < nRows; i++)
                for (var j = startCol; j < nCols; j++)
                    res[i - startRow, j - startCol] = this[i, j];

            return res;
        }

        public Tuple<int, double[]> Slau(double[] b)
        {
            if (Rows != Cols)
                throw new DataException("Underlying matrix should be square!");

            //Функция SLAU возвращает:
            //0 - решение найдено
            //-1 - система имеет бесконечное множество решений
            //-2 - система не имеет решений
            //copy - матрица коэффициентов СЛАУ
            //b - вектор правых частей
            //x - решение СЛАУ
            int i, j, k, r;
            double c, M, max, s;
            var copy = new Matrix(source);
            //Прямой ход метода Гаусса: приводим матрицу а (копию матрицы коэффициентов СЛАУ) 
            //к диагональному виду
            for (k = 0; k < Rows; k++)
            {
                //поиск максимального по модулю элемента в k-м столбце
                max = Math.Abs(copy[k, k]);
                r = k;
                for (i = k + 1; i < Rows; i++)
                {
                    if (Math.Abs(copy[i, k]) > max)
                    {
                        max = Math.Abs(copy[i, k]);
                        r = i;
                    }
                }
                //меняем местами k-ю и r-ю (строку, где находится максимальный 
                //по модулю элемент) строки
                for (j = 0; j < Rows; j++)
                {
                    c = copy[k, j];
                    copy[k, j] = copy[r, j];
                    copy[r, j] = c;
                }
                c = b[k];
                b[k] = b[r];
                b[r] = c;
                //Приведение матрицы к диагональному виду
                for (i = k + 1; i < Rows; i++)
                {
                    for (M = copy[i, k] / copy[k, k], j = k; j < Rows; j++)
                    {
                        copy[i, j] -= M * copy[k, j];
                    }
                    b[i] -= M * b[k];
                }
            }
            //Обратный ход метода Гаусса
            //Если последний элемент равен 0 и
            if (copy[Rows - 1, Rows - 1] == 0)
            {
                //если последний коэффициент вектора свободных членов равен 0
                if (b[Rows - 1] == 0)
                {
                    //система имеет бесконечное множество решений
                    return Tuple.Create(-1, new double[] { });
                }
                //если последний коэффициент вектора свободных членов не равен 0
                //то система решений не имеет
                return Tuple.Create(-2, new double[] { });
            }
            //если последний диагональный элемент не равен 0,
            //то начинается обратный ход метода Гаусса
            var x = new double[Rows];
            for (i = Rows - 1; i >= 0; i--)
            {
                for (s = 0, j = i + 1; j < Rows; j++)
                {
                    s += copy[i, j] * x[j];
                }
                x[i] = (b[i] - s) / copy[i, i];
            }

            EliminateError(x);
            return Tuple.Create(0, x);
        }
        
        public bool IsOrtogonal()
        {
            return (~this) == (!this);
        }

        public double[,] ToArray()
        {
            return source;
        }

        public bool IsSimmetrical()
        {
            return (~this) == this;
        }
        
        public double VectorLength()
        {
            return CalculateVectorLength(this);
        }

        public double ScalarProduct(Matrix Y)
        {
            return CalculateScalarProduct(Y);
        }
    
        public double VectorAngle(Matrix Y)
        {
            return CalculateScalarProduct(Y) / CalculateVectorLength(this)/CalculateVectorLength(Y);
        }

        public Matrix MatrixDevideMaxOrMinElement(bool flag)
        {
            return A2DevideMaxOrMin(flag);
        }

        public bool SumSquaredElementOfAnyColumnIsOne()
        {
            var copy = Copy(Rows, Cols);
            foreach (var d in copy)
                if (d > 1)
                    return false;
            var sum = 0.0;
            for (var j = 0; j < Rows; j++)
            {
                for (var i = 0; i < Cols; i++)
                    sum += copy[i, j] * copy[i, j];
                if (sum != 1.0) return false;
                sum = 0.0;
            }
            return true;
        }

        public bool SumProductedElementsOfTwoColumnsIsOne()
        {
            var copy = Copy(Rows, Cols);
            var sum = 0.0;
            var r = new Random();
            for (var j = 0; j < Cols; j++)
            {
                var temp = r.Next(j+1, copy.Rows);
                if (temp != j)
                {
                    for (var i = 0; i < Rows; i++)
                        sum += copy[i, j]*copy[i, temp];
                    if (sum != 0.0) return false;
                    sum = 0.0;
                }
            }
            return true;
        }

        public double MaxSumRowElementsModules()
        {
            var copy = Copy(Rows, Cols);
            var max = 0.0;
            var temp = 0.0;

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Cols; j++)
                    temp += Math.Abs(copy[i,j]);
                max = temp > max ? temp : max;
                temp = 0;
            }
            return max;
        }

        public double MaxSumColElementsModules()
        {
            var copy = Copy(Rows, Cols);
            var max = 0.0;
            var temp = 0.0;

            for (var j = 0; j < Cols; j++)
            {
                for (var i = 0; i < Rows; i++)
                    temp += Math.Abs(copy[i, j]);
                max = temp > max ? temp : max;
                temp = 0;
            }
            return max;
        }

        public double SqrtSumSquaredElements()
        {
            var copy = Copy(Rows, Cols);
            var sum = 0.0;
            for (var i = 0; i < Rows; i++)
                for (var j = 0; j < Cols; j++)
                    sum += copy[i,j]*copy[i,j];
            return Math.Sqrt(sum);
        }
        #endregion


        #region Private methods


        private double CalculateScalarProduct(Matrix A)
        {
            if(Rows!=A.Rows && Cols!=A.Cols)
                throw new ArgumentException("matrixes must have equal rows and columns count");
            double res = 0;
            for(var i = 0; i < A.Rows; i++)
                for (var j = 0; j < A.Cols; j++)
                    res += this[i, j]*A[i, j];
            return res;
        }
        private double CalculateVectorLength(Matrix A)
        {
            if(A.Rows>1 && A.Cols>1)
                throw new ArgumentException("Vector must have unit length one parameter");
            if (A.Rows == 1 && A.Cols == 1)
                return A[0, 0];
            var sum = 0.0;
            foreach (var s in A)
                sum += Math.Pow(s, 2);
      
            return Math.Sqrt(sum);
        }
        private double EliminateError(double d)
        {
            //d = double.Parse(d.ToString());
            return Math.Round(d, 6);
        }
        private void EliminateError(double[] input)
        {
            for (var i = 0; i < input.Length; i++)
                input[i] = double.Parse(input[i].ToString());
        }
        private static Matrix EliminateError(Matrix A)
        {
            for (var i = 0; i < A.Rows; i++)
                for (var j = 0; j < A.Cols; j++)
                    A[i, j] = Math.Round(A[i, j], 6);
            //var temp = A[i, j].ToString(CultureInfo.InstalledUICulture);
            //A[i,j] = double.Parse(A[i,j].ToString(), NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat);
            //A[i, j] = res;
            return A;
        }

        private double DeterminantWorker(double[,] subMatrix)
        {
            var N = subMatrix.GetLength(0);

            if (N != subMatrix.GetLength(1))
                throw new DataException("Matrix should be squared!");
             
            if (N == 1)
                return subMatrix[0, 0];

            if (N == 2)
                return subMatrix[0, 0]*subMatrix[1, 1] - subMatrix[0, 1]*subMatrix[1, 0];
            

        var koef = 1;
            var result = 0.0;
            var temp = 0.0;
            for (var i = 0; i < N; i++)
            {
                var nextSubMatrix = new double[N - 1, N - 1];
                for (var j = 1; j < N; j++)
                {
                    for (var k = 0; k < i; k++)
                        nextSubMatrix[j - 1, k] = subMatrix[j, k];

                    for (var k = i + 1; k < N; k++)
                        nextSubMatrix[j - 1, k - 1] = subMatrix[j, k];
                }
                temp = subMatrix[0, i];
                result += temp * DeterminantWorker(nextSubMatrix) * koef;
                koef *= -1;
            }
            return result;
        }

        private bool IsEquals(Matrix A)
        {
            return A.Select((x, i) => this.ElementAt(i) == x).All(x => x);
        }

        private static Matrix OpMultiply(Matrix A, Matrix B)
        {
            var aRows = A.Rows;
            var aCols = A.Cols;
            var bRows = B.Rows;
            var bCols = B.Cols;

            if (aCols != bRows)
                throw new DataException(
                    "Number of cols 1st matrix should be equals to number of rows of the 2nd matrix!");

            var result = new Matrix(aRows, bCols);

            for (var i = 0; i < aRows; i++)
                for (var j = 0; j < bCols; j++)
                    for (var k = 0; k < bRows; k++)
                        result[i, j] += A[i, k] * B[k, j];

            return result;
        }

        private static Matrix OpAddition(Matrix A, Matrix B, Func<double, double, double> op)
        {
            var aRows = A.Rows;
            var aCols = A.Cols;
            var bRows = B.Rows;
            var bCols = B.Cols;

            if (aRows != bRows || aCols != bCols)
                throw new DataException("Dimensions pf the first matrix should be equals to dimensions of the second matrix!");

            var result = new Matrix(aRows, aCols);

            for (var i = 0; i < aRows; i++)
                for (var j = 0; j < aCols; j++)
                    result[i, j] = op(A[i, j], B[i, j]);

            return result;
        }

        private static Matrix OpAddition(Matrix A, double koef, Func<double, double, double> op)
        {
            var aRows = A.Rows;
            var aCols = A.Cols;
            var result = new Matrix(aRows, aCols);

            for (var i = 0; i < aRows; i++)
                for (var j = 0; j < aCols; j++)
                    result[i, j] += A[i, j] - koef;

            return result;
        }

        private static Matrix OpMultiply(Matrix A, double koef)
        {
            var aRows = A.Rows;
            var aCols = A.Cols;
            var result = new Matrix(aRows, aCols);

            for (var i = 0; i < aRows; i++)
                for (var j = 0; j < aCols; j++)
                    result[i, j] += A[i, j] * koef;

            return result;
        }

        private static Matrix OpOnesComplement(Matrix A)
        {
            var rows = A.Rows;
            var cols = A.Cols;
            var res = new Matrix(cols, rows);

            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                    res[j, i] = A[i, j];

            return res;
        }

        private Matrix Inverse()
        {
            if (Rows != Cols)
                throw new DataException("Underlying matrix should be square!");

            if (Rows == 1)
                throw new DataException("Dimension of underlying matrix should be greater than one!");

            //у - обратная матрица
            //Функция будет возвращать 0, если обратная матрица существует
            //-1 - в противном случае
            var y = new Matrix(Rows, Rows);
            int i, j;
            var res = Tuple.Create(1, new double[] { });
            double[] b;
            //Выделение памяти для промежуточных массивов
            b = new double[Rows];
            for (i = 0; i < Rows; i++)
            {
                //Формирование вектора правых частей для нахождения i-го столбца
                //матрицы
                for (j = 0; j < Rows; j++)
                    if (j == i)
                        b[j] = 1;
                    else
                        b[j] = 0;
                //Нахождение i-го столбца матрицы путём решения СЛАУ Ax=b методом Гаусса.

                res = Slau(b);
                //Если решение СЛАУ не найдено, то невозможно вычислить обратную матрицу
                if (res.Item1 != 0)
                    break;
                //Формирование i-го столбца обратной матрицы
                for (j = 0; j < Rows; j++)
                    y[j, i] = res.Item2[j];
            }
            //Проверка существования обратной матрицы,если решение одного из
            //уравнений вида Ax=b не существует, то невозможно найти обратную
            //матрицу, и функция INVERSE вернёт значение -1
            if (res.Item1 != 0)
                return new Matrix(new double[,] { { -1 } }); //-1;

            return y;     //0;
        }

        private static Matrix EGeneration(int rows)
        {
            if (rows < 1)
                throw new DataException("Dimension of underlying matrix should be greater than one!");
            var E = new Matrix(rows, rows);
            for (var i = 0; i < rows; i++)
                E[i, i] = 1;
            return E;
        }

        private Matrix B1Calculate()
        {
            var A = source;
            var rows = A.GetLength(0);
            var cols = A.GetLength(1);
            var B = new Matrix(rows, cols);

            for (var i = 0; i < rows; i += 2)
            {
                for (var j = 0; j < cols; j++)
                {
                    B[i, j] = A[i, j] * A[i, j];
                }
            }

            for (var i = 1; i < rows; i += 2)
            {
                for (var j = 0; j < cols; j++)
                {
                    B[i, j] = 2 * A[i, j];
                }
            }
            return B;
        }

        private Matrix B16Calculate()
        {
            var A = source;
            var rows = A.GetLength(0);
            var cols = A.GetLength(1);
            var B = new Matrix(rows, cols);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if(i<j)
                        B[i, j] = A[i, j] * A[i, j];
                    if (i > j)
                        B[i, j] = A[i, j] / 3;
                }
            }
            
            return B;
        }

        private Matrix B17Calculate() ///////////////////////////////
        {
            var A = source;
            var sum = 0.0;
            var rows = A.GetLength(0);
            var cols = A.GetLength(1);
            var B = new Matrix(rows, cols);
            for (var i = 0; i < cols; i++)
                sum += A[i, i];
            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                    B[i, j] = A[i, j] / sum;
                
            return B;
        }

        private static Matrix ToMatrix(double[] array)
        {
            var A = new Matrix(array.Length, array.Length);
            for (var i = 0; i < array.Length; i++)
                for (var j = 0; j < array.Length; j++)
                    A[i, j] = array[i] * array[j];


            return A;
        }

        private static Matrix Transform2ArraysToMatrix(double[] array1, double[] array2)
        {
            if (array1.Length != array2.Length)
                throw new RankException("Array must have equal length");

            var A = new Matrix(array1.Length, array1.Length);

            for (var i = 0; i < array1.Length; i++)
                for (var j = 0; j < array2.Length; j++)
                    A[i, j] = array1[i] * array2[j];

            return A;
        }

        private Matrix A2DevideMaxOrMin(bool flag)
        {
            if (Rows != Cols)
                throw new DataException("Underlying matrix should be square!");
            if (Rows == 1)
                throw new DataException("Dimension of underlying matrix should be greater than one!");
            var copy = Copy(Rows, Cols);
            var temp = copy[0, 0];

            if (flag)
                foreach (var d in copy)
                {
                    if (d > temp)
                        temp = d;
                }
            else
            {
                foreach (var d in copy)
                {
                    if (d < temp)
                        temp = d;
                }
            }
            for (var i = 0; i < copy.Rows; i++)
            {
                for (var j = 0; j < copy.Cols; j++)
                {
                    copy[i, j] /= temp;
                    copy[i, j] = EliminateError(copy[i, j]);
                }
            }

            return copy;
        }

        

        #endregion

        

        #endregion
    }
}
