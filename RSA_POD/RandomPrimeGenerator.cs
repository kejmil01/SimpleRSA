using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_POD
{
    class RandomPrimeGenerator
    {
        public static int generate(int minValue, int maxValue)
        {
            return generate(minValue, maxValue, new Random());
        }

        public static int generate(int minValue, int maxValue, Random random)
        {
            int result = -1;

            while (result < minValue || result > maxValue)
            {
                int value = random.Next(minValue, maxValue);
                result = PrimeGenerator.getLargestPrime(value);
            }

            return result;
        }
    }
}
