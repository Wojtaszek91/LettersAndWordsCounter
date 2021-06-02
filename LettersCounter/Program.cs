using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

namespace LettersCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            #region InitPhase
            var url = "http://html-agility-pack.net/";
            HtmlDocument doc;
            var web = new HtmlWeb();
            Dictionary<string, int> words = new Dictionary<string, int>();
            Dictionary<char, int> letters = NodeModelUtilities.GetAlphabetDictionary();

            try
            {
                doc = web.Load(url);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seems like url is incorrect or unaccessable, please try again with another !");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(e.Message);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            #endregion InitPhase

            #region ParseAndDisplay
            var filteredNodes = doc.DocumentNode.Descendants().Where(node => node.Name == "p" || node.Name == "div")
            .Select(node =>
            {
                var wordsArray = node.GetDirectInnerText().Replace("\r", " ").
                Replace("\n", " ")
                .Trim()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                return new NodeModel(node.Name, wordsArray);
            })
            .ToArray();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Counting words and letters for " + url);
            NodeModelUtilities.ConsoleWriteWhiteLine();

            if (filteredNodes.Length > 0)
            {
                foreach (var node in filteredNodes)
                {
                    for (int i = 0; i < node.Words.Length; i++)
                    {
                        Thread.Sleep(1);
                        if (!words.ContainsKey(node.Words[i]))
                        {
                            words.Add(node.Words[i], 1);
                        }
                        else
                        {
                            words[node.Words[i]]++;
                        }
                        letters = NodeModelUtilities.CountLettersInElement(node.Words[i], letters);
                    }
                }

                int imagesCount = doc.DocumentNode.Descendants().Count(node => node.Name == "img");

                NodeModelUtilities.DisplayResult(words,letters, imagesCount);
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, we coudn't find any div or p elements !");
                Console.ForegroundColor = ConsoleColor.White;
            }

            #endregion ParseAndDisplay
        }
    }
}
