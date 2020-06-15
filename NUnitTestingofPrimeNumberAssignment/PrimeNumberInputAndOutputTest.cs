using NUnit.Framework;
using System.Collections.Generic;
using PrimeNumberClassLibrary;
using System;
namespace Tests
{
    public class PrimeNumberInputAndOutputTest
    {

        PrimeNumberFilter objPrimeNumberFilter = new PrimeNumberFilter();

        [TestCase("abc")]
        public void WhenUserInputisCharactor(string strUserInput)
        {
            Boolean blnResult = objPrimeNumberFilter.IsUserInputValid(strUserInput);
            Assert.AreEqual(false, blnResult);
        }

        [TestCase("0")]
        public void WhenUserInputis0(string strUserInput)
        {
            Boolean blnResult = objPrimeNumberFilter.IsUserInputValid(strUserInput);
            Assert.AreEqual(false, blnResult);
        }

        [TestCase("1")]
        public void WhenUserInputisValid(string strUserInput)
        {
            Boolean blnResult = objPrimeNumberFilter.IsUserInputValid(strUserInput);
            Assert.AreEqual(true, blnResult);
        }
       
        [TestCase(5)]
        public void WhenFilteredPrimeNumberCountisValid(int intUserInput)
        {
            List<int> lstFilteredPrimeNumberCount = objPrimeNumberFilter.GetFilteredPrimeNumber(intUserInput);
            Assert.AreEqual(intUserInput, lstFilteredPrimeNumberCount.Count);
        }

        [Test]
        public void WhenFirst3FilteredPrimeNumbersValid()
        {
            List<int> lstFilteredPrimeNumbers = objPrimeNumberFilter.GetFilteredPrimeNumber(3);
            string strFirst3PrimeNumbersActual = string.Join(",", lstFilteredPrimeNumbers);
            string strFirst3PrimeNumbersExpected = "2,3,5";
            Assert.AreEqual(strFirst3PrimeNumbersActual, strFirst3PrimeNumbersExpected);
        }

        [Test]
        public void WhenFirst10FilteredPrimeNumbersValid()
        {
            List<int> lstFilteredPrimeNumbers = objPrimeNumberFilter.GetFilteredPrimeNumber(10);
            string strFirst3PrimeNumbersActual = string.Join(",", lstFilteredPrimeNumbers);
            string strFirst3PrimeNumbersExpected = "2,3,5,7,11,13,17,19,23,29";
            Assert.AreEqual(strFirst3PrimeNumbersActual, strFirst3PrimeNumbersExpected);
        }

    }
}