using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recursion;

namespace Recursion.Tests
{
    [TestClass]
    public class RecursionTests
    {
        [TestMethod]
        public void Verify_Reverse_Of_String_ABCD()
        {
            string stringToBeReversed = "ABCD";
            string expectedString = "DCBA";

            var reverseString = Recursion.ReturnTheReverseString(stringToBeReversed);

            Assert.AreEqual(expectedString, reverseString);
        }

        [TestMethod]
        public void Verify_Reverse_Of_String_ANA_ARE_MERE_SI_PERE()
        {
            string stringToBeReversed = "ANA ARE MERE SI PERE";
            string expectedString = "EREP IS EREM ERA ANA";

            var reverseString = Recursion.ReturnTheReverseString(stringToBeReversed);

            Assert.AreEqual(expectedString, reverseString);
        }

        [TestMethod]
        public void Verify_The_Replacement_Of_A_Character_From_A_String_With_Another_String()
        {
            string firstString = "A";
            string secondString = "pere";
            int indexOfChar = 9;
            string expectedString = "pere";

            string resultedString = Recursion.ReplaceACharWithAString(indexOfChar, firstString, secondString);

            Assert.AreEqual(expectedString, resultedString);
        }

        [TestMethod]
        public void Verify_The_Replacement_Of_A_Character_From_A_String_With_Another_String_ANA_ARE_MERE()
        {
            string firstString = "ana are mere";
            string secondString = "pere";
            int indexOfChar = 9;
            string expectedString = "ana are pereere";

            string resultedString = Recursion.ReplaceACharWithAString(indexOfChar, firstString, secondString);

            Assert.AreEqual(expectedString, resultedString);
        }
    }
}
