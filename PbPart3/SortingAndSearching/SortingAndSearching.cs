using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // 3-way partition
            int i = 1;
            int k = 1;
            int n = text.Length-1;
            int p = n;

            while (i < p)
            {
                if (IsLessThan(text[i], text[n]))
                    Swap(text, i++, k++);
                else
                    if (text[i] == text[n])
                        Swap(text, i, p--);
                    else
                        i++;
            }

            // move pivots to center
            int m = GetMinValue(p - k, n - p + 1);
            SwapMore(text,k, k + m - 1, n - m + 1, n);

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
            bool isLess = true;

            if (a.Length != b.Length)            
                SetSameLengthForTwoStrings(ref a, ref b);
            

            for (int i = 0; i < a.Length; i++)

                if (a[i] > b[i])
                {
                    isLess = false;
                    break;
                }
            return isLess;
        }

        public static void SetSameLengthForTwoStrings(ref string  a, ref string b)
        {
          
            if (a.Length > b.Length)
                for (int i = b.Length ; i < a.Length; i++)
                    b = b + "0";
            else
                if (b.Length > a.Length)
                    for (int i = a.Length ; i < b.Length; i++)
                        a = a + "0";
        }
    }
}