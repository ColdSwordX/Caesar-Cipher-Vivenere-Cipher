using System;
using System.Collections.Generic;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What is the message");
                string message = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("How mutch would you like to shift with?");

                // ---- Viginar Cipher ----
                string shift = Console.ReadLine();
                Console.Write("Encrypted: ");
                string encrypyted = veginareCipherEncrypter(message, shift);
                Console.WriteLine(encrypyted);
                Console.Write("Decrypted: ");
                Console.WriteLine(veginareCipherDecrypter(encrypyted, shift));

                // ---- Caesar Cipher ----
                //int shift = NumberChecker();
                //string encripted = CaesarCipherEncrypter(message, shift);
                //Console.Write("Encrypted: ");
                //Console.WriteLine(encripted);
                //Console.Write("Decrypted: ");
                //Console.WriteLine(CaesarCipherDecipher(encripted, shift));
                //Console.WriteLine();
            }
        }
        static string CaesarCipherEncrypter(string _value, int _shift)
        {
            string output = string.Empty;

            foreach (char ch in _value)
                output += Cipher(ch, _shift);

            return output;
        }
        static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch - d) + key) % 26) + d);
        }
        static int NumberChecker()
        {
            bool isNumber;
            int value;
            do
            {
                isNumber = int.TryParse(Console.ReadLine(), out value);
                if (!isNumber)
                {
                    Console.WriteLine("Must be a number");
                }
                if (value > int.MaxValue || value < int.MinValue)
                {
                    Console.WriteLine($"The number must be within the int's min value({int.MinValue}) and max value({int.MaxValue})");
                }

            } while (isNumber == false);

            return value % 26;
        }
        static string CaesarCipherDecipher(string _value, int _shift)
        {
            return CaesarCipherEncrypter(_value, 26 - _shift);
        }
        /// <summary>
        /// Encryption for Vegenere Cipher
        /// </summary>
        /// <param name="_value">The message to be encrypted</param>
        /// <param name="_shift">What Key should be use to encrypt with</param>
        /// <returns>The encrypted message</returns>
        static string veginareCipherEncrypter(string _value, string _shift)
        {
            string output = string.Empty;

            for (int i = 0; i < _value.Length; i++)
            {
                if (!char.IsLetter(_value[i]))
                {
                    output += _value[i];
                }
                else
                {
                    int upper = char.IsUpper(_value[i]) ? 'A' : 'a';
                    int charValue = ((_value[i] - upper) + _shift[i % _shift.Length]) % 26;
                    charValue += upper;
                    output += (char)charValue;
                }
            }            
            return output;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_value"></param>
        /// <param name="_shift"></param>
        /// <returns></returns>
        static string veginareCipherDecrypter(string _value, string _shift)
        {
            string output = string.Empty;

            for (int i = 0; i < _value.Length; i++)
            {
                if (!char.IsLetter(_value[i]))
                {
                    output += _value[i];
                }
                else
                {
                    int upper = char.IsUpper(_value[i]) ? 'A' : 'a';
                    int charValue = _value[i] - upper - _shift[i % _shift.Length];
                    charValue = charValue % 26;
                    if (charValue < 0)
                    {
                        charValue += 26;
                    }
                    charValue += upper;
                    output += (char)charValue;
                }
            }
            return output;
        }
    }
}
