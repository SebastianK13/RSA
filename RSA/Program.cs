using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {

            for(int i = 0; i< 200;i++)
            {
                RSAController controller = new RSAController();
                controller.Controller();
            }

            Console.ReadKey();
        }
    }
}
