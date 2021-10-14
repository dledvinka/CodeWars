namespace CodeWars.ConsoleApp
{
    public class SimpleEncryption01
    {
        public static string Encrypt(string text, int n)
        {
            if (string.IsNullOrWhiteSpace(text) || n <= 0)
            {
                return text;
            }

            string resultString = text;

            for (int i = 0; i < n; i++)
            {
                string evens = string.Empty;
                string odds = string.Empty;

                for (int j = 0; j < resultString.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        evens += resultString[j].ToString();
                    }
                    else
                    {
                        odds += resultString[j].ToString();
                    }
                }

                resultString = odds + evens;
            }

            return resultString;
        }

        public static string Decrypt(string encryptedText, int n)
        {
            if (string.IsNullOrWhiteSpace(encryptedText) || n <= 0)
            {
                return encryptedText;
            }

            string resultString = encryptedText;

            for (int i = 0; i < n; i++)
            {
                int oddsCount = resultString.Length / 2;
                int evensCount = resultString.Length - oddsCount;

                string odds = resultString.Substring(0, oddsCount);
                string evens = resultString.Substring(oddsCount);
                string decrypted = string.Empty;

                for (int j = 0; j < evensCount; j++)
                {
                    decrypted += evens[j];
                    
                    if (j < odds.Length)
                    {
                        decrypted += odds[j];
                    }
                }

                resultString = decrypted;
            }

            return resultString;
        }
    }
}