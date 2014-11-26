using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBAN
{
    /// <summary>
    /// f
    /// </summary>
    public class IBANnumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        public bool isValid(string iban)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public bool isLetter(string letter)
        {
            if (letter.StartsWith("DE"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeral"></param>
        /// <returns></returns>
        public bool isNumeral(string numeral)
        {
            string erg = numeral.Substring(2, 2);
            return erg.All(c => Char.IsNumber(c));
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool isNumber(string number)
        {
            string erg = number.Substring(4, 30);
            return erg.All(c => Char.IsNumber(c));
            
        }
    }
        
}


