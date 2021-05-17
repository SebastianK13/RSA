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
        private string message;
        private int p;
        private int q;
        private int n;
        private int phi;
        private int e;
        private System.Numerics.BigInteger d;
        private string EncryptedMessage;
        private string DecryptedMessage;
        private string DecryptedMessageText;
        public RSAController() =>
             additional = new AdditionalMethods();

        public void Controller()
        {
            message = "KOT";
            additional.FindPQ(ref p, ref q);
            n = p * q;
            phi = (p - 1) * (q - 1);
            additional.SetE(ref e, phi, n);
            additional.FindDValue(ref d, phi, e);
            EncryptedMessage = additional.MessageEncryption(message, e ,n);
            DecryptedMessage = additional.MessageDecryption(d, n, ref DecryptedMessageText);

            Console.WriteLine("P: {0}\nQ: {1}\nN: {2}\nPhi: {3}\nE: {4}\nD: {5}\n" +
                "PublicKey({6}, {7})\nPrivateKey({8},{9})\nMessage: {10}\nEncryptedMessage: {11}\n" +
                "Decrypted Message Numeric: {12}\nDecryption Message Text: {13}\n", 
                p, q, phi, n, e, d, e, n, d, n, message, EncryptedMessage, DecryptedMessage, DecryptedMessageText);

        }

    }
}