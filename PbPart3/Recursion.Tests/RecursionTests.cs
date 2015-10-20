using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            char characterToBeReplaced = 'A';
            string expectedString = "pere";

            string resultedString = Recursion.ReplaceACharWithAString(characterToBeReplaced, firstString,  secondString);

            Assert.AreEqual(expectedString, resultedString);
        }

        [TestMethod]
        public void Verify_The_Replacement_Of_A_Character_From_A_String_With_Another_String_ANA_ARE_MERE()
        {
            string firstString = "ana are mere";
            string secondString = "xyz";
            char characterToBeReplaced = 'a';
            string expectedString = "xyznxyz xyzre mere";

            string resultedString = Recursion.ReplaceACharWithAString(characterToBeReplaced, firstString,  secondString);

            Assert.AreEqual(expectedString, resultedString);
        }

        [TestMethod]
        public void Verify_Operation1_On_Calculator()
        {
            string[] input = new string[] { "+", "3", "4" };
            double expectedResult = 7;
            var index = 0;

            double result = Recursion.Calculator(input, ref index );

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Verify_Operation2_On_Calculator()
        {
            string[] input = new string [] {"*","/","*","+","56","45","45","3","0.75"};
            double expectedResult = 1136.25;
            var index = 0;

            double result = Recursion.Calculator(input,ref index);

            Assert.AreEqual(expectedResult, result);
        }

       
     }
}
 