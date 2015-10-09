using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PbPart3;

namespace LotoTests
{
    [TestClass]
    public class LotoTests
    {
        [TestMethod]
        public void Odds_For_Lotto_2_of_5()
        {
            long numbersToBeGuessed = 2;
            long totalNumbers = 5;

            long odds = PbPart3.Loto.CalculateOdds(numbersToBeGuessed, totalNumbers);

            Assert.AreEqual(10, odds, "The odds are not calculated correctly");
        }

        [TestMethod]
        public void Odds_For_Lotto_6_of_49()
        {
            long numbersToBeGuessed = 6;
            long totalNumbers = 49;

            long odds = PbPart3.Loto.CalculateOdds(numbersToBeGuessed, totalNumbers);

            Assert.AreEqual(13983816, odds, "The odds are not calculated correctly");
        }

        [TestMethod]
        public void Odds_For_Lotto_5_of_49()
        {
            long numbersToBeGuessed = 5;
            long totalNumbers = 49;

            long odds = PbPart3.Loto.CalculateOdds(numbersToBeGuessed, totalNumbers);

            Assert.AreEqual(1906884, odds, "The odds are not calculated correctly");
        }

        [TestMethod]
        public void Odds_For_Lotto_4_of_49()
        {
            long numbersToBeGuessed = 4;
            long totalNumbers = 49;

            long odds = PbPart3.Loto.CalculateOdds(numbersToBeGuessed, totalNumbers);

            Assert.AreEqual(211876, odds, "The odds are not calculated correctly");
        }
    }
}
