using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjections.Interfaces
{
    internal interface IPaymentService
    {
        void Pay(decimal amount);
    }
}
