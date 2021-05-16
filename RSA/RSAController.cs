using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class RSAController
    {
        private readonly AdditionalMethods additional;
        private ulong p;
        private ulong q;
        private ulong n;
        private ulong eulerFunction;
        private ulong e;
        private ulong d;
        public RSAController() =>
             additional = new AdditionalMethods();

        public void Controller()
        {
            additional.FindPQ(ref p, ref q);
            n = p * q;
            eulerFunction = (p - 1) * (q - 1);

            additional.SetE(ref e, eulerFunction);

        }

    }
}
