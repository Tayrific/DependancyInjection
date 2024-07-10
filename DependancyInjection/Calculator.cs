using DependancyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Calculator : ICalculator
    {
        private readonly ILog _log;
        private readonly IMessage _mess;
        public Calculator(ILog log, IMessage message)
        {
            _log = log;
            _mess = message;
        }


        int ICalculator.Add(int a, int b)
        {
            int sum = (a + b);
            string str = _mess.SendMessage($"{a} and {b} have been added succefully to {sum}");

            _log.LogMess($"{a} added to {b} = {sum}");
            return sum;

        }

        float ICalculator.Divide(int a, int b)
        {
            if (b == 0)
            {
                _log.Error("Division by zero attempted.");
                return float.NaN;

            }
            else
            {
                float div = (float)a / (float)b;
                string str2 = _mess.SendMessage($"succefully divided qoutient is: {div}");
                Console.WriteLine($"Divide done : {str2}");

                _log.LogMess($"{a} divided by {b} = {div}");
                return div;

            }
            

        }
    }
}
