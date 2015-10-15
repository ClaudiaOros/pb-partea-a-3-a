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

        public static byte[] OperatorNot(byte[] binaryNumber)
        {
            for (int i = 0; i < binaryNumber.Length; i++)
            {
                if (binaryNumber[i] == 1)
                    binaryNumber[i] = 0;
                else
                    binaryNumber[i] = 1;
            }

            return binaryNumber;
        }

        public static byte[] OperatorAnd(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedBinary = new byte [maxLength];
            var index = 0;

            for (int i = 0; i < resultedBinary.Length; i++)
            {
                index = resultedBinary.Length - i - 1;
                resultedBinary[index] = OperatorAnd(GetElem(first, i), GetElem(second, i));
            }
            return resultedBinary;
        }

        public static byte OperatorAnd(byte first, byte second)
        {
            return (first == 1) && (second == 1) ? (byte)1 : (byte)0;
        }

        public static byte[] OperatorOR(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedBinary = new byte[maxLength];
            var index = 0;

            for (int i = 0; i < resultedBinary.Length; i++)
            {
                index = resultedBinary.Length - i - 1;
                resultedBinary[index] = OperatorOR(GetElem(first, i), GetElem(second, i));
            }
            return resultedBinary;
        }

        public static byte OperatorOR(byte first, byte second)
        {
            return (first == 0) && (second == 0) ? (byte)0 : (byte)1;
        }

        public static byte[] OperatorXOR(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedBinary = new byte[maxLength];

            for (int i = 0; i < first.Length; i++)
            {
                if (((GetElem(first, i) == 0) & (GetElem(second, i) == 0)) || ((GetElem(first, i) == 1) & (GetElem(second, i) == 1)))
                    resultedBinary[i] = 0;
                else
                    resultedBinary[i] = 1;
            }
            Array.Reverse(resultedBinary);
            return resultedBinary;
        }

        public static byte[] OperatorRightHandShift(byte[] binaryNumber, int value)
        {
            var resultedBinaryNumber = new byte[binaryNumber.Length];

            for (int i = value; i < binaryNumber.Length; i++)
            {
                resultedBinaryNumber[i] = binaryNumber[i - value];
            }

            return resultedBinaryNumber;
        }

        public static byte[] OperatorLeftHandShift(byte[] binaryNumber, int value)
        {
            var resultedBinaryNumber = new byte[binaryNumber.Length];

            for (int i = 0; i < binaryNumber.Length - value; i++)
            {
                resultedBinaryNumber[i] = binaryNumber[value + i];
            }

            return resultedBinaryNumber;
        }

        public static bool OperatorLessThan(byte[] first, byte[] second)
        {
            bool FirstNumberIsLess = false;

            int maxLength = Math.Max(first.Length, second.Length);

            for (int i = 0; i < maxLength; i++)
            {
                if (GetElemForLessThan(first, i, maxLength) < GetElemForLessThan(second, i,maxLength))
                {
                    FirstNumberIsLess = true;
                    break;
                }
                else
                {
                    FirstNumberIsLess = false;
                    break;
                }
            }
            return FirstNumberIsLess;
        }

        public static byte[] OperationAddition(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedBinaryNumber = new byte[maxLength];
            byte reminder = 0;

            for (int i = 0; i < resultedBinaryNumber.Length; i++)
            {
                resultedBinaryNumber[i] = (byte)((GetElem(first, i) + GetElem(second, i) + reminder) % 2);
                reminder = (byte)((GetElem(first, i) + GetElem(second, i) + reminder) / 2);
            }

            if (reminder != 0)
            {
                Array.Resize(ref resultedBinaryNumber, resultedBinaryNumber.Length + 1);
                resultedBinaryNumber[resultedBinaryNumber.Length-1] = 1;
            }

            Array.Reverse(resultedBinaryNumber);
            return resultedBinaryNumber;
        }

        public static byte[] OperationSubstraction(byte[] first, byte[] second)
        {
            var maxLength = Math.Max(first.Length, second.Length);
            byte[] resultedBinaryNumber = new byte[maxLength];
            byte reminder = 0;

            for (var i = 0; i < maxLength; i++)
            {
                var deductResult = (2 + GetElem(first, i) - GetElem(second, i) - reminder) % 2;
                resultedBinaryNumber[i] = (byte)deductResult;
                reminder = (byte)((2 + GetElem(first, i) - GetElem(second, i) - reminder) / 2);
                reminder = (byte)(reminder == 0 ? 1 : 0);
            }
            Array.Reverse(resultedBinaryNumber);
            return resultedBinaryNumber;
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
            var resultedNumber = 0;
            
            if (OperatorLessThan(first,second))
            {
                while (ConvertToDecimalNumber(second, 2) >= 0)
                {
                    second = OperationSubstraction(second, first);
                    resultedNumber++;                    
                }
            }
            else
            {
                while (ConvertToDecimalNumber(first, 2) > 0)
                {
                    first = OperationSubstraction(first, second);
                    resultedNumber++;
                }
            }

            return ConvertADecimalNumberIntoAnotherBase(resultedNumber,2);
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
                return array[i - (maxLength - array.Length - 1)];
            else
                return 0;
        }
    }
}
