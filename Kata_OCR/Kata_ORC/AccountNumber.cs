using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private Character[] orgData = new Character[9];
        
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


        public void addCharacter (Character character)
        {
            int arrLength = this.orgData.Length;
            this.orgData[arrLength + 1] = character;
        }

        public Character[] getOrgData ()
        {
            return this.orgData;
        }
    }
}
