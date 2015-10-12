using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasesOperations;

namespace Bases.Tests
{
    [TestClass]
    public class BasesTests
    {
        [TestMethod]
        public void TransformDecimalNumberToBaseTwo()
        {
            int decimalNumber = 12;
            int baseNumber = 2;
            byte[] expectedNumber = { 1, 0, 0 };

            byte[] convertedNumber = BasesOperations.Bases.ConvertADecimalNumberIntoAnotherBase(decimalNumber, baseNumber);

            Assert.AreEqual(expectedNumber, convertedNumber);
        }
    }
}
