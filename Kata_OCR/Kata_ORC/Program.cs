using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata_OCR
{
    class Program
    {
     
        static void Main(string[] args)
        {
            string file = @"\\192.168.10.2\Nas-Home\Software\Allgemein\Visual Studio\Visual Studio 2012\Kata_OCR\Kata_ORC\SampleData\sample.txt";
            
            System.IO.StreamReader sReader = new System.IO.StreamReader(file);


            string fileLine;
            int lineCounter = 0;
            var combinedNumber = new Dictionary<int, string>() ;
            
            while((fileLine = sReader.ReadLine()) != null)
            {
                    
                if(fileLine.Length > 0){
                    if (lineCounter == 0)
                    {
                        AccountNumber accountNumber = new AccountNumber();
                    }
                    Console.WriteLine(fileLine + lineCounter);
                    lineCounter++;
                }
                else{
                    
                    lineCounter = 0;
                }
             
            }
            Console.WriteLine(fileLine);                 
            sReader.Close();
            Console.Read();
        }



        public static string fileLine { get; set; }
    }
}
