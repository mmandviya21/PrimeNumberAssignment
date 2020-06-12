using System;
using System.Collections.Generic;

namespace PrimeNumberAssignment
{
    class Program
    {
        
        static List<int> lstFilteredPrimeNumbers = new List<int>();

        static List<int> lstFirstTenPrimeNumbers = new List<int>();


        static void Main(string[] args)
        {
            try
            {
                
                string strTitle = "Prime numbers to be displayed: ";
                Console.WriteLine(strTitle);
                Console.SetCursorPosition(strTitle.Length, Console.CursorTop - 1);
                string strPrimeNumberstobedisplayed = Console.ReadLine();

                if (IsUserInputValid(strPrimeNumberstobedisplayed))
                {
                    FilterPrimeNumbers(Convert.ToInt16(strPrimeNumberstobedisplayed));
                }
                else
                {
                    Console.WriteLine("\n " + strPrimeNumberstobedisplayed + " is not valid input. Input should be whole number and greater than 0.");
                    Console.WriteLine();
                    Main(null);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /*This method filters prime numbers as per input parameter and displays table of every filtered Prime Number */
        public static void FilterPrimeNumbers(int intPrimeNumberToBeDisplayed)
        {
            
            string strPrimeNumbers = "First " + intPrimeNumberToBeDisplayed.ToString() + " prime numbers: ";
                        
                int intPrimeNumberCount = 0;
                
                // SequenceNumber is increamental value from 0 
                int intNumberSequence = 0;
                
                /*Identify number of prime numbers as per user input and store in stringbuilder object*/
                while (intPrimeNumberCount < intPrimeNumberToBeDisplayed)
                {
                    if (IsPrime(intNumberSequence))
                    {
                        strPrimeNumbers += " " + intNumberSequence;
                        lstFilteredPrimeNumbers.Add(intNumberSequence);
                        lstFirstTenPrimeNumbers.Add(intNumberSequence);
                    intPrimeNumberCount++;
                    }
                    intNumberSequence++;
                }

                if(lstFirstTenPrimeNumbers.Count != 10)
                {
                   while (lstFirstTenPrimeNumbers.Count < 10)
                   {
                       if (IsPrime(intNumberSequence))
                       {
                         lstFirstTenPrimeNumbers.Add(intNumberSequence);                        
                       }
                    intNumberSequence++;
                   }
                 }
                
               Console.WriteLine();
               Console.Write(strPrimeNumbers);
               Console.WriteLine();
               Console.Write("Table of above prime numbers");
               Console.WriteLine();

            DisplayResult(lstFilteredPrimeNumbers);
               lstFilteredPrimeNumbers.Clear();
               Console.WriteLine();
               Console.WriteLine();                            
               Main(null);
        }

        /* This method displays table of each Prime Number passed in input integer List */
        private static void DisplayResult(List<int> lstFilteredPrimeNumbers)
        {

            int intPrimeNumber = 0;
            string strPrimeNumberTable = "";

            for (int i = 0; i <= lstFilteredPrimeNumbers.Count - 1; i++)
            {
                intPrimeNumber = lstFilteredPrimeNumbers[i];
                strPrimeNumberTable = intPrimeNumber + " | " + GetPrimeNumberTable(intPrimeNumber);
                Console.WriteLine(strPrimeNumberTable);                
                strPrimeNumberTable = "";            }            
        }

        /* This method Populates table of PrimeNumber */
        private static string GetPrimeNumberTable(int intPrimeNumber)
        {
            string strPrimeNumberTable = "";

            //for (int i = 1; i <= 10; i++)
            //{
            //    strPrimeNumberTable = strPrimeNumberTable + " " + (intPrimeNumber * i).ToString();
            //}            

            for (int i = 0; i < lstFirstTenPrimeNumbers.Count; i++)
            {
                strPrimeNumberTable = strPrimeNumberTable + " " + (intPrimeNumber * lstFirstTenPrimeNumbers[i]).ToString();
            }
            

            return strPrimeNumberTable;
        }

        /*This method verifies input ineger value is Prime number or not.*/
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        /*This method validates input variable is integer and greater than 0.*/
        static Boolean IsUserInputValid(string primeNumbertobedisplayed)
        {
            Boolean blnResult = false;
            
            int intInputValue;
            
            if (Int32.TryParse(primeNumbertobedisplayed, out intInputValue))
            {                
                if (intInputValue > 0)
                {
                    blnResult = true;
                }
            }

            return blnResult;
        }
    }
}
