using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LettersCounter
{
    public static class NodeModelUtilities
    {
        public static Dictionary<char, int> GetAlphabetDictionary()
        {
            Dictionary<char, int> alphabetDictionary = new Dictionary<char, int>(); 
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                alphabetDictionary.Add(letter, 0);
            }

            return alphabetDictionary;
        }

        public static Dictionary<char, int> CountLettersInElement(string textElement, Dictionary<char, int> lettersDictionary)
        {
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                foreach (var word in textElement)
                {
                    if (word == letter)
                    {
                        lettersDictionary[letter]++;
                    }
                }
            }
            return lettersDictionary;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static void DisplayResult(Dictionary<string, int> words, Dictionary<char,int> letters, int imgCount)
        {
            Console.Clear();
            ConsoleWriteWhiteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Words found:");
            foreach (var word in words)
            {
                Thread.Sleep(1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(word.Value + " ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(word.Key + "\n");

            }

            ConsoleWriteWhiteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Letters counter:");
            foreach (var letter in letters)
            {
                Thread.Sleep(1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(letter.Key + ": ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(letter.Value + "\n");
            }

            ConsoleWriteWhiteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Image tags found: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(imgCount + "\n");
            ConsoleWriteWhiteLine();
        }

        public static void ConsoleWriteWhiteLine()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string('=', 70));
        }
    }
}
