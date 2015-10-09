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
            int numberOfColumns = 4;
            string message = "nicaieri nu e ca acasa";
            string expectedEncryptedMessage = "neeaircsciaaana0iuc0";

            message = message.Replace(" ", "");
            int messageLength = message.Length;
            int numberOfLines = (int)Math.Ceiling((double)messageLength / numberOfColumns);

            string encryptedMessage = EncryptiontAndDecryption.EncryptionAndDecryption.EncryptMessage(message, numberOfColumns);

            int encryptedMessageLength = encryptedMessage.Length;
            var charencryptedMessage = encryptedMessage.ToCharArray();
            charencryptedMessage = ReplaceRandomLettersWith0(numberOfColumns, messageLength, numberOfLines, ref charencryptedMessage, encryptedMessageLength);

           encryptedMessage = new string(charencryptedMessage);

           Assert.AreEqual(expectedEncryptedMessage, encryptedMessage);
        }

        [TestMethod]
        public void DecryptMessageNEEAIRCSCIAAANA0IUC0()
        {
            int numberOfColumns = 4;
            string encryptedMessage = "NEEAIRCSCIAAANA0IUC0";
            string expectedDecryptedMessage = "NICAIERINUECAACASA";

            int encryptedMessageLength = encryptedMessage.Length;
            int numberOfLines = encryptedMessageLength / numberOfColumns;

            string decryptedMessage = EncryptiontAndDecryption.EncryptionAndDecryption.DecryptMessage(encryptedMessage, numberOfColumns);

            decryptedMessage = CreateDecryptedMessages(numberOfColumns, expectedDecryptedMessage, numberOfLines, decryptedMessage);

            Assert.AreEqual(expectedDecryptedMessage, decryptedMessage);
        }

        private static string CreateDecryptedMessages(int numberOfColumns, string expectedDecryptedMessage, int numberOfLines, string decryptedMessage)
        {
            string[] messages = new string[numberOfLines];
            messages[0] = decryptedMessage;
            for (int i = 1; i < numberOfColumns; i++)
            {
                for (int j = (decryptedMessage.Length - numberOfColumns); j < decryptedMessage.Length; j++)
                {
                    messages[i] = decryptedMessage.Remove(decryptedMessage.Length - i);
                }
            }

            for (int i = 0; i < numberOfColumns; i++)
            {
                if (messages[i].Length == expectedDecryptedMessage.Length)
                {
                    decryptedMessage = messages[i];
                }
            }
            return decryptedMessage;
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
