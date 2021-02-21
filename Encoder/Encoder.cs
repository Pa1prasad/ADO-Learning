using System;
using System.Text;

namespace Encoder
{
    public class EncoderProcessor
    {
        public string Encode(string message)
        {
            StringBuilder encodedMessage;
            try
            {
                string data = message.ToLower();
                data = ReverseNumbers(data);
                data = ReplaceVowels(data);

                encodedMessage = new StringBuilder(data);

                for (int i = 0; i < encodedMessage.Length; i++)
                {
                    char ch = encodedMessage[i];
                    if (Char.IsLetter(ch) || Char.IsWhiteSpace(ch))
                    {
                        char replacedChar;
                        if (ch == ' ')
                        {
                            replacedChar = 'y';
                        }
                        else if (ch == 'y')
                        {
                            replacedChar = ' ';
                        }
                        else
                        {
                            replacedChar = (char)(ch - 1);
                        }
                        encodedMessage[i] = replacedChar;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return encodedMessage.ToString();
        }
        private string ReplaceVowels(string message)
        {
            try
            {
                if (message.Contains('a'))
                {
                    message = message.Replace('a', '1');
                }
                if (message.Contains('e'))
                {
                    message = message.Replace('e', '2');
                }
                if (message.Contains('i'))
                {
                    message = message.Replace('i', '3');
                }
                if (message.Contains('o'))
                {
                    message = message.Replace('o', '4');
                }
                if (message.Contains('u'))
                {
                    message = message.Replace('u', '5');
                }
            }
            catch
            {
                throw;
            }
            
            return message;
        }

        private string ReverseNumbers(string message)
        {
            try
            {
                string numericals = string.Empty;

                for (int i = 0; i < message.Length; i++)
                {
                    if (Char.IsDigit(message[i]))
                    {
                        numericals += message[i];
                    }
                    else
                    {
                        if (numericals != string.Empty)
                        {
                            int Number = int.Parse(numericals);
                            int Reverse = 0;
                            while (Number > 0)
                            {
                                int remainder = Number % 10;
                                Reverse = (Reverse * 10) + remainder;
                                Number = Number / 10;
                            }
                            message = message.Replace(numericals, Reverse.ToString());
                            numericals = string.Empty;
                        }
                    }
                }
                if (numericals != string.Empty)
                {
                    int Number = int.Parse(numericals);
                    int Reverse = 0;
                    while (Number > 0)
                    {
                        int remainder = Number % 10;
                        Reverse = (Reverse * 10) + remainder;
                        Number = Number / 10;
                    }
                    message = message.Replace(numericals, Reverse.ToString());
                }
            }
            catch
            {
                throw;
            }
            
            return message;
        }
        
    }
}