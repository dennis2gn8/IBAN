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
               
            //ich brauche ein paar string parameters, und evtl. einen parameter
            string LeanderCode = iban.Substring(0, 2);
            //Eine definierte Variable mit den parameter Pruefsumme , die eine Wert enthält
            string Pruefsumme = iban.Substring(2, 2);
            //Eine definierte Variable mit den parameter Pruefsumme , die eine Wert enthält
            string BLZ_Konto = iban.Substring(4);
            //Hier wird die Bankleitzahl und Kontonummer extrahiert.

            // Ein Array mit der Größe 2
            var zahlencode = new[] { 1, 2 };

            if (!Pruefsumme.All(c => Char.IsNumber(c)))
            {
                return false;
            }

            if (!BLZ_Konto.All(c => Char.IsNumber(c)))
            {
                return false;
            }

            if (!LeanderCode.All(c => Char.IsLetter(c)))
            {
                return false;
            }

            if (LeanderCode.StartsWith("DE") && iban.Length != 22)
            {
                return false;
            }           

            char[] zeichen = LeanderCode.ToCharArray();

            //Gibt mir die Position der einzelnen Zeichen an (+1) 
            for (int i = 0; i < zeichen.Length; i++)
            {
                // Die Zeichen werden übergeben an i
                zahlencode[i] = zeichen[i] - 64 + 9;
            }

            // Ich erstelle eine Variable egdy in welcher ich aus einen Zahlenarray einen String verkette.
            string egdy = string.Concat(zahlencode);
            //Hier erste ich Variable mit den Namen resultString der mir die Buchstaben durch Zahlen resetzt.
            string resultString = iban.Replace(LeanderCode, egdy);
            //In diesen Codeabschnitt findet eine Umstellung statt.
            resultString = resultString.Substring(6) + resultString.Substring(0, 6);

            //In diesen Abschnitt wer eine Variable erstellt die den Parameter "zwischenwert" enthält 
            decimal erg = Convert.ToDecimal(decimal.Parse(resultString) % 97);
            
            /// Hier wurde überprüft ob das Ergebnis 1 ergibt.
            if (erg > 1 || erg < 1)
            {
                return false;
            }

            
            return true;                
        }

        public string GetBLZ(string iban)
        {
            Boolean bla = IsValid(iban);
            String blz = string.Empty;
            if (bla == true) 
            {
                

            }
            return blz;
        }
           
    }
}


