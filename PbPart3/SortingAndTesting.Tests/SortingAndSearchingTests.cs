using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAndSearching;

namespace SortingAndTesting.Tests
{
    [TestClass]
    public class SortingAndSearchingTests
    {
        [TestMethod]
        public void Ascending_order_of_a_text()
        {
            string[] text = {"ana","are","mere","pere","gutui","kiwi" };
            string[] expectedAscendingSortedText = { "ana","are","gutui","kiwi","mere","pere" };

            string[] ascendingText = SortingAndSearching.SortingAndSearching.Quicksort(text,0,text.Length-1);
            
            CollectionAssert.AreEqual(expectedAscendingSortedText, ascendingText,"Ascending order not correct");
        }

        [TestMethod]
        public void Descending_order_of_a_text()
        {
            string[] text = { "ana", "are", "mere", "pere", "gutui", "kiwi" };
            string[] expectedDescendingSortedText = { "pere", "mere", "kiwi", "gutui", "are", "ana" };

            string[] descendingText = SortingAndSearching.SortingAndSearching.OrderDescending(text);

            CollectionAssert.AreEqual(expectedDescendingSortedText, descendingText, "Descending order not correct");
        }

        [TestMethod]
        public void Ascending_loto_numbers()
        {
            int[] numbers = { 2, 5, 34, 23, 8, 13 };
            int[] expectedAscendingNumbers = { 2, 5, 8, 13, 23, 34 };

            int[] ascendingNumbers = SortingAndSearching.SortingAndSearching.InsertionSortingAlgorithm(numbers);

            CollectionAssert.AreEqual(expectedAscendingNumbers, ascendingNumbers);
        }

        [TestMethod]
        public void Reparation_Priority()
        {
            SortingAndSearching.SortingAndSearching.Reparation[]  reparations = new SortingAndSearching.SortingAndSearching.Reparation[]
             {  
                 new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb anvelope" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.low                      
                 },

                 new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb ulei" ,
                     priority =SortingAndSearching.SortingAndSearching.Priority.medium                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb motor" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.high                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb stergatoare" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.low                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "spalat motor" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.medium                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "vopsit" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.medium                      
                 }
             };

            var expectedReparationsOrderedByPriority = new SortingAndSearching.SortingAndSearching.Reparation[]
            {
                new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb anvelope" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.low                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb stergatoare" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.low                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb ulei" ,
                     priority =SortingAndSearching.SortingAndSearching.Priority.medium                      
                 },
                  new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "spalat motor" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.medium                      
                 },
                
                   new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "vopsit" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.medium                      
                 },
                   new SortingAndSearching.SortingAndSearching.Reparation
                 {
                     reparation = "schimb motor" ,
                     priority = SortingAndSearching.SortingAndSearching.Priority.high                      
                 }
            };

            var reparationsOrderedByPriority = SortingAndSearching.SortingAndSearching.SelectionSortingAlgorithm(reparations);

            CollectionAssert.AreEqual(expectedReparationsOrderedByPriority, reparationsOrderedByPriority);
        }

        [TestMethod]
        public void Order_words()
        {
            string[] text = {"ana","are","mere","mere","mere","pere","cirese","ana" };
            string[] expectedText = {"ana","ana","are","cirese","mere","mere","mere","pere" };

            string[] orderedText = SortingAndSearching.SortingAndSearching.QuickSort3Algorithm(text, 0, text.Length - 1);

            CollectionAssert.AreEqual(expectedText, orderedText);
        }
        
    }
}
