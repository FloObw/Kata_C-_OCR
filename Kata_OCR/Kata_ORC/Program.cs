using System;
using System.Collections;
using System.Collections.Generic;

namespace Kata_OCR
{
    class Program
    {
     
        static void Main(string[] args)
        {
            string file = @"..\..\SampleData\sample.txt";
            
            System.IO.StreamReader sReader = new System.IO.StreamReader(file);


            string fileLine;
            int lineCounter = 0;
            var combinedNumber = new Dictionary<int, string>() ;
            int accountNumberLength = 9;

            while((fileLine = sReader.ReadLine()) != null)
            {
                    
                if(fileLine.Length > 0){
                    //If is new Line create a Account number
                    if (lineCounter == 0)
                    {
                        AccountNumber accountNumber = new AccountNumber();
                    }
                   
                    //replace \n\r
                    fileLine = fileLine.Replace(System.Environment.NewLine, string.Empty);
                    
                    //split line into parts
                    var result = new String[accountNumberLength];

                    Console.WriteLine(fileLine);
                    for (var i = 0; i < accountNumberLength ; i++)
                    {
                        result[i] = fileLine.Substring(i * 3, 3);
                    }

                    foreach (string word in result)
                    {
                        Console.WriteLine(word);
                    }
                    //Console.WriteLine(fileLine + lineCounter);
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

    }
}
