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
        public void VerifyLessThanOperatorTest1()
        {
            byte[] first = new byte[] { 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 1 };

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);

            Assert.AreEqual(true, firstNumberIsLess);
        }

        [TestMethod]
        public void VerifyLessThanOperatorTest2()
        {
            byte[] first = new byte[] { 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1, 1};

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);

            Assert.AreEqual(true, firstNumberIsLess);
        }

        [TestMethod]
        public void VerifyLessThanOperatorTest3()
        {
            byte[] first = new byte[] { 0, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1, 1 };

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);

            Assert.AreEqual(true, firstNumberIsLess);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorTest1()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };

            bool firstNumberIsGreater = OperationsOnBases.OperatorGreaterThan(first,second);

            Assert.AreEqual(true, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorTest2()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 1 };

            bool firstNumberIsGreater = OperationsOnBases.OperatorGreaterThan(first, second);

            Assert.AreEqual(false, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorTest3()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool firstNumberIsGreater = OperationsOnBases.OperatorGreaterThan(first, second);

            Assert.AreEqual(true, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyEqualOperatorTest1()
        {
            byte[] first = new byte[] { 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool areEqual = OperationsOnBases.OperatorEqual(first, second);
            
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void VerifyEqualOperatorTest2()
        {
            byte[] first = new byte[] { 1, 1, 1};
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool areEqual = OperationsOnBases.OperatorEqual(first, second);

            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void VerifyEqualOperatorTest3()
        {
            byte[] first = new byte[] { 1, 1, 1 ,1};
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool areEqual = OperationsOnBases.OperatorEqual(first, second);

            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void VerifyNotEqualOperator()
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
        public void VerifyAdditionBetweenTwonumbersTest1()
        {
            byte[] first = new byte[] { 1, 0, 1, 1 };
            byte[] second = new byte[] { 1, 0, 1, 1 };
            byte[] expectedSum = new byte[] { 1, 0, 1, 1, 0 };
            int baseNumber = 2;

            byte[] sum = OperationsOnBases.OperationAddition(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifyAdditionBetweenTwonumbersTest2()
        {
            byte[] first = new byte[] { 1, 0, 1, 1 };
            byte[] second = new byte[] {  1, 1 };
            byte[] expectedSum = new byte[] { 1, 1, 1, 0 };
            int baseNumber = 2;

            byte[] sum = OperationsOnBases.OperationAddition(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifyAdditionBetweenTwonumbersTest3()
        {
            byte[] first = new byte[] { 1, 7, 3, 1 };
            byte[] second = new byte[] { 5, 1 };
            byte[] expectedSum = new byte[] { 2, 0, 0, 2 };
            int baseNumber = 8;

            byte[] sum = OperationsOnBases.OperationAddition(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifyAdditionBetweenTwonumbersTest4()
        {
            byte[] first = new byte[] {7, 0, 6, 1 };
            byte[] second = new byte[] {7, 1, 1 };
            byte[] expectedSum = new byte[] { 7, 7, 7, 2 };
            int baseNumber = 8;

            byte[] sum = OperationsOnBases.OperationAddition(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifySubstractionBetweenTwonumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 0, 1, 0 };
            byte[] expectedresult = new byte[] { 0, 1, 0, 1 };
            int baseNumber = 2;

            byte[] result = OperationsOnBases.OperationSubstraction(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedresult, result);
        }

        [TestMethod]
        public void VerifySubstractionBetweenTwonumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 0, 1, 0 };
            byte[] expectedresult = new byte[] { 1, 0, 1, 0, 0 };
            int baseNumber = 2;

            byte[] result = OperationsOnBases.OperationSubstraction(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedresult, result);
        }

        [TestMethod]
        public void VerifyOperationSubstractionBetweenTwonumbers3()
        {
            byte[] first = new byte[] { 1, 1, 0 };
            byte[] second = new byte[] { 1, 1 };
            byte[] expectedResult = new byte[] { 0, 1, 1};
            int baseNumber = 2;

            byte[] result = OperationsOnBases.OperationSubstraction(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void VerifyOperationSubstractionBetweenTwonumbers4()
        {
            byte[] first = new byte[] { 1, 0, 0, 0 };
            byte[] second = new byte[] { 1, 0 };
            byte[] expectedResult = new byte[] { 0, 1, 1, 0 };
            int baseNumber = 2;

            byte[] result = OperationsOnBases.OperationSubstraction(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void VerifyOperationSubstractionBetweenTwonumbers5()
        {
            byte[] first = new byte[] { 7, 6, 5 };
            byte[] second = new byte[] { 4, 3 };
            byte[] expectedResult = new byte[] { 7, 2, 2 };
            int baseNumber = 8;

            byte[] result = OperationsOnBases.OperationSubstraction(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 0, 1, 0 };
            byte[] expectedResult = new byte[] { 1, 0, 0, 1, 0, 1, 1, 0, 0 };
            int baseNumber = 2;

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers2()
        {
            byte[] first = new byte[] { 1, 1, 1};
            byte[] second = new byte[] { 1, 0 };
            byte[] expectedResult = new byte[] {1, 1, 1, 0 };
            int baseNumber = 2;

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers3()
        {
            byte[] first = new byte[] { 1, 0, 0, 1 };
            byte[] second = new byte[] { 1, 1 , 0};
            byte[] expectedResult = new byte[] { 1, 1, 0, 1, 1, 0 };
            int baseNumber = 2;

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyMultiplicationBetweenTwonumbers4()
        {
            byte[] first = new byte[] { 7, 2, 5 };
            byte[] second = new byte[] { 4, 2 };
            byte[] expectedResult = new byte[] { 3, 7, 1, 1, 2 };
            int baseNumber = 8;

            byte[] multiplication = OperationsOnBases.OperationMultiply(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, multiplication);
        }

        [TestMethod]
        public void VerifyDivisionBetweenTwonumbersTest1()
        {
            byte[] first = new byte[] { 1, 0, 1, 0 };
            byte[] second = new byte[] { 1, 0 };
            byte[] expectedResult = new byte[] { 1, 0, 1 };
            int baseNumber = 2;

            byte[] division = OperationsOnBases.OperationDivision(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, division);
        }

        [TestMethod]
        public void VerifyDivisionBetweenTwonumbersTest2()
        {
            byte[] first = new byte[] { 7, 2 };
            byte[] second = new byte[] { 5 };
            byte[] expectedResult = new byte[] { 1, 3 };
            int baseNumber = 8;

            byte[] division = OperationsOnBases.OperationDivision(first, second, baseNumber);

            CollectionAssert.AreEqual(expectedResult, division);
        }
    }
}
