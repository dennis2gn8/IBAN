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
            if (iban.Length == 0 || iban.Length > 34)
            {
                return false;
            }

            //ich brauche ein paar string parameters, und evtl. einen integer parameter
            string LeanderCode = iban.Substring(0, 2);
            //Eine definierte Variable mit den parameter Pruefsumme , die eine Wert enthält
            string Pruefsumme = iban.Substring(2, 2);
            //Eine definierte Variable mit den parameter Pruefsumme , die eine Wert enthält
            string BLZ_Konto = iban.Substring(4);
            // Ein Array mit der Größe 2
            var zahlencode = new [] { 1, 2};

            // Wenn der Ländercode nicht alle Zeichen Buchstaben sind , gib mir ein false
            if (!LeanderCode.All(c => Char.IsLetter(c)))
                return false;
            // Wenn der Ländercode nicht alle Zeichen nummeralisch sind , gib mir ein false
            if (!Pruefsumme.All(c => Char.IsNumber(c)))
                return false;
            // Wenn der Ländercode nicht alle Zeichen nummeralisch sind , gib mir ein false
            if (!BLZ_Konto.All(c => Char.IsNumber(c)))
                return false;
            //alphanumeric
            char[] zeichen = LeanderCode.ToCharArray();

            //Gibt mir die Position der einzelnen Zeichen an (+1) 
            for (int i = 0; i < zeichen.Length; i++)
            {
                // Die Zeichen werden übergeben an i
                zahlencode [i] = zeichen[i] - 64 + 9;
            }

            string resultString;
            resultString = Umstellung(iban);



            //frage, ich will doch den zahlencodezurück geben.. NEIN! Ich will wissen ob die übergebene IBAN valide ist!
            //aber ich habe auch false als potentielle rückwertausgabe.. 
            //welcher typ muss dann die methode haben?
            return true;
            //return zahlencode; DAS SOLL ICH ZURÜCK GEBEN...

        }

        public string Umstellung(string iban)
        {
            
            //eta huina delaet variable tipa string, i ne imeet nikakogo value
            string resultString;
            //zdes' ia daiu value tomu variable (resultstring). 
            //moi value sostoit iz chasti (substring) drugogo variable(iban)
            resultString = iban.Substring(7, 27);
            //zdes ia dobavliaiu k uzhe naznachenomu value eshio odnu chast' ot drugogo variable(iban)
            resultString += iban.Substring(0, 6);
            // ia vozrashaiu moi variable(resultstring)


            
            double zwischenwert = Convert.ToDouble(resultString);
            //Hier wird dem parameter "erg" der wert "zwischenwert" übergeben
            double erg = zwischenwert % 97;
            

            return resultString;
        }

        public bool Pruefwert(double erg)
        {
            if  (erg > 1 || erg < 1)
              return false;
      
             return true;
        }
       
    }
}


