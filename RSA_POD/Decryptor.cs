using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarlJohansen;

namespace RSA_POD
{
    public class Decryptor
    {
        public static String decrypt(List<BigInt> data, Key privateKey)
        {
            String decryptedData = "";
            foreach (BigInt i in data)
                decryptedData += decrypt(i, privateKey);
            return decryptedData;
        }

        public static String decrypt(BigInt data, Key privateKey)
        {
            BigInt m = BigInt.ModPower(data, privateKey.key, privateKey.n);

            String s = m.ToString();
            int d = Int16.Parse(s);
            String c = "";
            c += (char)d;

            return c;
        }
    }
}
