using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace IBAN
{
    /// <summary>
    /// 
    /// </summary>
    public class IBANnumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iban">iban (erwatet ein  parameter von typ string mit der bezeichnung iban)</param>
        /// <returns> boolean true if everything is OK, else false</returns>
        public bool IsValid(string iban)
        {
            if (iban.Length == 0)
            {
                return false;
            }

            if (iban.Length > 34)
            {
                return false;
            }

           // string KontrollZ = iban.Substring()
            // Ein Array mit der Größe 2
            var zahlencode = new[] { 1, 2 };

            if (!iban.Substring(0, 2).All(c => Char.IsLetter(c)))
            {
                return false;
            }

            if (!iban.Substring(2).All(c => Char.IsNumber(c)))
            {
                return false;
            }
            
            if (iban.StartsWith("DE") && iban.Length != 22)
            {
                return false;
            }
            else if (iban.StartsWith("PL")&& iban.Length != 28|| iban.StartsWith ("CZ") && iban.Length != 24)

                return false;

            char[] zeichen = iban.Substring(0, 2).ToCharArray();

            //Gibt mir die Position der einzelnen Zeichen an (+1) 
            for (int i = 0; i < zeichen.Length; i++)
            {
                // Die Zeichen werden übergeben an i
                zahlencode[i] = zeichen[i] - 64 + 9;
            }

            // Ich erstelle eine Variable egdy in welcher ich aus einen Zahlenarray einen String verkette.
            string egdy = string.Concat(zahlencode);
            //Hier erste ich Variable mit den Namen resultString der mir die Buchstaben durch Zahlen resetzt.
            string resultString = iban.Replace(iban.Substring(0, 2), egdy);
            //In diesen Codeabschnitt findet eine Umstellung statt.
            resultString = resultString.Substring(6) + resultString.Substring(0, 6);

            //In diesen Abschnitt wer eine Variable erstellt die den Parameter "zwischenwert" enthält 
            BigInteger erg = BigInteger.Parse(resultString) % 97;
            
            // Hier wurde überprüft ob das Ergebnis 1 ergibt.
            if (erg > 1 || erg < 1)
            {
                return false;
            }

            
            return true;                
        }

        public string GetBLZ(string iban)
        {
            Boolean Valid = IsValid(iban);

            if (Valid == true)
            {
                if (iban.StartsWith("DE"))
                {
                    return iban.Substring(4,8);
                }
                else if (iban.StartsWith("PL"))
                {
                    return iban.Substring(4,8);
                }
                else if (iban.StartsWith("CZ"))
                    return iban.Substring(4,4);
            
            }
            
                
                return string.Empty;


        }


        public string GetKonto(string iban)
        {
            Boolean Valid = IsValid(iban);

            if (Valid == true)
            {
                if (iban.StartsWith("DE"))
                {
                    return iban.Substring(12);
                }
                else if (iban.StartsWith("PL"))
                {
                    return iban.Substring(12);
                }
                else if (iban.StartsWith("CZ"))
                    return iban.Substring(10);
            
            }


            


            }



        }
           
    }
}


