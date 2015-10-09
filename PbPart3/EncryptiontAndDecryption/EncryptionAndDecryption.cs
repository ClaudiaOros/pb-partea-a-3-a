using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptiontAndDecryption
{
    public class EncryptionAndDecryption
    {
        public static string EncryptMessage(string message, double numberOfColumns)
        {
            string encryptedMessage= "";
            int messageLength = message.Length;
            int numberOfLines = (int)Math.Ceiling(messageLength / numberOfColumns);

            for (var i = 0; i < numberOfLines; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                {
                    int nr = i + (j * numberOfLines);

                    if (nr < messageLength)                  
                        encryptedMessage += message[nr];                   
                    else
                    {
                        encryptedMessage += PickRandomLetter();
                    }
                }
            }
                return encryptedMessage;
        }

        public static char PickRandomLetter()
        {
            Random r = new Random();

            int position = r.Next(0, 26);
            char letter =(char) ('a'+position);

            return letter;
        }
    }
}
