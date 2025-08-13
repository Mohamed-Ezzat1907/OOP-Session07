using Task.Tak02.Classes;
using Task.Task01.Classes;
using Task.Task01.Interfaces;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task01

            // إنشاء أمثلة (بعضها صالح وبعضها خاطئ لعرض الحالات)
            List<IPaymentMethod> payments = new List<IPaymentMethod>
            {
                new CreditCardPayment
                {
                    CardNumber = "4111 1111 1111 1111",
                    CardHolderName = "Mohamed Ezzat",
                    ExpiryDate = DateTime.Now.AddYears(2)
                },
                new CreditCardPayment
                {
                    CardNumber = "1234",
                    CardHolderName = "", // خطأ: اسم فارغ
                    ExpiryDate = DateTime.Now.AddMonths(-2) // خطأ: منتهي
                },
                new PayPalPayment
                {
                    Email = "user@example.com",
                    Password = "secret123"
                },
                new PayPalPayment
                {
                    Email = "invalid-email",
                    Password = "123" // خطأ: إيميل وصلاحية
                }
            };

            decimal amountToCharge = 100m;

            foreach (var method in payments)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Attempting payment using: {method.GetType().Name}");

                if (method.ValidatePaymentDetails())
                {
                    method.Pay(amountToCharge);
                }
                else
                {
                    Console.WriteLine($"Error: Validation failed for {method.GetType().Name}.\n");
                }
            }

            Console.WriteLine("All attempts finished. Press any key to exit.");
            Console.ReadKey(); 

            #endregion



            #region Task02

            Console.WriteLine("\n=== Shape Calculations ===");
            Shape rectangle = new Rectangle(5, 10);
            Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}");
            Console.WriteLine($"Rectangle Perimeter: {rectangle.CalculatePerimeter()}");

            Shape circle = new Circle(7);
            Console.WriteLine($"Circle Area: {circle.CalculateArea():F2}");
            Console.WriteLine($"Circle Perimeter: {circle.CalculatePerimeter():F2}");

            #endregion
        }
    }
    
}
