using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Meteo;

namespace Meteo.Tests
{
    [TestClass]
    public class MeteoTests
    {
        public static Meteo.Temperature[] temp = new Meteo.Temperature[]
            {
                new Meteo.Temperature { day = 1, tempMax = 10, tempMin = 0 },
                new Meteo.Temperature { day = 2, tempMax = 9, tempMin = 2 },
                new Meteo.Temperature { day = 3, tempMax = 12, tempMin = 0 },
                new Meteo.Temperature { day = 4, tempMax = 13, tempMin = -3 },
                new Meteo.Temperature { day = 5, tempMax = 10, tempMin = 2 },
                new Meteo.Temperature { day = 6, tempMax = 15, tempMin = -1 },
                new Meteo.Temperature { day = 7, tempMax = 15, tempMin = 2 },
                new Meteo.Temperature { day = 8, tempMax = 7, tempMin = 0 },
                new Meteo.Temperature { day = 9, tempMax = 6, tempMin = 0 },
                new Meteo.Temperature { day = 10, tempMax = 12, tempMin = 2 },
                new Meteo.Temperature { day = 11, tempMax = 6, tempMin = 1 },
                new Meteo.Temperature { day = 12, tempMax = 13, tempMin = 0 },
                new Meteo.Temperature { day = 13, tempMax = 13, tempMin = 0 },
                new Meteo.Temperature { day = 14, tempMax = 11, tempMin = 1 },
                new Meteo.Temperature { day = 15, tempMax = 9, tempMin = -3 },
                new Meteo.Temperature { day = 16, tempMax = 8, tempMin = 0 },
                new Meteo.Temperature { day = 17, tempMax = 6, tempMin = 2 },
                new Meteo.Temperature { day = 18, tempMax = 12, tempMin = 2 },
                new Meteo.Temperature { day = 19, tempMax = 7, tempMin = -3 },
                new Meteo.Temperature { day = 20, tempMax = 10, tempMin = 0 },
                new Meteo.Temperature { day = 21, tempMax = 13, tempMin = 1 },
                new Meteo.Temperature { day = 22, tempMax = 6, tempMin = -2 },
                new Meteo.Temperature { day = 23, tempMax = 13, tempMin = 2 },
                new Meteo.Temperature { day = 24, tempMax = 10, tempMin = -1 },
                new Meteo.Temperature { day = 25, tempMax = 15, tempMin = 0 },
                new Meteo.Temperature { day = 26, tempMax = 8, tempMin = -2 },
                new Meteo.Temperature { day = 27, tempMax = 6, tempMin = -3 },
                new Meteo.Temperature { day = 28, tempMax = 9, tempMin = 1 },
                new Meteo.Temperature { day = 29, tempMax = 10, tempMin = 0 },
                new Meteo.Temperature { day = 30, tempMax = 11, tempMin = -1 }
            };

        [TestMethod]
        public void VerifyTheWarmestDaysOrMaxValues()
        {
            Meteo.Temperature[] expectedDaysWithMaxValues = new Meteo.Temperature[]
                {
                    new Meteo.Temperature { day = 6, tempMax = 15, tempMin = -1 },
                    new Meteo.Temperature { day = 7, tempMax = 15, tempMin = 2 },
                    new Meteo.Temperature { day = 25, tempMax = 15, tempMin = 0 }
                };

            Meteo.Temperature[] daysWithMaxValues = Meteo.ReturnDaysWithMaxTemp(temp);

            Assert.AreEqual(expectedDaysWithMaxValues.Length, daysWithMaxValues.Length);
            CollectionAssert.AreEqual(expectedDaysWithMaxValues, daysWithMaxValues);
        }

        [TestMethod]
        public void VerifyTheColdestDaysOrMinValues()
        {
            Meteo.Temperature[] expectedDaysWithMinValues = new Meteo.Temperature[]
                {
                    new Meteo.Temperature { day = 4, tempMax = 13, tempMin = -3 },
                    new Meteo.Temperature { day = 15, tempMax = 9, tempMin = -3 },
                    new Meteo.Temperature { day = 19, tempMax = 7, tempMin = -3 },
                    new Meteo.Temperature { day = 27, tempMax = 6, tempMin = -3 }
                };

            Meteo.Temperature[] daysWithMinValues = Meteo.ReturnDaysWithMinTemp(temp);

            Assert.AreEqual(expectedDaysWithMinValues.Length, daysWithMinValues.Length);
            CollectionAssert.AreEqual(expectedDaysWithMinValues, daysWithMinValues);
        }

        [TestMethod]
        public void VerifyAverageTemperatureBasedOnMaxValues()
        {
            double expectedAverage = 10.17;

            double averageTemp = Meteo.CalculateAverageTemperatureBasedOnMaxValues(temp);

            Assert.AreEqual(expectedAverage, averageTemp);
        }

        [TestMethod]
        public void VerifyTheMaxDifferencesBetweenMinValuesAndMaxValue()
        {
            Meteo.Temperature[] expectedDays = new Meteo.Temperature[]
                {
                    new Meteo.Temperature { day = 4, tempMax = 13, tempMin = -3 },
                    new Meteo.Temperature { day = 6, tempMax = 15, tempMin = -1 }
                };
            int exxpectedMaxDiff = 16;
            int maxDiff = Meteo.ReturnMaxDiff(temp);

            Meteo.Temperature[] days = Meteo.ReturnDaysWithMaxDiffBetweenMinValAndMaxVal(temp);

            Assert.AreEqual(exxpectedMaxDiff, maxDiff);
            Assert.AreEqual(expectedDays.Length, days.Length);
            CollectionAssert.AreEqual(expectedDays, days);
        }

        [TestMethod]
        public void VerifyThatNewValuesForAnotherDayWereAdded()
        {
            Meteo.Temperature[] expectedNewDays = new Meteo.Temperature[]
            {
                new Meteo.Temperature { day = 1, tempMax = 10, tempMin = 0 },
                new Meteo.Temperature { day = 2, tempMax = 9, tempMin = 2 },
                new Meteo.Temperature { day = 3, tempMax = 12, tempMin = 0 },
                new Meteo.Temperature { day = 4, tempMax = 13, tempMin = -3 },
                new Meteo.Temperature { day = 5, tempMax = 10, tempMin = 2 },
                new Meteo.Temperature { day = 6, tempMax = 15, tempMin = -1 },
                new Meteo.Temperature { day = 7, tempMax = 15, tempMin = 2 },
                new Meteo.Temperature { day = 8, tempMax = 7, tempMin = 0 },
                new Meteo.Temperature { day = 9, tempMax = 6, tempMin = 0 },
                new Meteo.Temperature { day = 10, tempMax = 12, tempMin = 2 },
                new Meteo.Temperature { day = 11, tempMax = 6, tempMin = 1 },
                new Meteo.Temperature { day = 12, tempMax = 13, tempMin = 0 },
                new Meteo.Temperature { day = 13, tempMax = 13, tempMin = 0 },
                new Meteo.Temperature { day = 14, tempMax = 11, tempMin = 1 },
                new Meteo.Temperature { day = 15, tempMax = 9, tempMin = -3 },
                new Meteo.Temperature { day = 16, tempMax = 8, tempMin = 0 },
                new Meteo.Temperature { day = 17, tempMax = 6, tempMin = 2 },
                new Meteo.Temperature { day = 18, tempMax = 12, tempMin = 2 },
                new Meteo.Temperature { day = 19, tempMax = 7, tempMin = -3 },
                new Meteo.Temperature { day = 20, tempMax = 10, tempMin = 0 },
                new Meteo.Temperature { day = 21, tempMax = 13, tempMin = 1 },
                new Meteo.Temperature { day = 22, tempMax = 6, tempMin = -2 },
                new Meteo.Temperature { day = 23, tempMax = 13, tempMin = 2 },
                new Meteo.Temperature { day = 24, tempMax = 10, tempMin = -1 },
                new Meteo.Temperature { day = 25, tempMax = 15, tempMin = 0 },
                new Meteo.Temperature { day = 26, tempMax = 8, tempMin = -2 },
                new Meteo.Temperature { day = 27, tempMax = 6, tempMin = -3 },
                new Meteo.Temperature { day = 28, tempMax = 9, tempMin = 1 },
                new Meteo.Temperature { day = 29, tempMax = 10, tempMin = 0 },
                new Meteo.Temperature { day = 30, tempMax = 11, tempMin = -1 },
                new Meteo.Temperature { day = 31, tempMax = 18, tempMin = -4 }
            };

            Meteo.Temperature[] newDays = Meteo.AddNewEntry(temp, 31, 18, -4);

            Assert.AreEqual(expectedNewDays.Length, newDays.Length);
            CollectionAssert.AreEqual(expectedNewDays, newDays);
        }
    }
}
