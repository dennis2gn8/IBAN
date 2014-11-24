using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IBAN;

namespace IBANTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl;
            Zieferanzahl = "111111111111111111111111111111111";
            bool result;
            result = numberclass.Validate(Zieferanzahl);
            Assert.IsTrue(result);
            
        }

        [TestMethod]
        public void TestMethod2()     
        {   
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl1;
            Zieferanzahl1 = "";
            bool result;
            result = numberclass.Validate(Zieferanzahl1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl2;
            Zieferanzahl2 = "66666666666666666666666666666666677777777777777777777777777777777777777777777777777777777777777777777";
            bool result;
            result = numberclass.Validate(Zieferanzahl2);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestMethod4()
        {
            IBANnumber numberclass = new IBANnumber();
            String Zieferanzahl2;
            Zieferanzahl2 = "1234567890123456789012345678901234";
            bool result;
            result = numberclass.Validate(Zieferanzahl2);
            Assert.IsTrue(result);
        }
    }  
}
    
