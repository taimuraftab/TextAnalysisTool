using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;


namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BinTree binTree = new BinTree();

            readDisplayFileWords(binTree);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. The number of unique words");
                Console.WriteLine("2. All words with frequencies – any order ");
                Console.WriteLine("3. All words with frequencies in alphabetical order");
                Console.WriteLine("4. The longest word");
                Console.WriteLine("5. Most frequent word");
                Console.WriteLine("6. Display the word frequency & its line number");
                Console.WriteLine("7. Exit");
                Console.Write("\n");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Total unique words: " + binTree.Count());
                        break;
                    case "2":
                        binTree.PostOrder();
                        break;
                    case "3":
                        binTree.InOrder();
                        break;
                    case "4":
                        binTree.LongestWordStored();
                        break;
                    case "5":
                        binTree.MostFrequentWord();
                        break;
                    case "6":
                        Console.Write("Enter the word: ");
                        string word = Console.ReadLine(); 
                        
                        binTree.FileLineNumber(word);
                        binTree.WordFrequency(word);
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        static void readDisplayFileWords(BinTree binTree)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "sherlockHolmes.txt");
            string[] linesInFile = File.ReadAllLines(path);

            int lineNumber = 0;

            char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };

            foreach (string line in linesInFile)
            {
                lineNumber++;

                string[] wordsInLine = line.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
                Console.Write(lineNumber + ":");
                foreach (string word in wordsInLine)
                {
                    if (isWord(word))
                        binTree.InsertWord(word.ToLower(), lineNumber);
                    Console.Write(word.ToLower() + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");

        }


        static Boolean isWord(string str)
        {
            return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
        }
    }
}
