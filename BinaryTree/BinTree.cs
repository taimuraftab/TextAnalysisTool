using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class BinTree
    {
        private Node root;

        public BinTree()
        {
            root = null;
        }

        public BinTree(Node node)
        {
            root = node;

        }
        public void InOrder()
        {
            inOrder(root);
        }

        private void inOrder(Node tree)
        {
            if (tree != null)
            {
                inOrder(tree.Left);
                Console.Write(tree.Data.ToString() + ": " + tree.Count + " occurrences");
                Console.WriteLine("\n");
                inOrder(tree.Right);
            }
        }

        public void InOrderRev()
        {
            inOrderRev(root);
        }

        private void inOrderRev(Node tree)
        {
            if (tree != null)
            {
                inOrderRev(tree.Right);
                Console.Write(tree.Data.ToString() + ": " + tree.Count + " occurrences");
                Console.WriteLine("\n");
                inOrderRev(tree.Left);
            }
        }

        public void PreOrder()
        {
            preOrder(root);
        }

        private void preOrder(Node tree)
        {
            if (tree != null)
            {
                Console.Write(tree.Data.ToString() + ": " + tree.Count + " occurrences");
                Console.WriteLine("\n");
                preOrder(tree.Left);
                preOrder(tree.Right);
            }
        }

        public void PostOrder()
        {
            postOrder(root);
        }

        private void postOrder(Node tree)
        {
            if (tree != null)
            {
                postOrder(tree.Left);
                postOrder(tree.Right);
                Console.Write(tree.Data.ToString() + ": " + tree.Count + " occurrences");
                Console.WriteLine("\n");
            }
        }

        public int Count()
        {
            return count(root);
        }

        private int count(Node tree)
        {
            if (tree == null)
            {
                return 0;
            }
            else
            {
                return count(tree.Left) + count(tree.Right) + 1;
            }
        }

        public void InsertWord(string word, int line)
        {
            root = insertWord(root, word, line);
        }

        private Node insertWord(Node tree, string word, int line)
        {

            if (tree == null)
            {
                return new Node(word, line);
            }

            if (word.CompareTo(tree.Data) == 0) 
            {
                tree.Count++;
                if (!tree.LineNumbers.Contains(line))
                {
                    tree.LineNumbers.Add(line);
                }
            }
            else if (word.CompareTo(tree.Data) < 0)
            {
                tree.Left = insertWord(tree.Left, word, line);
            }
            else
            {
                tree.Right = insertWord(tree.Right, word, line);
            }

            return tree;
        }

        public void LongestWordStored()
        {
            int length = 0;
            string word = "";
            int count = 0;

            longestWordStored(root, ref word, ref length, ref count);

            if (word != "")
            {
                Console.WriteLine("The longest word is: " + word + ", and its occurrences is: " + count);
            }
        }

        private void longestWordStored(Node tree, ref string word, ref int length, ref int count)
        {
            if (tree != null)
            {
                if (tree.Data.Length > length)
                {
                    length = tree.Data.Length;
                    word = tree.Data;
                    count = tree.Count;
                }

                longestWordStored(tree.Left, ref word, ref length, ref count);
                longestWordStored(tree.Right, ref word, ref length, ref count);
            }
        }

        public void MostFrequentWord()
        {
            List<string> WordList = new List<string>();
            int Occurence = 0;

            mostFrequentWord(root, WordList, ref Occurence);

            if (WordList.Count > 0)
            {
                Console.WriteLine("\nThe most frequent word/s:");
                foreach (string word in WordList)
                {
                    Console.WriteLine($"{word}: {Occurence} occurrences");
                }
            }
        }

        private void mostFrequentWord(Node tree, List<string> WordList, ref int Occurence)
        {
            if (tree != null)
            {
                if (tree.Count > Occurence)
                {
                    Occurence = tree.Count;
                    WordList.Clear();
                    WordList.Add(tree.Data);
                }
                else if (tree.Count == Occurence)
                {
                    WordList.Add(tree.Data);
                }

                mostFrequentWord(tree.Left, WordList, ref Occurence);
                mostFrequentWord(tree.Right, WordList, ref Occurence);
            }
        }

        public void FileLineNumber(string word)
        {
            var lines = fileLineNumber(root, word.ToLower());

            if (lines.Count > 0)
            {
                Console.WriteLine($"\nThe word '{word}' appears on the following lines: ");
                foreach (int line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine($"\nThe word '{word}' was not found in the text.");
            }
        }

        private List<int> fileLineNumber(Node tree, string word)
        {
            List<int> lines = new List<int>();

            if (tree != null)
            {
                if (tree.Data == word)
                {
                    foreach (var line in tree.LineNumbers)
                    {
                        lines.Add(line);
                    }
                }
              
                var leftTree = fileLineNumber(tree.Left, word);
                foreach (var leftLines in leftTree)
                {
                    lines.Add(leftLines);
                }

                var rightTree = fileLineNumber(tree.Right, word);
                foreach (var rightLines in rightTree)
                {
                    lines.Add(rightLines);
                }
            }

            return lines;
        }


        public void WordFrequency(string word)
        {
            Node node = wordFrequency(root, word.ToLower());

            if (node != null)
            {
                Console.WriteLine("The word " + word + " appears " + node.Count + " times.");
            }
            else
            {
                Console.WriteLine("Ops! It's not matching with any text.");
            }
        }

        private Node wordFrequency(Node tree, string word)
        {
            if (tree == null)
            {
                return null;
            }

            if (word.CompareTo(tree.Data) == 0)
            {
                return tree;
            }
            else if (word.CompareTo(tree.Data) < 0)
            {
                return wordFrequency(tree.Left, word);
            }
            else
            {
                return wordFrequency(tree.Right, word);
            }
        }
    }
}
