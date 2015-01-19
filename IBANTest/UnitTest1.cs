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
        public void IsValid()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            IBANnumber numberclass = new IBANnumber();
            String Pruefsumme;
            Pruefsumme = "DE10550604170000082716";
            bool result;
            result = numberclass.IsValid(Pruefsumme);
            Assert.IsTrue(result);
        }
             [TestMethod]
        public void Umstellung()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            IBANnumber numberclass = new IBANnumber();
            String Pruefsumme;
            Pruefsumme = "AA111111111111111111111111111111122222222222222222222222222222222222222222222222222222222222222222";
            bool result;
            result = numberclass.IsValid(Pruefsumme);
            Assert.IsFalse(result);
        }
    }
}  

    
