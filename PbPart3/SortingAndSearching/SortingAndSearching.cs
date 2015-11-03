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
        
        public struct Subjects
        {
            public string name;
            public float[] marks;
        }

        public struct Student
        {
            public string Name;
            public Subjects[] subjects;
        }

        public struct Overall
        {
            public string studentName;
            public float overallMark;
        }

        public struct SmartestStudent
        {
            public string studentName;
            public int noOf10s;
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

        public static Elections[] GetWinner(Polls[] polls)
        {

            Elections[] finalList = polls[0].elections;

            for (int i = 1; i < polls.Length; i++)
            {
                for (int j = 0; j < polls[i].elections.Length; j++)

                    for (int z = 0; z < finalList.Length; z++)
                    {
                        if (finalList[z].candidate == polls[i].elections[j].candidate)
                        {
                            finalList[z].votes += polls[i].elections[j].votes;
                            break;
                        }
                    }
            }

            OrderListOfCandidatesByVotes(ref finalList);

            return finalList;
        }

        public static void OrderListOfCandidatesByVotes(ref  Elections[] finalList)
        {
            int j;
            for (int i = 1; i < finalList.Length; i++)
            {
                j = i;

                while (j > 0 && finalList[j - 1].votes < finalList[j].votes)
                {
                    SwapCandidates(ref finalList[j], ref finalList[j - 1]);
                    j = j - 1;
                }
            }
        }

        public static void SwapCandidates(ref Elections candidate1, ref Elections candidate2)
        {
            var temp = candidate1;
            candidate1 = candidate2;
            candidate2 = temp;
        }

        public static Dictionary<string, int> OrderWordsByOccurances(string[] text)
        {
            var dictionary = InsertIntoDictionary(text);
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

        public static Text[] OrderWordsByOccurrances(string[] text)
        {
            var finalList = new Text[0];

            for (int i = 0; i < text.Length; i++)
            {
                finalList = AddAnElement(ref finalList, text[i]);
            }

            finalList = SelectionSortingAlgorithm(finalList);

            return finalList;
        }

        public static Text[] AddAnElement(ref Text[] text, string word)
        {
            for (int i=0; i<text.Length; i ++)
            {
                if (text[i].word == word)
                {
                    text[i].occur++;
                    return text;
                }
            }

            Array.Resize(ref text, text.Length + 1);
            text[text.Length - 1].word = word;
            text[text.Length - 1].occur = 1;

            return text;

            }        

        public static Text[] SelectionSortingAlgorithm(Text[] text)
    {
        int min;
        Text temp;

        for (int i = 0; i < text.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < text.Length; j++)
                if ((text[j].occur > text[min].occur) || ((text[j].occur == text[min].occur) && ( IsLessThan(text[j].word , text[min].word))))
                    min = j;

            temp = SwapValues(text, min, i);
        }

        return text;
    }

        private static Text SwapValues(Text[] text, int min, int i)
    {
        Text temp;

        temp = text[i];
        text[i] = text[min];
        text[min] = temp;
        return temp;
    }

        public static Overall[] GetTheStudentsWithOrderedListByOverallMarks(Student[] students)
        {
            var finalList = new Overall[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                finalList[i] = GetOverallForOneStudent(students[i]);
            }

            finalList = SelectionSortingAlgorithm(finalList);

            return finalList;
        }

        public static Overall[] SelectionSortingAlgorithm(Overall[] students)
        {
            int max;

            for (int i = 0; i < students.Length - 1; i++)
            {
                max = i;
                for (int j = i + 1; j < students.Length; j++)
                    if (students[j].overallMark > students[max].overallMark)
                        max = j;

                Swap(students, max, i);
            }

            return students;
        }

        public static Overall Swap(Overall[] students, int max, int i)
        {
        Overall temp;

        temp = students[i];
        students[i] = students[max];
        students[max] = temp;
        return temp;
        }

        public static Overall GetOverallForOneStudent(Student student)
        {
            var overallStudent = new Overall();

            float[] overallMarks;
            float overallMark;

            student = ReturnOverallMarksForAllSubjects(student, out overallMarks, out overallMark);

            ReturnOverAllMarkForStudent(ref student, ref overallStudent, overallMarks, ref overallMark);

            return overallStudent;
        }

        private static void ReturnOverAllMarkForStudent(ref Student student, ref Overall overallStudent, float[] overallMarks, ref float overallMark)
        {
            for (int i = 0; i < overallMarks.Length; i++)
            {
                overallMark += overallMarks[i];
            }

            overallMark = overallMark / student.subjects.Length;

            overallStudent.overallMark = overallMark;
            overallStudent.studentName = student.Name;
        }

        private static Student ReturnOverallMarksForAllSubjects(Student student, out float[] overallMarks, out float overallMark)
        {
            float mark = 0;
            int size = 0;
            overallMarks = new float[size];
            overallMark = 0;

            for (int i = 0; i < student.subjects.Length; i++)
            {
                for (int j = 0; j < student.subjects[i].marks.Length; j++)
                {
                    mark += student.subjects[i].marks[j];
                }

                size++;
                Array.Resize(ref overallMarks, size);
                overallMarks[size - 1] = mark / student.subjects[i].marks.Length;
                mark = 0;
            }
            return student;
        }

        public static Overall FindAStudentByOverallMark(Student[] students, float mark)
        {
            var student = new Overall();

            var studentsWithOverall = GetTheStudentsWithOrderedListByOverallMarks(students);

            for (int i = 0; i < studentsWithOverall.Length; i++)
                if (studentsWithOverall[i].overallMark == mark)
                {
                    student.overallMark = studentsWithOverall[i].overallMark;
                    student.studentName = studentsWithOverall[i].studentName;
                }
            return student;   
        }

        public static SmartestStudent GetStudentWithMost10s(Student[] students)
        {
            var noOf10sForFirstStudent = GetNoOf10sForAStudent(students[0]);
            var smartStudent = new SmartestStudent()
                {
                     studentName = noOf10sForFirstStudent.studentName,
                     noOf10s = noOf10sForFirstStudent.noOf10s
                };

            for (int i = 1; i < students.Length; i++)
            {
                var result = GetNoOf10sForAStudent(students[i]);
                if (result.noOf10s > smartStudent.noOf10s)
                {
                    smartStudent.noOf10s = result.noOf10s;
                    smartStudent.studentName = result.studentName;
                }
            }

            return smartStudent;
        }

        public static SmartestStudent GetNoOf10sForAStudent(Student student)
        {
            var studentWith10s = new SmartestStudent();
            int noOf10s = 0;

            for (int i = 0; i < student.subjects.Length; i++)
                for (int j = 0; j < student.subjects[i].marks.Length; j++)
                    if (student.subjects[i].marks[j] == 10)
                        noOf10s++;

            studentWith10s.studentName = student.Name;
            studentWith10s.noOf10s = noOf10s;

            return studentWith10s;
        }

        public static Overall GetStudentWithLowestOverall(Student[] students)
        {
            var orderedList = GetTheStudentsWithOrderedListByOverallMarks(students);
            return orderedList[orderedList.Length - 1];
        }
    }
}
