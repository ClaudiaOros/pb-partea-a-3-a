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

        public static byte[] OperatorAnd(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] resultedBinary = GetMaxLength(firstBinaryNumber, secondBinaryNumber);

            for (int i = 0; i < resultedBinary.Length; i++)
            {
                if ((GetElem(firstBinaryNumber, i) == 1) & (GetElem(secondBinaryNumber, i) == 1))
                    resultedBinary[i] = 1;
                else
                    resultedBinary[i] = 0;
            }
            Array.Reverse(resultedBinary);
            return resultedBinary;
        }

        public static byte[] OperatorOR(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] resultedBinary = GetMaxLength(firstBinaryNumber, secondBinaryNumber);

            for (int i = 0; i < resultedBinary.Length; i++)
            {
                if ((GetElem(firstBinaryNumber, i) == 0) & (GetElem(secondBinaryNumber, i) == 0))
                    resultedBinary[i] = 0;
                else
                    resultedBinary[i] = 1;
            }
            Array.Reverse(resultedBinary);
            return resultedBinary;
        }

        public static byte[] OperatorXOR(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] resultedBinary = GetMaxLength(firstBinaryNumber, secondBinaryNumber);

            for (int i = 0; i < firstBinaryNumber.Length; i++)
            {
                if (((GetElem(firstBinaryNumber, i) == 0) & (GetElem(secondBinaryNumber, i) == 0)) || ((GetElem(firstBinaryNumber, i) == 1) & (GetElem(secondBinaryNumber, i) == 1)))
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

        public static bool OperatorLessThan(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            bool FirstNumberIsLess = false;
            int maxLength = GetMaxLength(firstBinaryNumber, secondBinaryNumber).Length;

            for (int i = 0; i < maxLength; i++)
            {
                if (GetElemForLessThan(firstBinaryNumber, i, maxLength) < GetElemForLessThan(secondBinaryNumber, i,maxLength))
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

        public static byte[] OperationAddition(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] resultedBinaryNumber = GetMaxLength(firstBinaryNumber, secondBinaryNumber);
            byte reminder = 0;

            for (int i = 0; i <= resultedBinaryNumber.Length; i++)
            {
                if ((GetElem(firstBinaryNumber, i) + (GetElem(secondBinaryNumber, i)) >= 2) & (reminder == 0))
                {
                    resultedBinaryNumber[i] = 0;
                    reminder = 1;
                }
                else
                    if ((GetElem(firstBinaryNumber, i) + (GetElem(secondBinaryNumber, i)) >= 2) & (reminder == 1))
                    {
                        resultedBinaryNumber[i] = 1;
                        reminder = 1;
                    }
                    else
                        if ((GetElem(firstBinaryNumber, i) + (GetElem(secondBinaryNumber, i)) < 2) & (reminder == 0))
                        resultedBinaryNumber[i] = (byte)(GetElem(firstBinaryNumber, i) + GetElem(secondBinaryNumber, i));
                        else 
                             if ((GetElem(firstBinaryNumber, i) + (GetElem(secondBinaryNumber, i)) < 2) & (reminder == 1))
                             {
                                 if ((GetElem(firstBinaryNumber, i) + GetElem(secondBinaryNumber, i) + reminder) >= 2)
                                 {
                                     resultedBinaryNumber[i] = 0;
                                     reminder = 1;
                                 }
                                 else
                                 {
                                     resultedBinaryNumber[i] = (byte)(GetElem(firstBinaryNumber, i) + GetElem(secondBinaryNumber, i) + reminder);
                                     reminder = 0;
                                 }
                             }
            }

                return resultedBinaryNumber;
        }

        public static byte[] OperationSubstraction(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] resultedBinaryNumber = GetMaxLength(firstBinaryNumber, secondBinaryNumber);

            return resultedBinaryNumber;
        }

        private static byte[] GetMaxLength(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] resultedBinary = new byte[0];
            if ((firstBinaryNumber.Length) > (secondBinaryNumber.Length))
                resultedBinary = new byte[firstBinaryNumber.Length];
            else
                resultedBinary = new byte[secondBinaryNumber.Length];
            return resultedBinary;
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
