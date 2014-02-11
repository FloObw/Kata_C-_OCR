using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Kata_OCR
{
    class Digit
    {
        private string[] digitAsArray = new string[3];

        private string number;

        private Boolean isReadable = true;

        static Hashtable hashtable;
        public Digit()
        {
            // Create and return new Hashtable.
            hashtable = new Hashtable();
            hashtable.Add("     |  |", 1);
            hashtable.Add(" _  _||_ ", 2);
            hashtable.Add(" _  _| _|", 3);
            hashtable.Add("   |_|  |", 4);
            hashtable.Add(" _ |_  _|", 5);
            hashtable.Add(" _ |_ |_|", 6);
            hashtable.Add(" _   |  |", 7);
            hashtable.Add(" _ |_||_|", 8);
            hashtable.Add(" _ |_| _|", 9);
            hashtable.Add(" _ | ||_|", 0);
        }
        
        public void addString(int lineCounter, string subpart)
        {
            this.digitAsArray[lineCounter] = subpart;
        }

        public string getAsString()
        {
            string val = "";
            foreach( string temp in this.digitAsArray)
            {
                val = val + temp;
            }
            return val;
        }

        public Boolean getReadableState()
        {
            return this.isReadable;
        }

        public string getAsNumber()
        {
            string digitasNumber = this.getAsString();
            if (hashtable.ContainsKey(digitasNumber))
            {
                this.number = hashtable[digitasNumber].ToString();
                this.isReadable = true;
            }
            else
            {
                this.number = "?";
                this.isReadable = false;
            }
            return this.number;
        }    
    }
}
