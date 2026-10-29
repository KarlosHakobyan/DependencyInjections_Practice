using DependencyInjections.Interfaces;
using DependencyInjections.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjections
{
    internal class Program
    {
       
        static void Main()
        {
            var services = new ServiceCollection();

            Console.Write("Insert amount for pay: ");
         

            if (!decimal.TryParse(Console.ReadLine(), out decimal amount)
                || amount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }


            services.AddTransient<OrderService>();
            services.AddSingleton<ILoggerService, ConsoleLoggerService>();

            Console.WriteLine("Chose payment method: Insert 1 for Card / 2 for PayPal");
            string method = Console.ReadLine();
            switch (method)
            {
                case "1":
                    services.AddTransient<IPaymentService, CardPaymentService>();
                    break; 

                case "2":
                    services.AddTransient<IPaymentService, PayPalPaymentService>();
                    break; 

                default:
                    Console.WriteLine("Invalid payment method.");
                    return;
            }

                //Alternative 
/*            services.AddTransient<Func<string, IPaymentService>>(provider => method =>
            {
                return method switch
                {
                    "1" => provider.GetRequiredService<CardPaymentService>(),
                    "2" => provider.GetRequiredService<PayPalPaymentService>(),
                    _ => throw new ArgumentException("Invalid method")
                };
            });*/


            var provider = services.BuildServiceProvider();
            var orderService = provider.GetRequiredService<OrderService>();
            
            orderService.ProcessOrder(amount);
               
                
        }
    }
}
