using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAN
{
    /// <summary>
    /// 
    /// </summary>
    public class IBANnumber
    {
        public bool hasIbanLength (string iban)
        {
            if (iban.Length == 0 || iban.Length > 34)
                return false;

            string LeanderCode = iban.Substring(0, 2);
            string Pruefsumme = iban.Substring(2, 2);
            string BLZ_Konto = iban.Substring(4);
            int zahlencode;

        
            if (!LeanderCode.All(c => Char.IsLetter(c)))
                return false;

            if (!Pruefsumme.All(c => Char.IsNumber(c)))
                return false;

            if (!BLZ_Konto.All(c => Char.IsNumber(c)))
                return false;

            char[] zeichen = LeanderCode.ToCharArray();
            
            
           //Gibt mir die Position der einzelnen Zeichen an (+1) 
            for (int i = 0; i < zeichen.Length; i++) 
            {
              
                
                // Die Zeichen werden übergeben an i
                zahlencode =  zeichen[i]  - 64 + 9;
            } 
                     

                   string zwischenwert = BLZ_Konto +  Pruefsumme + LeanderCode  ;
                   string Modulus = (zwischenwert);
                   


           }
        private int Modulo(string sModulus, int iTeiler)
        {
            

        }
    }     
}


