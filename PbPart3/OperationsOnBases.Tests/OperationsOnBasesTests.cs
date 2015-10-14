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
        public void VerifyBitwiseNOToperatorForABinaryNumber()
        {
            byte[] binaryNumber = new byte[] { 1, 0, 0, 1, 1 };
            byte[] expectedBinaryNumber = new byte[] { 0, 1, 1, 0, 0 };

            byte[] resultedBinaryNumber = OperationsOnBases.OperatorNot(binaryNumber);

            CollectionAssert.AreEqual(expectedBinaryNumber, resultedBinaryNumber);
        }

        [TestMethod]
        public void VerifyBitwiseANDoperatorForBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 0, 0, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };
            byte[] expectedBinaryNumber = new byte[] { 0, 0, 0, 1, 1 };

            byte[] resultedBinaryNumber = OperationsOnBases.OperatorAnd(first, second);

            CollectionAssert.AreEqual(expectedBinaryNumber, resultedBinaryNumber);
        }

        [TestMethod]
        public void VerifyBitwiseORoperatorForBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 0, 0, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };
            byte[] expectedBinaryNumber = new byte[] { 1, 0, 1, 1, 1 };

            byte[] resultedBinaryNumber = OperationsOnBases.OperatorOR(first, second);

            CollectionAssert.AreEqual(expectedBinaryNumber, resultedBinaryNumber);
        }

        [TestMethod]
        public void VerifyBitwiseXORoperatorForBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 0, 0, 1, 1 };
            byte[] second = new byte[] { 0, 0, 1, 1, 1 };
            byte[] expectedBinaryNumber = new byte[] { 1, 0, 1, 0, 0 };

            byte[] resultedBinaryNumber = OperationsOnBases.OperatorXOR(first, second);

            CollectionAssert.AreEqual(expectedBinaryNumber, resultedBinaryNumber);
        }

        [TestMethod]
        public void VerifyBitwiseRightHandShiftOperatorForBinaryNumbers()
        {
            byte[] binaryNumber = new byte[] { 1, 0, 0, 1, 1, 0, 1, 1 };
            int value = 2;
            byte[] expectedBinaryNumber = new byte[] { 0, 0, 1, 0, 0, 1, 1, 0 };

            byte[] resultedBinaryNumber = OperationsOnBases.OperatorRightHandShift(binaryNumber, value);

            CollectionAssert.AreEqual(expectedBinaryNumber, resultedBinaryNumber);
        }

        [TestMethod]
        public void VerifyBitwiseLeftHandShiftOperatorForBinaryNumbers()
        {
            byte[] binaryNumber = new byte[] { 1, 0, 0, 1, 1, 0, 1, 0 };
            int value = 2;
            byte[] expectedBinaryNumber = new byte[] { 0, 1, 1, 0, 1, 0, 0, 0 };

            byte[] resultedBinaryNumber = OperationsOnBases.OperatorLeftHandShift(binaryNumber, value);

            CollectionAssert.AreEqual(expectedBinaryNumber, resultedBinaryNumber);
        }

        [TestMethod]
        public void VerifyLessThanOperatorForBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1, 1 };

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);

            Assert.AreEqual(true, firstNumberIsLess);
        }

        [TestMethod]
        public void VerifyGreaterThanOperatorForBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 1 };
            byte[] second = new byte[] { 1, 1, 1 };

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);
            bool firstNumberIsGreater = !firstNumberIsLess;

            Assert.AreEqual(true, firstNumberIsGreater);
        }

        [TestMethod]
        public void VerifyEqualOperatorForBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 1, 1, 0 };
            byte[] second = new byte[] { 1, 1, 1, 0 };

            bool firstNumberIsLess = OperationsOnBases.OperatorLessThan(first, second);
            bool secondNumberIsLess = OperationsOnBases.OperatorLessThan(second, first);

            bool areEqual = false;

            if ((firstNumberIsLess == false) & (secondNumberIsLess == false))
                areEqual = true;
            
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void VerifyNotEqualOperatorForBinaryNumbers()
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
        public void VerifyAdditionBetweenTwoBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 0, 1, 1 };
            byte[] second = new byte[] { 1, 0, 1, 1 };
            byte[] expectedSum = new byte[] { 1, 0, 1, 1, 0 };

            byte[] sum = OperationsOnBases.OperationAddition(first, second);

            CollectionAssert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void VerifySubstractionBetweenTwoBinaryNumbers()
        {
            byte[] first = new byte[] { 1, 0, 1, 1 };
            byte[] second = new byte[] { 1, 0, 1, 1 };
            byte[] expectedSum = new byte[] { 0, 0, 0, 0 };

            byte[] sum = OperationsOnBases.OperationSubstraction(first, second);

            Assert.AreEqual(expectedSum, sum);
        }
    }
}
