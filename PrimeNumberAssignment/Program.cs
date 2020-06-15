using System;
using System.Collections.Generic;
using PrimeNumberClassLibrary;

namespace PrimeNumberAssignment
{
    public class Program
    {
        
        static List<int> lstFilteredPrimeNumbers = new List<int>();
        static PrimeNumberFilter objPrimeNumberFilter = new PrimeNumberFilter();

        static void Main(string[] args)
        {
            try
            {                
                Console.ForegroundColor = ConsoleColor.White;                
                string strTitle = "Input Prime number count to be displayed: ";
                Console.WriteLine(strTitle);
                Console.SetCursorPosition(strTitle.Length, Console.CursorTop - 1);
                string strPrimeNumberstobedisplayed = Console.ReadLine();

                // Validate input parameter
                if (objPrimeNumberFilter.IsUserInputValid(strPrimeNumberstobedisplayed))
                {
                    PrimeNumberOutput(Convert.ToInt16(strPrimeNumberstobedisplayed));
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

        /* MethodName: PrimeNumberOutput
           Medhod Description: Method filters prime numbers as per input parameter and displays table of every Prime Number
           Input Parameter: Integer value (Prime number count to be displayed)
           Output : None          
        */
        public static void PrimeNumberOutput(int intPrimeNumberToBeDisplayed)
        {
            string strPrimeNumbers = "Multiplication table of " + intPrimeNumberToBeDisplayed.ToString() + " Prime Numbers";

            Console.WriteLine();                
            Console.Write(strPrimeNumbers);
            Console.WriteLine();

            // Get Filtered Prime number as per user input
            lstFilteredPrimeNumbers = objPrimeNumberFilter.GetFilteredPrimeNumber(intPrimeNumberToBeDisplayed);
               
            // This code will display multiplication table of filtered Prime Number.
            int intPrimeNumber = 0;
               Console.WriteLine("{0} {1,5}", "Prime Number ", "Multiplacation Table");
               for (int i = 0; i <= lstFilteredPrimeNumbers.Count - 1; i++)
               {
                   intPrimeNumber = lstFilteredPrimeNumbers[i];                
                   Console.WriteLine("{0,-12} {1,5}", intPrimeNumber.ToString(), GetPrimeNumberTable(intPrimeNumber));
               }

               lstFilteredPrimeNumbers.Clear();
               Console.WriteLine();               
               Main(null);
        }
        

        /* MethodName: GetPrimeNumberTable
           Medhod Description: This method returns multiplication table of input Prime Number.
           Input Parameter: Integer value (Prime number)
           Output string : Space separated multiplication table of (input Prime number)          
        */
        private static string GetPrimeNumberTable(int intPrimeNumber)
        {
            string strPrimeNumberTable = "";                  

            for (int i = 0; i < lstFilteredPrimeNumbers.Count; i++)
            {
                strPrimeNumberTable = strPrimeNumberTable + " " + (intPrimeNumber * lstFilteredPrimeNumbers[i]).ToString();
            }            

            return strPrimeNumberTable;
        }
    }
}
