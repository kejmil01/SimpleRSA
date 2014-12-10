using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_POD
{
    public class ModInverseCalculator
    {
        private static Tuple<int, Tuple<int, int>> extendedEuclid(int a, int b)
        {
            int x = 1, y = 0;
            int xLast = 0, yLast = 1;
            int q, r, m, n;
            while (a != 0)
            {
                q = b / a;
                r = b % a;
                m = xLast - q * x;
                n = yLast - q * y;
                xLast = x; yLast = y;
                x = m; y = n;
                b = a; a = r;
            }
            return new Tuple<int, Tuple<int, int>>(b, new Tuple<int, int>(xLast, yLast));
        }

        public static int calculate(int a, int m)
        {
            return (extendedEuclid(a, m).Item2.Item1 + m) % m;
        }
    }
}
