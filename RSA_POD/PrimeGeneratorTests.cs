using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RSA_POD
{
    [TestFixture]
    public class PrimeGeneratorTests
    {
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void getLargestPrime_throwsExceptionWhenPassingTooLowValue(int range)
        {
            Assert.Throws(typeof(Exception), 
                delegate()
            {
                PrimeGenerator.getLargestPrime(range);
            });
        }

        [TestCase(2, 2)]
        [TestCase(60, 59)]
        [TestCase(1000, 997)]
        public void getLargestPrime_returnProperValues(int range, int result)
        {
            Assert.AreEqual(PrimeGenerator.getLargestPrime(range), result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(2)]
        public void getRelativePrime_throwsExceptionWhenPassingTooLowValue(int value)
        {
            Assert.Throws(typeof(Exception),
                delegate()
                {
                    PrimeGenerator.getRelativePrime(value);
                });
        }

        [TestCase(540, 7)]
        public void getRelativePrime_returnsProperValue(int value, int result)
        {
            Assert.AreEqual(result, PrimeGenerator.getRelativePrime(value));
        }
    }
}
