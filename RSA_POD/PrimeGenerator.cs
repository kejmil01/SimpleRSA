using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_POD
{
    public class PrimeGenerator
    {
        const int startingRange = 10;

        public static int getLargestPrime(int range)
        {
            if (range < 2)
                throw new Exception("Range has to be greater than or equal to 2");
            return getLargestPrimeMethod(range);
        }

        private static int getLargestPrimeMethod(int range)
        {
            bool[] tab = getFilledSieve(range);
            return findLargestPrime(tab, range);
        }

        private static int findLargestPrime(bool[] tab, int range)
        {
            for(int i = range; i >= 2; i --)
            {
                if (tab[i] == false)
                    return i;
            }
            return 2;
        }

        /// <summary>
        /// Return smallest prime that common divisor with passed value equals to 1.
        /// </summary>
        /// <param name="value">Base value.</param>
        /// <returns>Smallest prime that common divisor with passed value equals to 1</returns>
        public static int getRelativePrime(int value)
        {
            if (value <= 2)
                throw new Exception("Value has to be greater than 2.");
            return getRelativePrimeMethod(value);
        }

        private static int getRelativePrimeMethod(int value)
        {
            int range = startingRange;
            bool[] tab = getFilledSieve(range);       
            int startingPosition = 2;

            while(true)
            {
                int prime = getRelativePrimeFromArray(tab, startingPosition, range, value);
                if (prime != -1)
                    return prime;
                else
                {
                    startingPosition = range;
                    int newRange = range + startingRange;
                    tab = extendSieve(tab, range, newRange);
                    range = newRange;
                }
            }
        }

        private static int getRelativePrimeFromArray(bool[] tab, int startingPosition, int range, int value)
        {
            for(int i = startingPosition; i <= range; i++)
            {
                if(tab[i] == false)
                {
                    if((value % i) != 0)
                        return i;
                }
            }
            return -1;
        }

        private static bool[] getFilledSieve(int range)
        {
            bool[] tab = new bool[range + 1];
            fillSieve(tab, range);
            return tab;
        }

        private static bool[] extendSieve(bool[] tab, int range, int desiredRange)
        {
            bool[] newTab = new bool[desiredRange + 1];
            Array.Copy(tab, newTab, range);
            fillSieve(newTab, desiredRange);
            return newTab;
        }

        private static void fillSieve(bool[] tab, int range)
        {
            for (int i = 2; i * i <= range; i++)
            {
                if (tab[i] == true)
                {
                    continue;
                }
                for (int j = 2 * i; j <= range; j += i)
                {
                    tab[j] = true;
                }
            }
        }
    }
}
