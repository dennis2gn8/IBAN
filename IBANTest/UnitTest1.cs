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
        public void IsValidDE()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String Pruefsumme;
            Pruefsumme = "DE10550604170000082716";
            bool result;
            result = IBANnumber.IsValid(Pruefsumme);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidPL()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String Pruefsumme;
            Pruefsumme = "PL65109017370000000967";
            bool result;
            result = IBANnumber.IsValid(Pruefsumme);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsValidDK()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String Pruefsumme;
            Pruefsumme = "DK3456789012345678";
            bool result;
            result = IBANnumber.IsValid(Pruefsumme);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetDEBLZ()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "DE10550604170000082716";
            String result;
            result = IBANnumber.GetBLZ(iban);
            Assert.AreEqual(result, "55060417");
       
        }

        [TestMethod]
        public void TestGetDEBLZNOT()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "DE1055060417000023213213082716";
            String result;
            result = IBANnumber.GetBLZ(iban);
            Assert.AreNotEqual(result, "55060417");
       
         }

        [TestMethod]
        public void TestGetDEKonto()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "DE10550604170000082716";
            String result;
            result = IBANnumber.GetKonto(iban);
            Assert.AreEqual(result, "0000082716");
       
        }

        [TestMethod]
        public void TestGetDEKontoNot()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "DE1055060417000023213213082716";
            String result;
            result = IBANnumber.GetKonto(iban);
            Assert.AreNotEqual(result, "0000082716");
        }

        [TestMethod]
        public void TestGetPLBLZ()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "PL37109024020000000610000434";
            String result;
            result = IBANnumber.GetBLZ(iban);
            Assert.AreEqual(result, "10902402");
        }

        [TestMethod]
        public void TestGetNotPLBLZ()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "PL37109024020655000000610000434";
            String result;
            result = IBANnumber.GetBLZ(iban);
            Assert.AreNotEqual(result, "10902402");
            
         }

        [TestMethod]
        public void TestGetPLKonto()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "PL37109024020000000610000434";
            String result;
            result = IBANnumber.GetKonto(iban);
            Assert.AreEqual(result,"0000000610000434");
        }

        [TestMethod]
        public void TestGetCZBLZ()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            String iban;
            iban = "CZ6508000000192000145399";
            String result;
            result = IBANnumber.GetBLZ(iban);
            Assert.AreEqual(result, "0800");
        }

        [TestMethod]
        public void TestGetNoTCZBLZ()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
            
            String iban;
            iban = "CZ65034253458000000192000145399";
            String result;
            result = IBANnumber.GetBLZ(iban);
            Assert.AreNotEqual(result, "0800");
        }

        [TestMethod]
        public void TestGetCZKonto()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
          
            String iban;
            iban = "CZ6508000000192000145399";
            String result;
            result = IBANnumber.GetKonto(iban);
            Assert.AreEqual(result, "00192000145399");
        }
        
        [TestMethod]
        public void TestGetNotKonto()
        {
            //ich instanziiere hier eine Klasse und übergebe die  einer neuen  Klasse
          
            String iban;
            iban = "CZ650342534580sadasda00000192000145399";
            String result;
            result = IBANnumber.GetKonto(iban);
            Assert.AreNotEqual(result,"0000192000145399");
        }

        [TestMethod]
        public void TestGenerateGermanIban()
        {
            String expectedIban ="DE10550604170000082716";
            String givenBlz ="55060417";
            String givenKtoNr="82716";
            String result;
            result = IBANnumber.GenerateDeIban(givenBlz, givenKtoNr);
            Assert.AreEqual(result, expectedIban);
        }        
    }
}  

    
