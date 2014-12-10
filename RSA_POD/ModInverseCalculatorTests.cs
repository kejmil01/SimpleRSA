using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RSA_POD
{
    [TestFixture]
    public class ModInverseCalculatorTests
    {
        [TestCase(7, 540, 463)]
        [TestCase(7, 5, 3)]
        public void calculate_returnsProperValue(int a, int b, int result)
        {
            Assert.AreEqual(result, ModInverseCalculator.calculate(a, b));
        }

    }
}
