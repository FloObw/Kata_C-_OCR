using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private Digit[] orgData = new Digit[9];
        
        private Boolean isValidChecksum = false;

        private Boolean isreadable = true;
    
        private string accountNumber = "";
    
        private List <string> accountNumberAsArray ;
    
        private List <string> possibleAccountNumbers;
    
        public string[] possibleReplacer = new string [6] {
            " _ ",
            " _|",
            "|_ ",
            "|_|",
            "| |",
            "  |"
        };

        public string getNumber()
        {
            string number = "";
            foreach(Digit digit in this.orgData){
                number = number + digit.getAsNumber();
            }
            return number; 
        }

        public void addDigit(int position , Digit digit)
        {
            this.orgData[position] = digit;
        }

        public Digit getDigitByIndex(int index)
        {
            return this.orgData[index];
        }

        public Digit[] getOrgData ()
        {
            return this.orgData;
        }

        internal void add(object p)
        {
            throw new NotImplementedException();
        }
    }
}
