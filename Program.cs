using System;
using System.Collections.Generic;

namespace Kata_OCR
{
    class Program
    {
        private static AccountNumber accountNumber;    
 
        static void Main(string[] args)
        {
            string filename = "sample.txt";
            string folder = System.IO.Directory.GetCurrentDirectory();
            System.IO.StreamReader sReader = new System.IO.StreamReader(folder+"..\\..\\..\\SampleData\\" + filename);
            
            string fileLine;
            int lineCounter = 0;
            var combinedNumber = new Dictionary<int, string>() ;

            int accountNumberLength = 9;
            while((fileLine = sReader.ReadLine()) != null )
            {
                if(fileLine.Length > 0){
                    //replace \n\r
                    fileLine = fileLine.Replace(System.Environment.NewLine, string.Empty);
                    if (lineCounter == 0)
                    {
                        accountNumber = new AccountNumber();
                    }
                     // loop beginns from end to assign correct
                    for (var i = 0 ; i < accountNumberLength; i++)
                    {
                        //split line into parts
                        string subpart = fileLine.Substring(i * 3, 3);

                        //On first line create digit and ad it to accountnumber
                        if (lineCounter == 0)
                        {
                            Digit digit = new Digit();
                            digit.addString(lineCounter, subpart);                           
                            accountNumber.addDigit(i, digit);
                        }
                        else
                        {
                            accountNumber.getDigitByIndex(i).addString(lineCounter,subpart);
                        }
                    }
                    lineCounter++;
                }
                else{   
                    lineCounter = 0;
                    string additionalState = "";
                    //Begin to evaluate accountNumber 
                    accountNumber.prepareNumber();
                    accountNumber.check();
                    String number = accountNumber.getNumber();
                    if (accountNumber.isReadable() == false || accountNumber.getIsValidChecksum() == false)
                    {
                        Recombiner possibleAccount = new Recombiner(accountNumber);
                        accountNumber = possibleAccount.tryChangeAndEvaluate();
                        //If now is readable Accountnumber
                        if (accountNumber.isReadable() &&  accountNumber.getIsValidChecksum())
                        {
                            //Set The number whith new Data
                            number = accountNumber.getPossibleAccountNumbers()[0];
                            //remove first
                            accountNumber.getPossibleAccountNumbers().RemoveAt(0);
                            additionalState = " AMB " + string.Join(" ", accountNumber.getPossibleAccountNumbers().ToArray());
                        }
                        else if(accountNumber.isReadable() == false){
                            additionalState = " ILL";
                        }
                        else if (accountNumber.getIsValidChecksum() == false)
                        {
                            additionalState = " ERR";
                        }
                    }                    
                    Console.WriteLine(number + additionalState);
                }
            }
            Console.WriteLine(fileLine);                 
            sReader.Close();
            Console.Read();
        }

    }
}
