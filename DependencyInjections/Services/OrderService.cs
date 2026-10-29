using DependencyInjections.Interfaces;
using System;

namespace DependencyInjections.Services
{
    internal class OrderService
    {
 
        private readonly IPaymentService _paymentService;
        private readonly ILoggerService _loggerService;

        public OrderService(IPaymentService paymentService, ILoggerService loggerService)
        {
            _paymentService = paymentService;
            _loggerService = loggerService;
        }

        public void ProcessOrder(decimal amount)
        {
            _loggerService.Log($"Processing order: {amount}");

            _paymentService.Pay(amount);

            _loggerService.Log("Payment completed successfully.");
        }
    }
}