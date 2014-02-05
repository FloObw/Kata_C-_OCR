using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata_OCR
{
    class AccountNumber
    {
        private Character[] orgData = new Character[9];

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
