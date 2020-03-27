using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMatrix;
using MyPolynomial;

namespace epam1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[,] { { 1, 2, 4 }, { 2, 3, 6 }, { 3, 4, 8 } };
            int[,] numbers1 = new int[,] { { 5, 6, 4 }, { 1, 3, 7 }, { 5, 6, 9 } };
            int[,] numbers2 = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } };
            int[,] numbers3 = new int[,] { { 1, 4, 4}, { 2, 5,5 }, { 3, 6,7 }, { 4,5,6} };
            int[,] numbers4 = new int[,] { { 1, 4, 4 }, { 2, 5, 5 }, { 3, 6, 7 }, { 4, 5, 6 } };

            Matrix m = new Matrix(numbers);
            Matrix m1 = new Matrix(numbers2);
            Matrix m2 = new Matrix(numbers1);
            Matrix m3 = new Matrix(numbers3);
            Matrix m4 = new Matrix(numbers3);

            Console.WriteLine("Multiplication matrix:");
            try
            {
                var result = m*m1;
                result.ShowResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.WriteLine("Addition matrix:");
            try
            {
                var result1 = m + m2;
                result1.ShowResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
           
            
            Console.WriteLine("Substraction matrix:");
            try
            {
                var result2 = m - m2;
                result2.ShowResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.Write("Compare matrix: ");
            try
            {
                if (m != m1)
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            int[] coeffs = new int[] { 5, 3, 0, 1, 5 };
            int[] coeffs1 = new int[] { 1, 2, 1, 0, 3};
            int[] coeffs2 = new int[] {  2, 1, 0, 3 };
            int[] coeffs3 = new int[] { 1, 2, 0, 0, 3 };
            int[] coeffs4 = new int[] { 2, 0, 7, 3 , 1};

            Polynomial p = new Polynomial(coeffs);
            Polynomial p1 = new Polynomial(coeffs1);
            Polynomial p2 = new Polynomial(coeffs2);
            Polynomial p3 = new Polynomial(coeffs1);
            Polynomial p4 = new Polynomial(coeffs2);


            Console.WriteLine("Polynomial addition: ");
            try
            {
                var result3 = p3 + p4;
                result3.ShowCoefficients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            Console.WriteLine("Polynomial substraction: ");
            try
            { 
                var result4 = p3 - p4;
                result4.ShowCoefficients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            Console.WriteLine("Polynomial multilication: ");
            try
            {
                Polynomial result5 = p * p1;
                result5.ShowCoefficients();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }

    }
}
