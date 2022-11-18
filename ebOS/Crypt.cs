using System;

namespace ebOS
{
    public class Encrypt
    {
        static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)(((ch + key - d) % 26) + d);


        }
        static char cipher1(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)(((ch - key - d) % 26) + d);
        }
        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }
        public static string Decipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher1(ch, key);

            return output;
        }
        public static void Run()
        {
            Console.Write("Encrypt or decrypt? ");
            string input = Console.ReadLine();
            if (input == "encrypt")
            {
                try
                {
                    Console.Write("text: ");
                    string textinput = Console.ReadLine();
                    Console.Write("key: ");
                    string keyinput = Console.ReadLine();
                    Console.WriteLine("Encrypted: " + Encrypt.Encipher(textinput, int.Parse(keyinput)));
                }
                catch (Exception)
                {
                    Console.WriteLine("Key must be a number!");
                }
            }
            if (input == "decrypt")
            {
                try
                {
                    Console.Write("text: ");
                    string textinput = Console.ReadLine();
                    Console.Write("key: ");
                    string keyinput = Console.ReadLine();
                    Console.WriteLine("Decrypted: " + Encrypt.Decipher(textinput, int.Parse(keyinput)));
                }
                catch (Exception)
                {
                    Console.WriteLine("Key must be a number!");
                }
            }
        }
    }
}