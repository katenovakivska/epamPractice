using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrix
{
    public class Matrix
    {
        private int[,] matrix;
        public readonly int rows;
        public readonly int columns;

        public Matrix(int[,] matrix)
        {
            this.matrix = Copy(matrix);
            this.rows = matrix.GetLength(0);
            this.columns = matrix.GetLength(1);
        }

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                    return matrix[i, j];
                else
                    throw new IndexOutOfRangeException();
            }

            set
            {
                if (i >= 0 && i < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                    matrix[i, j] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        //in GetValue param means dimension of multidimensional array
        public static int[,] Copy(int [,] matrix)
        {
            int[,] m = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    m[i,j] = matrix[i, j];
                }
            }
            return m;
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            int sum = 0;
            if (matrix1.columns != matrix2.rows)
            {
                throw new IndexOutOfRangeException();
            }

            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
            {
                throw new NullReferenceException();
            }
            var result = new Matrix(matrix1.rows, matrix2.columns);
            result.matrix = new int[matrix1.rows, matrix2.columns];
            
            for (int k = 0; k < matrix2.columns; k++)
            {
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.columns; j++)
                    {
                        sum += matrix1[i, j] * matrix2[j, k];    
                    }
             
                    result.matrix[i,k] = sum;
                    sum = 0;
                }
            }
            return result;
        }
       

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            var result = new Matrix(matrix1.rows, matrix2.columns);
            result.matrix = new int[matrix1.rows, matrix2.columns];
            if (matrix1.columns != matrix2.rows)
            {
                throw new IndexOutOfRangeException();
            }
            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.columns; j++)
                    {
                       result.matrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                    
                }

            return result;
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            var result = new Matrix(matrix1.rows, matrix2.columns);
            result.matrix = new int[matrix1.rows, matrix2.columns];
            if (matrix1.columns != matrix2.rows)
            {
                throw new IndexOutOfRangeException();
            }
            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
            {
                throw new NullReferenceException();
            }
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix1.columns; j++)
                {
                    result.matrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }

            }
            return result;
        }

        public static bool operator ==(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows == matrix2.rows && matrix1.columns == matrix2.columns)
            {
                return true;
            }
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix1.columns; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            {
                return true;
            }
            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix1.columns; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void ShowResult()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public void RangeException(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.columns != matrix2.rows)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override bool Equals(object obj)
        {
            var matrix = obj as Matrix;
            return matrix != null &&
                   EqualityComparer<int[,]>.Default.Equals(this.matrix, matrix.matrix) &&
                   rows == matrix.rows &&
                   columns == matrix.columns;
        }

        public override int GetHashCode()
        {
            var hashCode = 1313493824;
            hashCode = hashCode * -1521134295 + EqualityComparer<int[,]>.Default.GetHashCode(matrix);
            hashCode = hashCode * -1521134295 + rows.GetHashCode();
            hashCode = hashCode * -1521134295 + columns.GetHashCode();
            return hashCode;
        }
    }
}
