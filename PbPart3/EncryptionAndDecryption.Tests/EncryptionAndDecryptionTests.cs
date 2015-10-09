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
            string expectedDecryptedMessage = "NICAIERINUECAACASA00";

            int encryptedMessageLength = encryptedMessage.Length;
            int numberOfLines = encryptedMessageLength / numberOfColumns;

            string decryptedMessage = EncryptiontAndDecryption.EncryptionAndDecryption.DecryptMessage(encryptedMessage, numberOfColumns);

            Assert.AreEqual(expectedDecryptedMessage, decryptedMessage);
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
