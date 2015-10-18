using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    public class Meteo
    {
        public struct Temperature
        {
            public int day;
            public int tempMin;
            public int tempMax;
        }

        public static Temperature[] ReturnDaysWithMaxTemp(Temperature[] temp)
        {
            Temperature[] daysWithMaxTemp = new Temperature[0];
            int maxTemp = ReturnMaxValue(temp);

            int daysWithMaxValue = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].tempMax == maxTemp)
                {
                    daysWithMaxValue++;
                    Array.Resize(ref daysWithMaxTemp, daysWithMaxValue);

                    daysWithMaxTemp[daysWithMaxValue - 1] =

                        new Temperature { day = temp[i].day, tempMax = temp[i].tempMax, tempMin = temp[i].tempMin};
                }
            }

            return daysWithMaxTemp;
        }

        public static Temperature[] ReturnDaysWithMinTemp(Temperature[] temp)
        {
            Temperature[] daysWithMinTemp = new Temperature[0];
            int minTemp = ReturnMinValue(temp);

            int daysWithMinValue = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].tempMin == minTemp)
                {
                    daysWithMinValue++;
                    Array.Resize(ref daysWithMinTemp, daysWithMinValue);

                    daysWithMinTemp[daysWithMinValue - 1] =

                        new Temperature { day = temp[i].day, tempMax = temp[i].tempMax, tempMin = temp[i].tempMin };
                }
            }

            return daysWithMinTemp;
        }

        public static double CalculateAverageTemperatureBasedOnMaxValues(Temperature[] temp)
        {
            double average = 0;

            for (int i =0; i< temp.Length; i++)
            {
                average += temp[i].tempMax;
            }

            average = (double) Math.Round((average / temp.Length),2);

            return average;
        }

        public static Temperature[] ReturnDaysWithMaxDiffBetweenMinValAndMaxVal(Temperature[] temp)
        {
            Temperature[] days = new Temperature[0];
            int diff = ReturnMaxDiff(temp);

            int daysWithMaxDiff = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if ((temp[i].tempMax - temp[i].tempMin) == diff)
                {
                    daysWithMaxDiff++;
                    Array.Resize(ref days, daysWithMaxDiff);

                    days[daysWithMaxDiff - 1] =

                        new Temperature { day = temp[i].day, tempMax = temp[i].tempMax, tempMin = temp[i].tempMin };
                }
            }

            return days;
        }

        public static Temperature[] AddNewEntry(Temperature[] temp, int newDay, int max, int min)
        {
            Temperature[] newTemp = new Temperature[temp.Length];

            for (int i = 0; i < temp.Length; i++)
            {
                newTemp[i] = temp[i];
            }

            Array.Resize(ref newTemp, newTemp.Length + 1);
            newTemp[newTemp.Length-1] = new Temperature { day = newDay,tempMax = max, tempMin = min };

            return newTemp;
        }


        private static int ReturnMaxValue(Temperature[] temp)
        {
            int maxTemp = temp[0].tempMax;
            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i].tempMax > maxTemp)
                {
                    maxTemp = temp[i].tempMax;
                }
            }

            return maxTemp;
        }

        private static int ReturnMinValue(Temperature[] temp)
        {
            int minTemp = temp[0].tempMin;
            for (int i = 1; i < temp.Length; i++)
            {
                if (temp[i].tempMin < minTemp)
                {
                    minTemp = temp[i].tempMin;
                }
            }

            return minTemp;
        }

        public static int ReturnMaxDiff(Temperature[] temp)
        {
            int diff = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if ((temp[i].tempMax - temp[i].tempMin) > diff)
                    diff = temp[i].tempMax - temp[i].tempMin;
            }

            return diff;
        }

    }
}
