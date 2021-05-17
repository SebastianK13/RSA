using ExtendedNumerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class AdditionalMethods
    {
        private List<string> alphabet = new List<string> {
            "a","b","c","d","e","f","g","h","i","j","k","l",
            "m","n","o","p","q","r","s","t","u","v","w","x",
            "y","z"
        };
        private List<int> indexes =
            new List<int>();
        public void FindPQ(ref int p, ref int q)
        {
            bool success = false;
            do
            {
                p = GeneratePrimeNumber();
                q = GeneratePrimeNumber();

                if (p != q)
                    success = true;

            } while (!success);

        }
        int GeneratePrimeNumber()
        {
            bool success = false;
            int randomNum = 0;
            do
            {
                Random rand = new Random();
                randomNum = rand.Next(101, 501);

                success = isPrimeNum(randomNum);

            } while (!success);

            return randomNum;
        }

        private bool isPrimeNum(int randomNum)
        {
            int dividerCount = 0;
            for (int i = 2; i < randomNum; i++)
            {
                if (randomNum % i == 0)
                    dividerCount++;

                if (dividerCount > 0)
                    return false;

            }
            return true;
        }
        public void SetE(ref int e, int phi, int n)
        {
            bool success = false;
            do
            {
                e = FindOdd(n);
                if (isGCD(e, phi))
                    success = true;

            } while (!success);
        }
        private bool isGCD(int e, int phi)//Greater Common Divisor (NWD)
        {
            int tempF = phi;
            int tempS = e;
            int temp = 0;
            bool success = false;

            do
            {
                if (tempF % tempS == 0)
                {
                    if (temp == 0)
                        e = tempS;
                    else if (temp == 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    temp = tempF % tempS;
                    tempF = tempS;
                    tempS = temp;
                }

            } while (!success);

            return false;
        }
        private int FindOdd(int n)
        {
            bool success = false;
            int odd = 0;
            do
            {
                Random random = new Random();
                odd = random.Next(3, n-1);
                if (odd % 2 != 0)
                {
                    success = true;
                    return odd;
                }

            } while (!success);
            return 0;
        }
        public void FindDValue(ref System.Numerics.BigInteger d, System.Numerics.BigInteger phi, System.Numerics.BigInteger e)
        {
            bool success = false;
            ulong i = 0;
            do
            {
                i++;
                string currValue = ((decimal)(1 + (i * phi)) / (decimal)e).ToString();
                bool isInteger = System.Numerics.BigInteger.TryParse(currValue, out d);
                if (isInteger)
                {
                    d = ((1 + (i * phi)) / e);
                    success = true;
                }

            } while (!success);

        }
        public string MessageEncryption(string message, int e, int n)
        {
            string eMsg = "";
            for (int i = 0; i < message.Length; i++)
            {
                string curr = message[i].ToString().ToLower();
                var temp = System.Numerics.BigInteger.Pow((alphabet.IndexOf(curr) + 1), e);
                int y = (int)(temp % n);
                indexes.Add(y);
                eMsg += y;
            }
            return eMsg;
        }
        public string MessageDecryption(System.Numerics.BigInteger d, int n, ref string DecryptedMessageText)
        {
            string dMsg = "";
            for (int i = 0; i < indexes.Count(); i++)
            {
                var temp = System.Numerics.BigInteger.Pow(indexes[i], (int)d);
                int y = (int)(temp % n);
                dMsg += y;
                DecryptedMessageText += alphabet[y - 1];
            }
            return dMsg;
        }

    }
}