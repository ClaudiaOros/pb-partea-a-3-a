using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SortingAndSearching
{
    public class SortingAndSearching
    {
        public enum Priority
        {
            low,
            medium,
            high
        };

        public struct Reparation
        {
            public string reparation;
            public Priority priority;

        }

        public struct Elections
        {
            public string candidate;
            public int votes;
        }

        public struct Polls
        {
            public Elections[] elections;
        }

        public struct Text
        {
            public string word;
            public int occur;
        }

        public static string[] Quicksort(string[] text, int left, int right)
        {
            int i = left, j = right;
            string pivot = text[(left + right) / 2];

            while (i <= j)
            {
                while (text[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (text[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    string tmp = text[i];
                    text[i] = text[j];
                    text[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(text, left, j);
            }

            if (i < right)
            {
                Quicksort(text, i, right);
            }

            return text;
        }

        public static string[] OrderDescending(string[] text)
        {
            string[] textToOrder = Quicksort(text, 0, text.Length - 1);

            Array.Reverse(textToOrder);

            return textToOrder;
        }

        public static int[] InsertionSortingAlgorithm(int[] array)
        {
            int temp, j;
            for (int i = 1; i < array.Length; i++)
            {
                temp = array[i];
                j = i - 1;

                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }

            return array;
        }


        public static Reparation[] SelectionSortingAlgorithm(Reparation[] repairs)
        {
            int min;
            Reparation temp;

            for (int i = 0; i < repairs.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < repairs.Length; j++)
                    if (repairs[j].priority < repairs[min].priority)
                        min = j;

                temp = SwapValues(repairs, min, i);
            }

            return repairs;
        }

        public static string[] SelectionSortingAlgorithm(string[] text)
        {
            int min;

            for (int i = 0; i < text.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < text.Length; j++)
                    if (IsLessThan(text[j], text[min]))
                        min = j;

                Swap(text, min, i);
            }

            return text;
        }

        private static Reparation SwapValues(Reparation[] repairs, int min, int i)
        {
            Reparation temp;

            temp = repairs[i];
            repairs[i] = repairs[min];
            repairs[min] = temp;
            return temp;
        }


        public static void Swap(string[] array, int a, int b)
        {
            string temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public static string[] QuickSort3Algorithm(string[] text, int left, int right)
        {
            Swap(text, text.Length - 1, (left + right) / 2);

            // 3-way partition
            int i = left;
            int k = left;
            int n = right;
            int p = n;


            while (i < p)
            {
                if (IsLessThan(text[i], text[n]))
                { Swap(text, i++, k++); }
                else
                    if (text[i] == text[n])
                        Swap(text, i, p--);
                    else
                        i++;
            }

            // move pivots to center
            int m = GetMinValue(p - k, n - p + 1);
            SwapMore(text, k, k + m - 1, n - m + 1, n);

            // recursive sorts

            QuickSort3Algorithm(text, 1, k - 1);

            QuickSort3Algorithm(text, n - p + k + 1, n);

            return text;

        }

        public static void SwapMore(string[] text, int xStart, int xEnd, int yStart, int yEnd)
        {
            while (xEnd >= xStart)
            {
                var temp = text[yStart];
                text[yStart] = text[xStart];
                text[xStart] = temp;
                xStart++;
                yStart++;
            }
        }

        public static int GetMinValue(int a, int b)
        {
            return a < b ? a : b;
        }

        public static bool IsLessThan(string a, string b)
        {
            bool isLess = false;

            if (a.Length != b.Length)
                SetSameLengthForTwoStrings(ref a, ref b);
            bool equal = false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                    equal = true;

                else
                    if (a[i] > b[i])
                    {
                        isLess = false;
                        break;
                    }
                    else
                        if (a[i] < b[i])
                        {
                            isLess = true;
                            break;
                        }

            }
            return isLess;
        }

        public static void SetSameLengthForTwoStrings(ref string a, ref string b)
        {

            if (a.Length > b.Length)
                for (int i = b.Length; i < a.Length; i++)
                    b = b + "0";
            else
                if (b.Length > a.Length)
                    for (int i = a.Length; i < b.Length; i++)
                        a = a + "0";
        }

        public static Polls GetWinner(Polls[] polls)
        {

            Polls finalList = new Polls()
            {
                elections = new Elections[]
                { 
                    new Elections()
                    {
                     candidate = "Iohannis",
                     votes = 0
                    },

                    new Elections()
                    {
                      candidate = "Macovei",
                      votes = 0
                    },

                    new Elections()
                    {
                     candidate = "Ponta",
                     votes = 0
                    },

                    new Elections()
                    {
                      candidate = "Tariceanu",
                      votes = 0
                    }
                }
            };

            finalList = GetFinalResultsForCandidates(polls, finalList);

            OrderListOfCandidatesByVotes(ref finalList);

            return finalList;
        }

        public static Polls GetFinalResultsForCandidates(Polls[] polls, Polls finalList)
        {
            for (int i = 0; i < polls.Length; i++)
            {
                for (int j = 0; j < polls[i].elections.Length; j++)
                {
                    if (polls[i].elections[j].candidate == "Iohannis")
                    {
                        finalList.elections[0].votes += polls[i].elections[j].votes;
                    }
                    else
                        if (polls[i].elections[j].candidate == "Macovei")
                        {
                            finalList.elections[1].votes += polls[i].elections[j].votes;
                        }
                        else
                            if (polls[i].elections[j].candidate == "Ponta")
                            {
                                finalList.elections[2].votes += polls[i].elections[j].votes;
                            }
                            else if (polls[i].elections[j].candidate == "Tariceanu")
                            {
                                finalList.elections[3].votes += polls[i].elections[j].votes;
                            }
                }
            }
            return finalList;
        }

        public static void OrderListOfCandidatesByVotes(ref Polls finalList)
        {
                 int j;
                 for (int i = 1; i < finalList.elections.Length; i++ )
                 {
                     j = i;

                     while (j > 0 && finalList.elections[j - 1].votes < finalList.elections[j].votes)
                     {
                         SwapCandidates(ref finalList.elections[j],ref finalList.elections[j - 1]);
                         j = j - 1;
                     }
                 }           
        }

        public static void SwapCandidates(ref Elections candidate1,ref Elections candidate2)
        {
            var temp = candidate1;
            candidate1 = candidate2;
            candidate2 = temp;
        }

        public static Dictionary<string, int> OrderWordsByOccurances(string[] text)
        {
            var dictionary =  InsertIntoDictionary(text);
            var dctTemp = new Dictionary<string, int>();

            foreach (var item in dictionary.OrderByDescending(key => key.Value))
            {
                dctTemp.Add(item.Key, item.Value);
            }

            return dctTemp;
        }

        private static Dictionary<string, int> InsertIntoDictionary(string[] text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string word in text)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word] += 1;
                }
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            return dictionary;
        }
    }
}