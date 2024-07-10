using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjection
{
    internal class Message : IMessage
    {
        public string SendMessage(string mess)
        {
            Console.WriteLine($"Message is : {mess}");
            return "Your message has been sent!!";
        }
    }

}
