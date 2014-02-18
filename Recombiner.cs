using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class Recombiner
    {
        private AccountNumber accountNumber = null;
         // constructor 
        public Recombiner(AccountNumber accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        [Obsolete("Functionality to implement")]
        public Boolean tryChangeAndEvaluate(out string state)
        {
            //get each number from accountnumber 
            foreach (Digit digit in this.accountNumber.getAccountNumberAsArray())                
            {
                //get each string from digit
                foreach (String numberpart in digit.getAsArray())
                {
                    //now start to change one char  and check if is valid checksum
                    
                   // Console.WriteLine(numberpart);
                }
            }
            state = " ILL";
            return true;

        } 

    }
}
