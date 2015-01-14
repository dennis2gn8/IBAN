using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBAN;
using System.Diagnostics;

namespace IBANTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// In diesem Beispiel wird die Zeichenlänge überprüft und ein "true" ausgegeben , wenn die Bedingung erfüllt ist.
        /// </summary>
        [TestMethod]
        public void hasIbanLength()
        {
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl;
            Zieferanzahl = "AAx1111111111111111111111111111111";
            bool result;
            result = numberclass.hasIbanLength(Zieferanzahl);
            Assert.IsTrue(result);
            
        }

        /// <summary>
        /// In diesem Beispiel wird die Zeichenlänge überprüft und ein "false" ausgegeben , wenn die Bedingung erfüllt ist.
        /// </summary>
        [TestMethod]
        public void ÜberprüfungDerZeichenMengeNull()     
        {   
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl1;
            Zieferanzahl1 = "";
            bool result;
            result = numberclass.hasIbanLength(Zieferanzahl1);
            Assert.IsFalse(result);
        }
        /// <summary>
        /// In diesem Beispiel wird die Zeichenlänge überprüft und ein "false" ausgegeben , wenn die Bedingung erfüllt ist.
        /// </summary>
        [TestMethod]
        public void ÜberPrüfungdDerLängeTrue()
        {
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl2;
            Zieferanzahl2 = "AZ6666666666666666666666666666666677777777777777777777777777777777777777777777777777777777777777777777";
            bool result;
            result = numberclass.hasIbanLength(Zieferanzahl2);
            Assert.IsFalse(result);

        }

        /// <summary>
        /// In diesem Beispiel wird die Zeichenlänge überprüft und ein "true" ausgegeben , wenn die Bedingung erfüllt ist(+35).
        /// </summary>
        [TestMethod]
        public void ÜberprüfungAufLängeFalse()
        {
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl2;
            Zieferanzahl2 = "AA34567890123456789012345678901234";
            bool result;
            result = numberclass.hasIbanLength(Zieferanzahl2);
            Assert.IsTrue(result);
        }
    }
}  

    
