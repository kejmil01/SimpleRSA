using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RSA_POD
{
    [TestFixture]
    public class KeyGeneratorTests
    {
        [TestCase(0, 0)]
        [TestCase(-1, 3)]
        [TestCase(4, 0)]
        public void generate_throwsExceptionWhenPassingTooLowValue(int value1, int value2)
        {
            Assert.Throws(typeof(Exception), delegate()
            {
                KeyGenerator.generate(value1, value2);
            });
        }

        [Test]
        public void generate_returnsProperValue()
        {
            Key privateKey = new Key
            {
                key = 463,
                n = 589
            };
            Key publicKey = new Key
            {
                key = 7,
                n = 589
            };
            int p = 31;
            int q = 19;

            PrivatePublicKey keys = KeyGenerator.generate(p, q);

            Assert.AreEqual(keys.PrivateKey.key, privateKey.key);
            Assert.AreEqual(keys.PrivateKey.n, privateKey.n);

            Assert.AreEqual(keys.PublicKey.key, publicKey.key);
            Assert.AreEqual(keys.PublicKey.n, publicKey.n);
        }
    }
}
