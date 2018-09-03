using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class StateMachine
    {
        private class Node
        {
            public char Value { get; }
            public Dictionary<char, Node> Children { get; }
            public bool IsEndNode { get; }

            public Node(char value)
            {
                Value = value;
                Children = new Dictionary<char, Node>();
                IsEndNode = false;
            }

            public Node(char value, bool isEndNode)
            {
                Value = value;
                Children = new Dictionary<char, Node>();
                IsEndNode = isEndNode;
            }
        }

        private Node _root { get; set; }

        public StateMachine(char defaultValue)
        {
            _root = new Node(defaultValue);
        }

        public void AddElement(string word)
        {
            AddElement(word, _root, 0);
        }

        public bool ValidWord(string word)
        {
            return ValidWord(word, _root, 0);
        }

        private void AddElement(string word, Node node, int count)
        {
            var n = node;
            if (count >= word.Length)
            {
                return;
            }

            var c = word[count];
            if (!node.Children.ContainsKey(c))
            {
                node.Children.Add(c, new Node(c, count == word.Length - 1));
            }
            AddElement(word, node.Children[c], count + 1);
        }

        private bool ValidWord(string word, Node node, int count)
        {
            if (count >= word.Length)
            {
                return false;
            }

            var c = word[count];
            if (!node.Children.ContainsKey(c))
            {
                return false;
            }
            return node.Children[c].IsEndNode || ValidWord(word, node.Children[c], count + 1);
        }
    }
}
