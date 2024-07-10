using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjection
{
    internal class Log : ILog
    {
        public void LogMess(string message)
        {
            Console.WriteLine($"Logging message : {message}");
            //Log message in file
            Serilog.Log.Information(message);
        }

        public void Error(string message)
        {
            Serilog.Log.Error(message);
        }
    }
}
