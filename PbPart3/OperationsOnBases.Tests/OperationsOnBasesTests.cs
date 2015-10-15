using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationsOnBases;

namespace OperationsOnBases.Tests
{
    [TestClass]
    public class OperationsOnBasesTests
    {
        [TestMethod]
        public void TransformDecimalNumberToBaseTwo()
        {
            int decimalNumber = 12;
            int baseNumber = 2;
            byte[] expectedNumber = new byte[] { 1, 1, 0, 0 };

            byte[] convertedNumber = OperationsOnBases.ConvertADecimalNumberIntoAnotherBase(decimalNumber, baseNumber);

            CollectionAssert.AreEqual(expectedNumber, convertedNumber);
        }

        [TestMethod]
        public void VerifyTransformationOfaNumberFromADifferentBaseIntoDecimal()
        {
            byte[] number = { 1, 1, 1 };
            int baseNumber = 2;
            double expectedNumber = 7;

            double decimalNumber = OperationsOnBases.ConvertToDecimalNumber(number, baseNumber);

            Assert.AreEqual(expectedNumber, decimalNumber);
        }

        [TestMethod]
        public void VerifyTransformationOfaNumberFromADifferentBaseIntoDecimal2()
        {
            byte[] number = { 1, 1};
            int baseNumber = 2;
            double expectedNumber = 3;

            double decimalNumber = OperationsOnBases.ConvertToDecimalNumber(number, baseNumber);

            Assert.AreEqual(expectedNumber, decimalNumber);
        }

        [TestMethod]
        public void VerifyTransformationOfaNumberFromADifferentBaseIntoDecimal3()
        {
            byte[] number = { 1, 0 };
            int baseNumber = 2;
            double expectedNumber = 2;

            double decimalNumber = OperationsOnBases.ConvertToDecimalNumber(number, baseNumber);

            Assert.AreEqual(expectedNumber, decimalNumber);
        }

        [TestMethod]
        public void VerifyBitwiseNOToperatorForAnumber()
        {
            byte[] number = new byte[] { 1, 0, 0, 1, 1 };
            byte[] expectednumber = new byte[] { 0, 1, 1, 0, 0 };

            byte[] resultedNumber = OperationsOnBases.OperatorNot(number);

            CollectionAssert.AreEqual(expectednumber, resultedNumber);
        }

        [TestMethod]
        public void VerifyBitwiseANDoperatorFornumbers()
        {
            byte[] first = new byte[] { 1, 0, 0, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };
            byte[] expectednumber = new byte[] { 0, 0, 0, 1, 1 };

            byte[] resultedNumber = OperationsOnBases.OperatorAnd(first, second);

            CollectionAssert.AreEqual(expectednumber, resultedNumber);
        }

        [TestMethod]
        public void VerifyBitwiseORoperatorFornumbers()
        {
            byte[] first = new byte[] { 1, 0, 0, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };
            byte[] expectednumber = new byte[] { 1, 0, 1, 1, 1 };

            byte[] resultedNumber = OperationsOnBases.OperatorOR(first, second);

            CollectionAssert.AreEqual(expectednumber, resultedNumber);
        }

        [TestMethod]
        public void VerifyBitwiseXORoperatorFornumbers()
        {
            byte[] first = new byte[] { 1, 0, 0, 1, 1 };
            byte[] second = new byte[] { 0, 0, 1, 1, 1 };
            byte[] expectednumber = new byte[] { 1, 0, 1, 0, 0 };

            byte[] resultedNumber = OperationsOnBases.OperatorXOR(first, second);

            CollectionAssert.AreEqual(expectednumber, resultedNumber);
        }

        [TestMethod]
        public void VerifyBitwiseRightHandShiftOperatorFornumbers()
        {
            byte[] number = new byte[] { 1, 0, 0, 1, 1, 0, 1, 1 };
            int value = 2;
            byte[] expectednumber = new byte[] { 0, 0, 1, 0, 0, 1, 1, 0 };

            byte[] resultedNumber = OperationsOnBases.OperatorRightHandShift(number, value);

            CollectionAssert.AreEqual(expectednumber, resultedNumber);
        }

        [TestMethod]
        public void VerifyBitwiseLeftHandShiftOperatorFornumbers()
        {
            byte[] number = new byte[] { 1, 0, 0, 1, 1, 0, 1, 0 };
            int value = 2;
            byte[] expectednumber = new byte[] { 0, 1, 1, 0, 1, 0, 0, 0 };

            byte[] resultedNumber = OperationsOnBases.OperatorLeftHandShift(number, value);

            CollectionAssert.AreEqual(expectednumber, resultedNumber);
        }

        [TestMethod]
        public void VerifyLessThanOperatorFornumbers()
        {
            byte[] first = new byte[] { 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 1 };

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);

            Assert.AreEqual(true, firstNumberIsLess);
        }

        [TestMethod]
        public void VerifyLessThanOperatorFornumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1, 1};

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);

            Assert.AreEqual(true, firstNumberIsLess);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorFornumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };

            bool firstNumberIsGreater = OperationsOnBases.OperatorGreaterThan(first,second);

            Assert.AreEqual(true, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorFornumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 1 };

            bool firstNumberIsGreater = OperationsOnBases.OperatorGreaterThan(first, second);

            Assert.AreEqual(false, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorFornumbers3()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool firstNumberIsGreater = OperationsOnBases.OperatorGreaterThan(first, second);

            Assert.AreEqual(true, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyEqualOperatorFornumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool areEqual = OperationsOnBases.OperatorEqual(first, second);
            
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void VerifyEqualOperatorFornumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1};
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool areEqual = OperationsOnBases.OperatorEqual(first, second);

            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void VerifyEqualOperatorFornumbers3()
        {
            byte[] first = new byte[] { 1, 1, 1 ,1};
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool areEqual = OperationsOnBases.OperatorEqual(first, second);

            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void VerifyNotEqualOperatorFornumbers()
        {

            byte[] first = new byte[] { 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1};

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);
            bool secondNumberIsLess = OperationsOnBases.OperatorLessThan(second, first);

            bool areEqual = false;

            if ((firstNumberIsLess == false) & (secondNumberIsLess == false))
                areEqual = true;

            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void VerifyAdditionBetweenTwonumbers()
        {
            byte[] first = new byte[] { 1, 0, 1, 1 };
            byte[] second = new byte[] { 1, 0, 1, 1 };
            byte[] expectedSum = new byte[] { 1, 0, 1, 1, 0 };

            byte[] sum = OperationsOnBases.OperationAddition(first, second);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifyAdditionBetweenTwonumbers2()
        {
            byte[] first = new byte[] { 1, 0, 1, 1 };
            byte[] second = new byte[] {  1, 1 };
            byte[] expectedSum = new byte[] { 1, 1, 1, 0 };

            byte[] sum = OperationsOnBases.OperationAddition(first, second);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifySubstractionBetweenTwonumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 0, 1, 0 };
            byte[] expectedresult = new byte[] { 0, 1, 0, 1 };

            byte[] result = OperationsOnBases.OperationSubstraction(first, second);

            CollectionAssert.AreEqual(expectedresult, result);
        }

        [TestMethod]
        public void VerifySubstractionBetweenTwonumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 0, 1, 0 };
            byte[] expectedresult = new byte[] { 1, 0, 1, 0, 0 };

            byte[] result = OperationsOnBases.OperationSubstraction(first, second);

            CollectionAssert.AreEqual(expectedresult, result);
        }

        [TestMethod]
        public void VerifyOperationSubstractionBetweenTwonumbers3()
        {
            byte[] first = new byte[] { 1, 1, 0 };
            byte[] second = new byte[] { 1, 1 };
            byte[] expectedResult = new byte[] { 0, 1, 1};

            byte[] result = OperationsOnBases.OperationSubstraction(first, second);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void VerifyOperationSubstractionBetweenTwonumbers4()
        {
            byte[] first = new byte[] { 1, 0, 0, 0 };
            byte[] second = new byte[] { 1, 0 };
            byte[] expectedResult = new byte[] { 0, 1, 1, 0 };

            byte[] result = OperationsOnBases.OperationSubstraction(first, second);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 0, 1, 0 };
            byte[] expectedResult = new byte[] { 1, 0, 0, 1, 0, 1, 1, 0, 0 };

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1};
            byte[] second = new byte[] { 1, 0 };
            byte[] expectedResult = new byte[] {1, 1, 1, 0 };

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers3()
        {
            byte[] first = new byte[] { 1, 0, 0, 1 };
            byte[] second = new byte[] { 1, 1 , 0};
            byte[] expectedResult = new byte[] { 1, 1, 0, 1, 1, 0 };

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyDivisionBetweenTwonumbers()
        {
            byte[] first = new byte[] { 1, 0, 1, 0 };
            byte[] second = new byte[] { 1, 0 };
            byte[] expectedResult = new byte[] { 1, 0, 1 };

            byte[] division = OperationsOnBases.OperationDivision(first, second);

            CollectionAssert.AreEqual(expectedResult, division);
        }
    }
}
