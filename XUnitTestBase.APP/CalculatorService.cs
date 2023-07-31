using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestBase.APP
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(int a, int b)
        {
            if (a + b < 0)
            {
                return 0;
            }

            return a + b;
        }

        public int Mul(int a, int b)
        {
            if (a == 0)
            {
                throw new Exception("a = 0 olamaz!");
            }

            return a * b;
        }
    }
}
