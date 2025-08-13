using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task.Task01.Interfaces;

namespace Task.Task01.Classes
{
    internal class CreditCardPayment : IPaymentMethod
    {
        #region properties

        public string? CardHolderName { get; set; }
        public string? CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }

        #endregion

        #region Methods
        public void Pay(decimal amount)
        {
            var sanitized = Regex.Replace(CardNumber ?? "", @"\D", "");
            var last4 = sanitized.Length >= 4 ? sanitized.Substring(sanitized.Length - 4) : sanitized;
            Console.WriteLine($"Processing Credit Card payment of {amount:C} for {CardHolderName} (card ending {last4})...");
            
            Console.WriteLine("Payment successful via Credit Card.\n");
        }

        public bool ValidatePaymentDetails()
        {
            if(CardHolderName is null)
            {
                Console.WriteLine("CreditCard: Card holder name is empty.");
                return false;
            }

            var digitsOnly = Regex.Replace(CardNumber ?? "", @"\D", "");
            if (!Regex.IsMatch(digitsOnly, @"^\d{13,19}$"))
            {
                Console.WriteLine("CreditCard: Card number must contain 13 to 19 digits.");
                return false;
            }

            if (ExpiryDate < DateTime.Now)
            {
                Console.WriteLine("CreditCard: Card is expired.");
                return false;
            }

            return true;
        } 

        #endregion
    }

    internal class PayPalPayment : IPaymentMethod
    {
        #region properties

        public string Email { get; set; }
        public string Password { get; set; }

        #endregion

        #region Methods

        public bool ValidatePaymentDetails()
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                Console.WriteLine("PayPal: Email is empty.");
                return false;
            }

           
            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Console.WriteLine("PayPal: Invalid email format.");
                return false;
            }

            
            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
            {
                Console.WriteLine("PayPal: Password must be at least 6 characters.");
                return false;
            }

            return true;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C} for account {Email}...");
            
            Console.WriteLine("Payment successful via PayPal.\n");
        }

        #endregion
    }
}
