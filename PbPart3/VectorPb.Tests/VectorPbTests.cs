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
            var vector = new Vector.VectorPb<object>(obj,count);

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
            var vector = new Vector.VectorPb<object>(obj, count);

            object elementToBeAdded = 9;
            var resultedVector = vector.Add(elementToBeAdded);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_adding_a_new_element_on_a_position_where_is_no_element()
        {
            int count = 7;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, null };
            var expectedVector = new object[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            var vector = new Vector.VectorPb<object>(obj, count);

            object elementToBeAdded = 9;
            int position = 7;

            var resultedVector = vector.Insert(position, elementToBeAdded);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_adding_a_new_element_on_a_position_where_is_an_element_without_resizing_array()
        {
            int count = 7;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, null };
            var expectedVector = new object[] { 1, 2, 3, 9, 4, 5, 6, 7 };
            var vector = new Vector.VectorPb<object>(obj, count);

            object elementToBeAdded = 9;
            int position = 3;

            var resultedVector = vector.Insert(position, elementToBeAdded);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_adding_a_new_element_on_a_position_where_is_an_element_with_resizing_array()
        {
            int count = 8;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var expectedVector = new object[] { 1, 2, 3, 9, 4, 5, 6, 7, 8, null, null, null, null, null, null, null };
            var vector = new Vector.VectorPb<object>(obj, count);

            object elementToBeAdded = 9;
            int position = 3;

            var resultedVector = vector.Insert(position, elementToBeAdded);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_removing_an_element_without_resizing_the_array()
        {
            int count = 7;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, null };
            var expectedVector = new object[] { 1, 2, 3, 5, 6, 7 ,null, null};
            var vector = new Vector.VectorPb<object>(obj, count);

            object elementToBeRemoved = 4;

            var resultedVector = vector.Remove(elementToBeRemoved);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_removing_an_element_with_resizing_the_array()
        {
            int count = 9;
            object[] obj = new object[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, null, null, null };
            var expectedVector = new object[8] { 1, 2, 3, 5, 6, 7, 8, 9 };
            var vector = new Vector.VectorPb<object>(obj, count);

            object elementToBeRemoved = 4;

            var resultedVector = vector.Remove(elementToBeRemoved);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_removing_an_element_on_a_certain_position_without_resizing_the_array()
        {
            int count = 7;
            object[] obj = new object[8] { 1, 2, 3, 4, 5, 6, 7, null };
            var expectedVector = new object[] { 1, 2, 3, 5, 6, 7, null, null };
            var vector = new Vector.VectorPb<object>(obj, count);

            int position = 3;

            var resultedVector = vector.Remove(position);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_an_array_after_removing_an_element_on_a_certain_position_with_resizing_the_array()
        {
            int count = 9;
            object[] obj = new object[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, null, null, null };
            var expectedVector = new object[8] { 1, 2, 3, 5, 6, 7, 8, 9 };
            var vector = new Vector.VectorPb<object>(obj, count);

            int position = 3;

            var resultedVector = vector.Remove(position);

            CollectionAssert.AreEqual(expectedVector, resultedVector);
        }

        [TestMethod]
        public void Verify_number_of_values_equal_to_5()
        {
            int count = 9;
            object[] obj = new object[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, null, null, null, null, null, null, null };

            Vector.VectorPb<object> vector = new Vector.VectorPb<object>(obj,count);
            object value = 5;
            int noOfValue = 0;
            var expectedResult = 1;
            foreach (object ob in vector)
            {
                if (ob.Equals(value))
                    noOfValue++; 
            }

            Assert.AreEqual(expectedResult, noOfValue);
        }

        [TestMethod]
        public void Verify_number_of_values_equal_to_4()
        {
            int count = 16;
            object[] obj = new object[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 5, 4, 4, 4, 3, 2, 1 };

            Vector.VectorPb<object> vector = new Vector.VectorPb<object>(obj, count);
            object value = 4;
            int noOfValue = 0;
            var expectedResult = 4;
            foreach (object ob in vector)
            {
                if (ob.Equals(value))
                    noOfValue++;
            }

            Assert.AreEqual(expectedResult, noOfValue);
        }

            
    }
}
