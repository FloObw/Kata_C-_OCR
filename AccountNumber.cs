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

        private string number;
        
        private List <string> possibleAccountNumbers;
    
        public string[] possibleReplacer = new string [6] {
            " _ ",
            " _|",
            "|_ ",
            "|_|",
            "| |",
            "  |"
        };
        /*
         * Return combined digits in account number
         * 
         * */
        public string getNumber()
        {
            foreach(Digit digit in this.orgData){
                this.number = number +  digit.getAsNumber();
            }
            return this.number; 
        }

        public Boolean isReadable()
        {
            return this.isreadable;
        }


        public Array getAccountNumberAsArray()
        {
            return this.orgData;
        }

        public void addDigit(int position , Digit digit)
        {
            this.orgData[position] = digit;
            digit.getAsNumber();
        }

        public void checkDigit()
        {
            foreach (Digit digit in this.orgData)
            {
                digit.getAsNumber();
                if (digit.getReadableState() == false)
                {
                    this.isreadable = false;
                }
            }
        }

        public void checkIsValidChecksum()
        {
            
        }

        public Digit getDigitByIndex(int index)
        {
            return this.orgData[index];
        }

        public Digit[] getOrgData ()
        {
            return this.orgData;
        }
    }
}
