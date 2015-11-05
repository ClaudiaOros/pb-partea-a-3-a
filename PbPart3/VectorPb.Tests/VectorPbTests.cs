using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorPb;
using Vector;

namespace VectorPb.Tests
{
    [TestClass]
    public class VectorPbTests
    {
        [TestMethod]
        public void Verify_an_array_after_adding_a_new_element_No_Resizing_the_aray()
        {
            int count = 7;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, null };
            var expectedVector = new object[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            var vector = new Vector.VectorPb(obj,count);

            object elementToBeAdded = 9;
            var resultedVector = vector.Add(elementToBeAdded);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_adding_a_new_element_With_Resizing_the_array_of_8_elements()
        {
            int count = 8;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var expectedVector = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 ,null,null,null,null,null,null,null};
            var vector = new Vector.VectorPb(obj, count);

            object elementToBeAdded = 9;
            var resultedVector = vector.Add(elementToBeAdded);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }
    }
}
