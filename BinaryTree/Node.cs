using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Node
    {
        private string data;
        public Node Left, Right;
        public int Count;
        public List<int> LineNumbers;

        public Node(string word, int linenumber) 
        {
            this.data = word.ToLower();
            this.Count = 1;
            this.LineNumbers = new List<int> { linenumber };
            Left = null;
            Right = null;
        }

        public string Data
        {
            get { return data; }
            set { data = value.ToLower(); }
        }
    }
}

