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

        private List<string> possibleAccountNumbers = new List<string>();
    
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
            return this.number; 
        }

        public void prepareNumber()
        {
            foreach (Digit digit in this.orgData)
            {
                int number;
                if (digit.TryGetNumber(out  number))
                {
                    this.number += number.ToString();
                }
                else
                {
                    this.number += '?';
                }
                
            }
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
        }

        public void check()
        {

            foreach (Digit digit in this.orgData)
            {
                int number;
                if (digit.TryGetNumber(out number) == false)
                {
                    this.isreadable = false;
                }
            }
            this.checkIsValidChecksum(this.number);
        }

        public void checkIsValidChecksum(string accountNumber)
        {            
            string numberAsString = accountNumber;
            int[] numberArray = numberAsString.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            int checksumAdd = 0;
            int tempCounter = numberArray.Length;
            for (int i = tempCounter; i > 0; i--)
            {
                int tempNumber = numberArray[tempCounter - i];
                checksumAdd += i * tempNumber;
            }

            //Check modulo %11 
            if ((checksumAdd % 11) == 0)
            {
                this.isValidChecksum = true;               
            }           
        }


        public Boolean getIsValidChecksum ()
        {
            return this.isValidChecksum;
        }

        public Digit getDigitByIndex(int index)
        {
            return this.orgData[index];
        }

        public Digit[] getOrgData ()
        {
            return this.orgData;
        }

        public List <string> getPossibleAccountNumbers()
        {
            return this.possibleAccountNumbers;
        }

        public void addPossibleRefactoredNumber(string toTestAccountnumber)
        {
            this.possibleAccountNumbers.Add(toTestAccountnumber);
            this.isValidChecksum = true;         
        }
    }
}
