using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnBases
{
    public class OperationsOnBases
    {
        public static byte[] ConvertADecimalNumberIntoAnotherBase(int decimalNumber, int baseNumber)
        {
            byte[] convertedNumber = new byte[Byte.MaxValue];
            int i = 0;

            while (decimalNumber > 0)
            {
                var modulo = decimalNumber % baseNumber;
                convertedNumber[i++] = (byte)modulo;
                decimalNumber = decimalNumber / baseNumber;
            }
            Array.Resize(ref convertedNumber, i);
            Array.Reverse(convertedNumber);

            return convertedNumber;
        }

        public static double ConvertToDecimalNumber(byte[] number, int baseOfTheNumber)
        {
            double decimalNumber = 0;

            for (int i = 0; i < number.Length; i++)
            {
                decimalNumber = decimalNumber + number[i] * Math.Pow(baseOfTheNumber, number.Length - i - 1);
            }
            return decimalNumber;
        }

        public static byte[] OperatorNot(byte[] number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                number [i] = (number[i] == 1) ? (byte)0: (byte)1;
            }
            return number;
        }

        public static byte[] OperatorAnd(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedNumber = new byte [maxLength];
            var index = 0;

            for (int i = 0; i < resultedNumber.Length; i++)
            {
                index = resultedNumber.Length - i - 1;
                resultedNumber[index] = OperatorAnd(GetElem(first, i), GetElem(second, i));
            }
            return resultedNumber;
        }

        public static byte OperatorAnd(byte first, byte second)
        {
            return (first == 1) && (second == 1) ? (byte)1 : (byte)0;
        }

        public static byte[] OperatorOR(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedNumber = new byte[maxLength];
            var index = 0;

            for (int i = 0; i < resultedNumber.Length; i++)
            {
                index = resultedNumber.Length - i - 1;
                resultedNumber[index] = OperatorOR(GetElem(first, i), GetElem(second, i));
            }
            return resultedNumber;
        }

        public static byte OperatorOR(byte first, byte second)
        {
            return (first == 0) && (second == 0) ? (byte)0 : (byte)1;
        }

        public static byte[] OperatorXOR(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedNumber = new byte[maxLength];

            for (int i = 0; i < first.Length; i++)
            {
                resultedNumber[i] = (((GetElem(first, i) == 0) & (GetElem(second, i) == 0)) || ((GetElem(first, i) == 1) & (GetElem(second, i) == 1))) ? (byte)0 : (byte)1;
            }
            Array.Reverse(resultedNumber);
            return resultedNumber;
        }

        public static byte[] OperatorRightHandShift(byte[] number, int value)
        {
            var resultedNumber = new byte[number.Length];

            for (int i = value; i < number.Length; i++)
            {
                resultedNumber[i] = number[i - value];
            }
            return resultedNumber;
        }

        public static byte[] OperatorLeftHandShift(byte[] number, int value)
        {
            var resultedNumber = new byte[number.Length];

            for (int i = 0; i < number.Length - value; i++)
            {
                resultedNumber[i] = number[value + i];
            }

            return resultedNumber;
        }

        public static bool OperatorLessThan(byte[] first, byte[] second)
        {
            bool FirstNumberIsLess = false;

            int maxLength = Math.Max(first.Length, second.Length);

            for (int i = 0; i <maxLength; i++)
            {
                if (GetElemForLessThan(first, i, maxLength) < GetElemForLessThan(second, i,maxLength)) 
                {
                    FirstNumberIsLess = true;
                    break;
                }
            }
            return FirstNumberIsLess;
        }

        public static bool OperatorGreaterThan(byte[] first, byte[] second)
        {
            return (OperatorLessThan(second, first));
        }

        public static bool OperatorEqual(byte[] first, byte[] second)
        {
            return ((OperatorLessThan(second, first) == false) && (OperatorLessThan(first, second) == false));
        }

        public static byte[] OperationAddition(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedNumber = new byte[maxLength];
            byte reminder = 0;

            for (int i = 0; i < resultedNumber.Length; i++)
            {
                int sum = (GetElem(first, i) + GetElem(second, i) + reminder);
                resultedNumber[i] = (byte)(sum % 2);
                reminder = (byte)(sum / 2);
            }

            if (reminder != 0)
            {
                Array.Resize(ref resultedNumber, resultedNumber.Length + 1);
                resultedNumber[resultedNumber.Length-1] = 1;
            }

            Array.Reverse(resultedNumber);
            return resultedNumber;
        }

        public static byte[] OperationSubstraction(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedNumber = new byte[maxLength];
            byte reminder = 0;

            for (var i = 0; i < maxLength; i++)
            {
                var difference = GetElem(first, i) - GetElem(second, i) - reminder;
                var deductResult = (2 + difference) % 2;
                resultedNumber[i] = (byte)deductResult;
                reminder = (byte)((2 + difference) / 2);
                reminder = (byte)(reminder == 0 ? 1 : 0);
            }
            Array.Reverse(resultedNumber);
            return resultedNumber;
        }

        public static byte[] OperationMultiply(byte[] first, byte[] second)
        {
            var resultedNumber = new byte[0];
            var decimalSecond = ConvertToDecimalNumber(second, 2);

            for (int i = 1; i <= decimalSecond; i++)
                resultedNumber = OperationAddition(resultedNumber, first);
             
            return resultedNumber;
        }

        public static byte[] OperationDivision(byte[] first, byte[] second)
        {
           int resultedNumber = 0;

                while (OperatorGreaterThan(first,second) || OperatorEqual(first,second))
                {
                    first = OperationSubstraction(first, second);
                    resultedNumber++;                    
                }
            return ConvertADecimalNumberIntoAnotherBase(resultedNumber,2) ;
        }

        public static byte GetElem(byte[] array, int i)
        {
            if (i < array.Length)
                return array[array.Length - i - 1];
            else
                return 0;
        }

        public static byte GetElemForLessThan(byte[] array, int i, int maxLength)
        {
            if (i >= maxLength - array.Length)
                return array[i - (maxLength-array.Length)];
            else
                return 0;
        }
    }
}
