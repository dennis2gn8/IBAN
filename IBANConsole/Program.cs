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
            Console.WriteLine("Geben sie hier ihre BLZ ein: ");
            string blz = Console.ReadLine();
            Console.WriteLine("Geben sie hier ihre Kontonummer ein: ");

            string konto = Console.ReadLine();
            string iban = IBANnumber.GenerateDeIban(blz,konto);
            
            Console.WriteLine(iban);
            Console.ReadKey();
        }
    }
}
