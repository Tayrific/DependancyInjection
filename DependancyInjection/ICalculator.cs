using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependancyInjection
{
    internal interface ICalculator
    {
        public int Add(int a, int b);
        public float Divide(int a, int b);
    }
}
