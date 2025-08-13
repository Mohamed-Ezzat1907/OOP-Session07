using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOOP07.Classes
{
    internal static class Maths
    {
        #region Attributes

        public static int operationCount = 0; 

        #endregion

        #region Methods

        public static decimal Add(decimal num01, decimal num02)
        {
            operationCount++;

            return num01 + num02;
        }

        public static decimal Subtract(decimal num01, decimal num02) 
        {
            operationCount++;

            return num01 - num02; 
        }

        public static decimal Multiply(decimal num01, decimal num02)
        {
            operationCount++;

            return num01 * num02;
        }

        public static double Divide(double num01, double num02)
        {
            operationCount++;

            if (num02 == 0)
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return double.NaN;
            }
            else
                return num01 / num02;
        }

        public static double Power(double num, int exponent)
        {
            operationCount++;

            double result = 1;
            if (exponent > 0)
            {
                for (int i = 0; i < exponent; i++)
                {
                    result *= num;
                }
            }
            else if (exponent < 0)
            {
                for (int i = 0; i < -exponent; i++)
                {
                    result *= num;
                }
                result = 1 / result;
            }
            else
            {
                result = 1;
            }

            return result;
        }

        public static double Average(double[] arr)
        {
            operationCount++;

            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Array is empty or null.");
                return double.NaN;
            }
            else
            {
                double sum = 0;
                foreach(double number in arr)
                    sum += number;
                return sum / arr.Length;
            }
        }

        public static void ShowOperationCount()
        {
            Console.WriteLine($"total operations have been performed: {operationCount}");
        }

        #endregion
    }
}
