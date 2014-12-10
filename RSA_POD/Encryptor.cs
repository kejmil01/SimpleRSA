using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarlJohansen;

namespace RSA_POD
{
    public class Encryptor
    {
        public static List<BigInt> encrypt(Key publicKey, String data)
        {
            List<BigInt> values = new List<BigInt>(data.Length);
            for (int i = 0; i < data.Length; i++)
                values.Add(encrypt(publicKey, data[i]));
            return values;
        }

        public static BigInt encrypt(Key publicKey, char data)
        {
            return BigInt.ModPower((int)data, publicKey.key, publicKey.n);
        }
    }
}
