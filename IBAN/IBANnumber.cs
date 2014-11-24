using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAN
{
    public class IBANnumber
    {
        public bool Validate(string iban)
        {

            int length; 
            length= iban.Length;

            if (length == 0)          
            {
                return false;
            }
            else if (length < 35) 
            {
                return true;
            }

            return false;
        
        }
    }
}

