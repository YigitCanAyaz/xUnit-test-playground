using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestBase.APP
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            if (a + b < 0)
            {
                return 0;
            }

            return a + b;
        }
    }
}
