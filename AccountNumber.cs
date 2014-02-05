using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private character[] orgData = new character[9];

        public void addCharacter (character character)
        {
            int arrLength = this.orgData.Length;
            this.orgData[arrLength + 1] = character;
        }

        public character[] getOrgData ()
        {
            return this.orgData;
        }
    }
}
