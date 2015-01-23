using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBAN;

namespace IBANConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 0)
            {
                Console.WriteLine("Keine argumente gegeben");
                Console.ReadKey();
                return;
            }

            string blz = args[0];
            string konto = args[1];
            string iban = IBANnumber.GenerateDeIban(blz, konto);

            Console.WriteLine(iban);
            Console.ReadLine();
        }
    }
}
