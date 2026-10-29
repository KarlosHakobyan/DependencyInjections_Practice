using DependencyInjections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjections.Services
{
    internal class CardPaymentService : IPaymentService
    {
        public void Pay(decimal cardAmount)
        {
            Console.WriteLine($"{cardAmount} paid by card");
        }
    }
}
