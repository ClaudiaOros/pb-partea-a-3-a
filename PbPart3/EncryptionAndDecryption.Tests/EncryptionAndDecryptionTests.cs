using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncryptionAndDecryption;

namespace EncryptionAndDecryption.Tests
{
    [TestClass]
    public class EncryptionAndDecryptionTests
    {
        [TestMethod]
        public void EncryptMessageNICAIERI_NU_E_CA_ACASA()
        {
            double numberOfColumns = 4;
            string message = "nicaieri nu e ca acasa";
            string expectedEncryptedMessage = "neeaircsciaaana0iuc0";

            message = message.Replace(" ", "");
            int messageLength = message.Length;
            int numberOfLines = (int)Math.Ceiling(messageLength / numberOfColumns);

            string encryptedMessage = EncryptiontAndDecryption.EncryptionAndDecryption.EncryptMessage(message, numberOfColumns, messageLength, numberOfLines);

            int encryptedMessageLength = encryptedMessage.Length;
            var charencryptedMessage = encryptedMessage.ToCharArray();
            charencryptedMessage = ReplaceRandomLettersWith0(numberOfColumns, messageLength, numberOfLines, ref charencryptedMessage, encryptedMessageLength);

           encryptedMessage = new string(charencryptedMessage);

           Assert.AreEqual(expectedEncryptedMessage, encryptedMessage);
        }

        private static char[] ReplaceRandomLettersWith0(double numberOfColumns, int messageLength, int numberOfLines, ref char[] charencryptedMessage, int encryptedMessageLength)
        {
            int howManyLettersAreRandom = (int)(numberOfColumns * numberOfLines - messageLength);

            int i = 0;
            for (int j = encryptedMessageLength-1; j > 0; j--)
            {

                if (j % numberOfColumns == (numberOfColumns-1))
                {
                    charencryptedMessage[j] = '0';
                    i++;
                }
                if (i == howManyLettersAreRandom)
                {
                    break;
                }
            }
            return charencryptedMessage;
        }
    }
}
