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
            if (args.Length != 2)
            {
                Console.WriteLine("Ihre BLZ oder ihre Kontonummer ist nicht gültig oder entspricht nicht dem gültigen Format.");
                return;
            }
           
            string blz = args[0];

            if (blz.Length != 8 || !blz.All(c => Char.IsNumber(c)))
            {
                Console.Write("Ihre BLZ muss 8 Zeichen lang sein und dem gültigen Format entsprechen.");
                return;
            } 
           
            string konto = args[1];
            if (konto.Length == 0 || !konto.All(c => Char.IsNumber(c)))
            {
                Console.Write("Ihre Kontonummer entspricht nicht dem gültigen Format.");
                return;
            }

            string iban = IBANnumber.GenerateDeIban(blz, konto);
            
            Console.WriteLine(iban);
        }
    }
}