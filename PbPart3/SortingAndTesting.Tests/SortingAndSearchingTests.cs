using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAndSearching;
using System.Collections.Generic;

namespace SortingAndTesting.Tests
{
    [TestClass]
    public class SortingAndSearchingTests
    {
        [TestMethod]
        public void Ascending_order_of_a_text()
        {
            string[] text = { "ana", "are", "mere", "pere", "gutui", "kiwi" };
            string[] expectedAscendingSortedText = { "ana", "are", "gutui", "kiwi", "mere", "pere" };

            string[] ascendingText = SortingAndSearching.SortingAndSearching.Quicksort(text, 0, text.Length - 1);

            CollectionAssert.AreEqual(expectedAscendingSortedText, ascendingText, "Ascending order not correct");
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
            SortingAndSearching.SortingAndSearching.Reparation[] reparations = new SortingAndSearching.SortingAndSearching.Reparation[]
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
            string[] text = { "ana", "are", "mere", "mere", "mere", "pere", "ana", "cirese" };
            string[] expectedText = { "ana", "ana", "are", "cirese", "mere", "mere", "mere", "pere" };

            string[] orderedText = SortingAndSearching.SortingAndSearching.SelectionSortingAlgorithm(text);

            CollectionAssert.AreEqual(expectedText, orderedText);
        }

        [TestMethod]
        public void Compare_Two_Strings1()
        {
            string s1 = "cuvant";
            string s2 = "cuvantmmmm";

            bool isfirstless = SortingAndSearching.SortingAndSearching.IsLessThan(s1, s2);

            Assert.AreEqual(true, isfirstless);
        }

        [TestMethod]
        public void Compare_Two_Strings2()
        {
            string s1 = "cuvantfgffg";
            string s2 = "cuvant";

            bool isfirstless = SortingAndSearching.SortingAndSearching.IsLessThan(s1, s2);

            Assert.AreEqual(false, isfirstless);
        }

        [TestMethod]
        public void Compare_Two_Strings3()
        {
            string s1 = "ana";
            string s2 = "cirese";

            bool isfirstless = SortingAndSearching.SortingAndSearching.IsLessThan(s1, s2);

            Assert.AreEqual(true, isfirstless);
        }

        [TestMethod]
        public void Verify_Who_Won_THe_Elections()
        {

            var clujPoll = new SortingAndSearching.SortingAndSearching.Polls
            {
                elections = new SortingAndSearching.SortingAndSearching.Elections[]
                {
                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Iohannis",
                   votes = 10
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate  = "Macovei",
                   votes = 9

                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Ponta",
                   votes = 8
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Tariceanu",
                   votes = 7
                    }
                }
            };

            var timisPoll = new SortingAndSearching.SortingAndSearching.Polls
            {
                elections = new SortingAndSearching.SortingAndSearching.Elections[]
                {
                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                   candidate = "Ponta",
                   votes = 11
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Iohannis",
                   votes = 9
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Tariceanu",
                   votes = 3
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Macovei",
                   votes = 2
                    }
                }
            };

            var albaPoll = new SortingAndSearching.SortingAndSearching.Polls
            {
                elections = new SortingAndSearching.SortingAndSearching.Elections[]
                {
                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Iohannis",
                   votes = 13
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Tariceanu",
                   votes = 6
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Ponta",
                   votes = 5
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {

                    candidate = "Macovei",
                   votes = 1
                    }
                }
            };

            SortingAndSearching.SortingAndSearching.Polls[] polls = new SortingAndSearching.SortingAndSearching.Polls[]
            {
                clujPoll,
                timisPoll,
                albaPoll
            };



            var expectedListOfCandidates = new SortingAndSearching.SortingAndSearching.Elections[]
                {
                    new SortingAndSearching.SortingAndSearching.Elections()
                    {
                          candidate = "Iohannis",
                         votes = 32
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {
                         candidate = "Ponta",
                         votes = 24
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {
                        candidate = "Tariceanu",
                        votes = 16
                    },

                    new SortingAndSearching.SortingAndSearching.Elections()
                    {
                         candidate = "Macovei",
                         votes = 12
                    }
                
            };

            SortingAndSearching.SortingAndSearching.Elections[] listOfCandidates = SortingAndSearching.SortingAndSearching.GetWinner(polls);

            for (int i = 0; i < expectedListOfCandidates.Length; i++)
            {
                Assert.AreEqual(expectedListOfCandidates[i].votes, listOfCandidates[i].votes);
                Assert.AreEqual(expectedListOfCandidates[i].candidate, listOfCandidates[i].candidate);
            }
        }


        [TestMethod]
        public void Order_words_by_occurances_using_dictionary()
        {
            string[] text = { "ana", "are", "mere", "mere", "mere", "pere", "ana", "cirese" };

            Dictionary<string, int> expectedResult = new Dictionary<string, int>();
            expectedResult.Add("mere", 3);
            expectedResult.Add("ana", 2);
            expectedResult.Add("are", 1);
            expectedResult.Add("pere", 1);
            expectedResult.Add("cirese", 1);

            var actualResult = SortingAndSearching.SortingAndSearching.OrderWordsByOccurances(text);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Order_words_by_occurrances()
        {
            string[] text = { "ana", "are", "mere", "mere", "mere", "pere", "ana", "cirese" };

            SortingAndSearching.SortingAndSearching.Text[] expectedResult = new SortingAndSearching.SortingAndSearching.Text[]
            {
                new SortingAndSearching.SortingAndSearching.Text()
                {  
                     word = "mere",
                     occur = 3
                },
                new SortingAndSearching.SortingAndSearching.Text()
                {  
                     word = "ana",
                     occur = 2
                },
                new SortingAndSearching.SortingAndSearching.Text()
                {  
                     word = "are",
                     occur = 1
                },
                new SortingAndSearching.SortingAndSearching.Text()
                {  
                     word = "cirese",
                     occur = 1
                },
                new SortingAndSearching.SortingAndSearching.Text()
                {  
                     word = "pere",
                     occur = 1
                }
            };

            var actualResult= SortingAndSearching.SortingAndSearching.OrderWordsByOccurrances(text);

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

    }
}
