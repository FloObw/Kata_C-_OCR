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

        static Hashtable GetHashtable()
        {
            // Create and return new Hashtable.
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Area", 1);
            hashtable.Add("Perimeter", 2);
            hashtable.Add("Mortgage", 3);
            hashtable.Add("Area", 4);
            hashtable.Add("Perimeter", 5);
            hashtable.Add("Mortgage", 6);
            hashtable.Add("Area", 7);
            hashtable.Add("Perimeter", 8);
            hashtable.Add("Mortgage", 9);
            hashtable.Add("Mortgage", 0);
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

        public int getAsNumber()
        {
            return this.getAsString().GetHashCode();
        }
    }
}
