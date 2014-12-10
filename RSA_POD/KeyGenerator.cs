using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_POD
{
    public class KeyGenerator
    {
        public static PrivatePublicKey generate(int p, int q)
        {
            if (p < 2)
                throw new Exception("'p' has to be greater than or equal to 2.");
            if (q < 2)
                throw new Exception("'q' has to be greater than or equal to 2.");

            return generateMethod(p, q);

        }

        private static PrivatePublicKey generateMethod(int p, int q)
        {
            int n = p * q;
            int phi = (p - 1) * (q - 1);
            int e = PrimeGenerator.getRelativePrime(phi);
            int d = ModInverseCalculator.calculate(e, phi);

            return new PrivatePublicKey(e, d, n);
        }
    }
}
