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

        static Dictionary<string, int> hashtable;
        static Digit()
        {
            // Create and return new Hashtable.
            hashtable = new Dictionary<string,int>();
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

        public Dictionary<string,int> gethashtable()
        {            
            return hashtable;
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

        public Array getAsArray()
        {
            return this.digitAsArray;
        }

        public bool TryGetNumber(out int number)
        {
            string digitasNumber = this.getAsString();
            if (hashtable.ContainsKey(digitasNumber))
            {
                number = hashtable[digitasNumber];               
                return true;
            }
            else
            {
                number = -1;
                return false;
            }
        }
    }
}
