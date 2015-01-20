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
        public void IsValid2()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            IBANnumber numberclass = new IBANnumber();
            String Pruefsumme;
            Pruefsumme = "PL65109017370000000967";
            bool result;
            result = numberclass.IsValid(Pruefsumme);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValid3()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            IBANnumber numberclass = new IBANnumber();
            String Pruefsumme;
            Pruefsumme = "DK3456789012345678";
            bool result;
            result = numberclass.IsValid(Pruefsumme);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetBLZ()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            IBANnumber numberclass = new IBANnumber();
            String iban;
            iban = "DK3456789012345678";
            String result;
            result = numberclass.GetBLZ(iban);
            Assert.AreSame()
        }
        //forget programming, PLAY SMITE INSTEAD (Proginator)
    }
}  

    
