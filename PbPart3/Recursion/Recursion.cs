﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class Recursion
    {
        public static string ReturnTheReverseString(string s)
        {

            if ((s.Length == 1) || (String.IsNullOrEmpty(s))) return s;
            else
                return s[s.Length - 1] + ReturnTheReverseString(s.Substring(0, s.Length - 1));
        }

        public static string ReplaceACharWithAString(char charToBeReplaced, string a, string b)
        {
            if (String.IsNullOrEmpty(a))
                return a;

            if (a[0] == charToBeReplaced)
                return b + ReplaceACharWithAString(charToBeReplaced, a.Substring(1, a.Length - 1), b);
            return a[0] + ReplaceACharWithAString(charToBeReplaced, a.Substring(1, a.Length - 1), b);
        }

        public static double Calculator(string[] input, ref int index)
        {
            double result;

            if (!double.TryParse(input[index], out result))
            {
                var operators = input[index];
                index++;

                var operand1 = Calculator(input, ref index);
                var operand2 = Calculator(input, ref index);

                return Compute(operators, operand1, operand2);
            }

            var nr = double.Parse(input[index]);
            index++;
            return nr;
        }

        public static double Compute(string @operator, double operand1, double operand2)
        {
            switch (@operator)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;           
            }

            return 0;
        }

        public static ulong HanoiTowers(int disk, ref ulong moves)
        {
            if (disk == 0)
                return moves;

            HanoiTowers(disk - 1, ref moves);
            moves++;
            HanoiTowers(disk - 1, ref moves);

            return moves;
        }

        public static int Pascal(int row, int column)
        {
            if (column == 0)
                return 0;
            else if (row == 1 && column == 1)
                return 1;
            else if (column > row)
                return 0;
            else
                return (Pascal(row - 1, column - 1) + Pascal(row - 1, column));
        }

    }
}
