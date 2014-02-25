using System;
using System.Collections;
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


        public AccountNumber tryChangeAndEvaluate()
        {
            //get each number from accountnumber 
            int digitPosition = 0;
            foreach (Digit digit in this.accountNumber.getAccountNumberAsArray())                
            {
                //string from digit
                string digitasString = digit.getAsString();

                Boolean foundPossibleDigit = false;
                int nearestNumberInt = new int();

                //now start to change one char  and check if is valid checksum
                foreach (var hashDigit in digit.gethashtable())
                {
                    int equalsAmount = 0;
                    for (int i = 0; i < hashDigit.Key.Length; i++)
                    {
                        if (hashDigit.Key[i] == digitasString[i])
                        {
                            equalsAmount++;
                        }
                    }

                    if (equalsAmount == 8)
                    {
                        nearestNumberInt = hashDigit.Value;
                        foundPossibleDigit = true;
                    }                    
                }

                //if something found
                if (foundPossibleDigit)
                {
                    string toTestAccountnumber = this.accountNumber.getNumber();
                    
                    toTestAccountnumber = UtillityHelper.replaceAt(toTestAccountnumber, digitPosition, nearestNumberInt.ToString()[0]);

                    //try checksum of new accountnumber
                    this.accountNumber.checkIsValidChecksum(toTestAccountnumber);
                    if (this.accountNumber.isReadable() && this.accountNumber.getIsValidChecksum())
                    {
                        this.accountNumber.addPossibleRefactoredNumber(toTestAccountnumber);                        
                    }
                }
                digitPosition++; 
            }
            return this.accountNumber;
        }
    }
}
