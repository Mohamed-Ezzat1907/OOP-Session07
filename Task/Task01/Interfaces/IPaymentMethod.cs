using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Task01.Interfaces
{
    internal interface IPaymentMethod
    {
        public void Pay(decimal amount);
        bool ValidatePaymentDetails();
    }
}
