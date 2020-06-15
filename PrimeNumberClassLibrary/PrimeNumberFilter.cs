using System;
using System.Collections.Generic;

namespace PrimeNumberClassLibrary
{
    public class PrimeNumberFilter
    {

        /* MethodName: IsUserInputValid
           Medhod Description: This method validates user input value is integer and its greater than 0.
           Input Parameter: Integer value (Prime number count to be displayed)
           Output Parameter: Booelan (input validation success or not)          
        */
        public Boolean IsUserInputValid(string primeNumbertobedisplayed)
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

        /* MethodName: IsPrimeNumber
           Medhod Description: This method verifies input ineger value is Prime number or not.
           Input Parameter: Integer value (Number to be verified)
           Output Parameter: Booelan (input number is Prime number or not)          
        */
        public bool IsPrimeNumber(int number)
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

        /* MethodName: GetFilteredPrimeNumber
           Medhod Description: Method filters prime numbers as per input parameter.
           Input Parameter: Integer value (Prime number count to be displayed)
           Output : List of Integer with Prime Numbers           
        */
        public List<int> GetFilteredPrimeNumber(int intPrimeNumberToBeDisplayed)
        {

            List<int> lstFilteredPrimeNumbers = new List<int>();
            int intPrimeNumberCount = 0;

            // SequenceNumber is increamental value from 0 
            int intNumberSequence = 0;

            /* Identify number of prime numbers as per user input and store in List*/
            while (intPrimeNumberCount < intPrimeNumberToBeDisplayed)
            {
                if (IsPrimeNumber(intNumberSequence))
                {
                    lstFilteredPrimeNumbers.Add(intNumberSequence);
                    intPrimeNumberCount++;
                }
                intNumberSequence++;
            }
            return lstFilteredPrimeNumbers;
        }
    }
}
