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
    public static class IBANnumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iban">iban (erwatet ein  parameter von typ string mit der bezeichnung iban)</param>
        /// <returns> boolean true if everything is OK, else false</returns>
        public static bool IsValid(string iban)
        {
            //Hier wird die minimallänge deviniert 
            if (iban.Length == 0)
            {
                return false;
            }
            // In diesen Abschnitt wird die Maxmallänge definiert.
            if (iban.Length > 34)
            {
                return false;
            }

           // string KontrollZ = iban.Substring()
            // Ein Array mit der Größe 2
            var zahlencode = new[] { 1, 2 };
            //Dieser Abschnitt wird Position festgelegt ,außerdem sagen wir hier das die ersten 2 Zeichen nur Buchstaben sind.
            if (!iban.Substring(0, 2).All(c => Char.IsLetter(c)))
            {
                return false;
            }
            //Hier wird festgelegt das die Zeichen ab Position 3 nur Nummern sein dürfen.
            if (!iban.Substring(2).All(c => Char.IsNumber(c)))
            {
                return false;
            }
            //Wenn der Startindex mit DE anfängt ist die länge auf 22 festgelegt
            if (iban.StartsWith("DE") && iban.Length != 22)
            {
                return false;
            }
            //Falls die IBAN mit PL startet und die Länge nicht 28 ist oder  Fall die Länge mit CZ startet und nicht die Länge 24 ist , dann return false
            else if (iban.StartsWith("PL")&& iban.Length != 28|| iban.StartsWith ("CZ") && iban.Length != 24)

                return false;
            //Hier wird ein Zeichenarray erstellt der die stellen von 0/2 durchgeht
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
        // In Dieser Funktion wir die BLZ extrahiert.
        public static string GetBLZ(string iban)
        {
            Boolean Valid = IsValid(iban);
            //Fall die Valide ist gib ein True aus 
            if (Valid == true)
            {
                if (iban.StartsWith("DE"))
                {
                    //Hier wird die länge der Blz anhand der Position festgelegt
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

        //In Dieser Funktion wir die BLZ extrahiert.
        public static string GetKonto(string iban)
        {
         //Bolean wird erstellt und die Funktion IsValid wird überprüft.
            Boolean Valid = IsValid(iban);
            //Wenn die Funktion true  ist extrahiere die Blz von, DE, Pl, CZ.
            if (Valid == true)
            {
                //Wenn iban mit "De" startet.
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
            return string.Empty;
        }

        //In dieser Funktion wird eine valide ibannummer Generiert 
        public static string GenerateDeIban(string givenBlz, string givenKtoNr)
        {
            string iban;
            string Leandercode ="DE";
        
            
            var zahlencode = new[] { 1, 2 };
            char[] zeichen = Leandercode.ToCharArray();
           
           
            for (int i = 0; i < zeichen.Length; i++)
            {                
                zahlencode[i] = zeichen[i] - 64 + 9;
               
            }
            //Hier wird geprüft ob die Länge der KontoNr 10 enthält , falls nicht wird immer eine null dazuaddiert. 
            while (givenKtoNr.Length < 10)
            {
                givenKtoNr = "0" + givenKtoNr;
            }
            //In dieser Variable werden 2 Strings zusammen verkettet und an die Zwischensumme überwiesen.
            string zwischensumme = string.Concat(zahlencode) + "00";

            iban = givenBlz + givenKtoNr + zwischensumme;

            BigInteger zwischenwert = BigInteger.Parse(iban) % 97;

            
            BigInteger erg = 98 - zwischenwert;
            string Prüfsumme = Convert.ToString(erg);
            
            while (Prüfsumme.Length < 2)
            {
                Prüfsumme = "0" + Prüfsumme;
            }
            
            string IBAN = Leandercode + Prüfsumme + givenBlz + givenKtoNr;
            return IBAN;
            

        }
    }
}


 