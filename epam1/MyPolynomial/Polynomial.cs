using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPolynomial
{
    public class Polynomial
    {
        private int[] coefficients;
        public readonly int amount;

        public Polynomial(int[] coefficients)
        {
            this.coefficients = coefficients;
            coefficients.CopyTo(this.coefficients, 0);
            this.amount = coefficients.Length;
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < coefficients.Length)
                    return coefficients[i];
                else
                    throw new IndexOutOfRangeException();
            }

            set
            {
                if (i >= 0 && i < coefficients.Length)
                    coefficients[i] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public void ShowCoefficients()
        {
            for (int i = 0; i < amount; i++)
            {
                Console.Write($"{coefficients[i]} ");
            }
            Console.WriteLine();
        }

        public void ShowCoefficients(int newElement, int oldElement)
        {
            Console.Write("Changing polynomial: ");
            for (int i = 0; i < amount; i++)
            {
                if (coefficients[i] == oldElement)
                    coefficients[i] = newElement;
                Console.Write($"{coefficients[i]} ");
            }
            Console.WriteLine();
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            int size;
            if (ReferenceEquals(polynomial1, null) || ReferenceEquals(polynomial2, null))
            {
                throw new NullReferenceException();
            }
            if (polynomial1.coefficients.Length >= polynomial2.coefficients.Length)
                size = polynomial1.coefficients.Length;
            else
                size = polynomial2.coefficients.Length;

            int[] coeffs = new int[size];
            Polynomial result = new Polynomial(coeffs);
            for (int i = 0; i < result.amount; i++)
            {
                int a, b;
                if (polynomial1.coefficients.Length <= i)
                    a = 0;
                else
                    a = polynomial1.coefficients[i];

                if (polynomial2.coefficients.Length <= i)
                    b = 0;
                else
                    b = polynomial2.coefficients[i];

                result.coefficients[i] = a + b;

            }
            return result;
            
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            int size;
            if (ReferenceEquals(polynomial1, null) || ReferenceEquals(polynomial2, null))
            {
                throw new NullReferenceException();
            }
            if (polynomial1.coefficients.Length >= polynomial2.coefficients.Length)
                size = polynomial1.coefficients.Length;
            else
                size = polynomial2.coefficients.Length;

            int[] coeffs = new int[size];
            Polynomial result = new Polynomial(coeffs);
            for (int i = 0; i < result.amount; i++)
            {
                int a, b;
                if (polynomial1.coefficients.Length <= i)
                    a = 0;
                else
                    a = polynomial1.coefficients[i];

                if (polynomial2.coefficients.Length <= i)
                    b = 0;
                else
                    b = polynomial2.coefficients[i];

                result.coefficients[i] = a - b;

            }
            return result;
        }


        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (ReferenceEquals(polynomial1, null) || ReferenceEquals(polynomial2, null))
            {
                throw new NullReferenceException();
            }
            int size = polynomial1.coefficients.Length + polynomial2.coefficients.Length - 1;
            int[] coefficients = new int[size];
            Polynomial result = new Polynomial(coefficients);
            for (int i = 0; i < polynomial1.coefficients.Length; ++i)
            {
                for (int j = 0; j < polynomial2.coefficients.Length; ++j)
                {
                    coefficients[i + j] += polynomial1.coefficients[i] * polynomial2.coefficients[j];
                }
            }
            return result;
        }
    }

   
}
