using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_POD
{
    public class PrivatePublicKey
    {
        public Key PrivateKey;
        public Key PublicKey;

        public PrivatePublicKey(Key PrivateKey, Key PublicKey)
        {
            this.PrivateKey = PrivateKey;
            this.PublicKey = PublicKey;
        }

        public PrivatePublicKey(int e, int d, int n)
        {
            this.PublicKey = new Key();
            this.PublicKey.key = e;
            this.PublicKey.n = n;

            this.PrivateKey = new Key();
            this.PrivateKey.key = d;
            this.PrivateKey.n = n;
        }
    }
}
