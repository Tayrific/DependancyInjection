using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjection
{
    internal interface ILog
    {
        public void LogMess(string message);
        public void Error(string message);
    }
}
