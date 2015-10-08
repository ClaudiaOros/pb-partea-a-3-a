using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptiontAndDecryption
{
    public class EncryptionAndDecryption
    {
        public static string EncryptMessage(string message, double numberOfColumns, int messageLength, int numberOfLines)
        {
            string encryptedMessage= "";

            for (var i = 0; i < numberOfLines; i++)
            {
                for (var j = 0; j < numberOfColumns; j++)
                {
                    int nr = i + (j * numberOfLines);

                    if (nr < messageLength)                  
                        encryptedMessage = encryptedMessage + message[nr];                   
                    else
                    {
                        var randomLetter = PickRandomLetter();
                        encryptedMessage = encryptedMessage + randomLetter;
                    }
                }
            }
                return encryptedMessage;
        }

        public static string PickRandomLetter()
        {
            String[] alphabet = {
                                        "A","B","C","D","E","F","G","H","I","J","K","L","M",
                                        "N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
                                };

            Random r = new Random();

            int position = r.Next(0, 26);
            string letter = alphabet[position];

            return letter;
        }
    }
}
