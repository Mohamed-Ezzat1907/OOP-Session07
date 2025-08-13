using AssignmentOOP07.Classes;

namespace AssignmentOOP07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Assignment

            Console.WriteLine("Add: " + Maths.Add(5, 4));
            Console.WriteLine("Subtract: " + Maths.Subtract(5, 6));
            Console.WriteLine("Multiply: " + Maths.Multiply(9, 3));
            Console.WriteLine("Divide: " + Maths.Divide(20, 5));
            Console.WriteLine("Power: " + Maths.Power(4, 2));
            Console.WriteLine("Average: " + Maths.Average(new double[] { 3, 12, 10, 32 }));

            Maths.ShowOperationCount(); 

            #endregion

        }
    }
}
