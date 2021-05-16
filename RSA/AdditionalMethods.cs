using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    public class AdditionalMethods
    {
        public void FindPQ(ref ulong p, ref ulong q)
        {
            bool success = false;
            do
            {
                p = (ulong)GeneratePrimeNumber();
                q = (ulong)GeneratePrimeNumber();

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
                randomNum = rand.Next(100000, 999999);

                success = isPrimeNum(randomNum);

            } while (!success);

            return randomNum;
        }

        private bool isPrimeNum(int randomNum)
        {
            int dividerCount = 0;
            for(int i = 2; i < randomNum; i++)
            {
                if (randomNum % i == 0)
                    dividerCount++;

                if (dividerCount > 0)
                    return false;

            }
            return true;
        }
        public void SetE(ref ulong e, ulong eulerF)
        {
            bool success = false;
            do
            {
                e = (ulong)FindOdd();
                if (isGCD(e, eulerF))
                    success = true;

            } while (!success);
        }
        private bool isGCD(ulong e, ulong eulerF)//Greater Common Divisor (NWD)
        {
            ulong tempF = eulerF;
            ulong tempS = e;
            ulong temp = 0;
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
        private int FindOdd()
        {
            bool success = false;
            int odd = 0;
            do
            {
                Random random = new Random();
                odd = random.Next(3, Int32.MaxValue);
                if (odd % 2 != 0)
                {
                    success = true;
                    return odd;
                }
                
            } while (!success);
            return 0;
        }

    }
}
