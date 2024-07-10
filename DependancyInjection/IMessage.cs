using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjection
{
    internal interface IMessage
    {
        public string SendMessage(string mess);
    }
}
