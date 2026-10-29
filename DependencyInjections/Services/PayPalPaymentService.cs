using DependencyInjections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjections.Services
{
    internal class PayPalPaymentService : IPaymentService
    {
        public void Pay(decimal paypalAmount)
        {
            Console.WriteLine($"{paypalAmount} paid by PayPal.");
        }
    }
}
