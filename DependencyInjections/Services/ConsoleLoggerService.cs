using DependencyInjections.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjections.Services
{
    internal class ConsoleLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");  
        }
    }
}
