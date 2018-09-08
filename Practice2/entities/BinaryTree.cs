using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> _root { get; set; }
        private int _size { get; set; }

        public BinaryTree()
        {
            _root = null;
            _size = 0;
        }

        public BinaryTree(T[] sortedElement)
        {
            _root = InitBinaryTreeFromSortedArray(sortedElement, 0, sortedElement.Length - 1);
            _size = sortedElement.Length;
        }

        private Node<T> InitBinaryTreeFromSortedArray(T[] element, int i, int j)
        {
            var size = j - i + 1;
            if (size <= 3)
            {
                var nodes = new Node<T>[size];
                for (int k = 0; k < size; k++)
                {
                    nodes[k] = new Node<T>(element[i + k], 2);
                }
                Node<T> node;
                switch (size)
                {
                    case 1:
                        return nodes[0];
                    case 2:
                        node = nodes[1];
                        nodes[1].Children[0] = nodes[0];
                        return node;
                    case 3:
                        node = nodes[1];
                        nodes[1].Children[0] = nodes[0];
                        nodes[1].Children[1] = nodes[2];
                        return node;
                    default:
                        return null;
                }
            }
            else
            {
                int m = size / 2;
                Node<T> root;
                if (size % 2 == 0)
                {
                    root = new Node<T>(element[--m], 2);
                }
                else
                {
                    root = new Node<T>(element[m], 2);
                }
                var left = InitBinaryTreeFromSortedArray(element, i, m - 1);
                var right = InitBinaryTreeFromSortedArray(element, m + 1, j);
                root.Children[0] = left;
                root.Children[1] = right;
                return root;
            }
        }

        public void Add(T element)
        {
            Add(_root, element);
            _size++;
        }

        public void OrderTraversal()
        {
            OrderTraversal(_root);
            Console.WriteLine();
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(_root);
            Console.WriteLine();
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(_root);
            Console.WriteLine();
        }

        public int Height()
        {
            return Height(_root);
        }

        public Node<T> GetElement(int index)
        {
            var i = _size / 2;
            if (_size % 2 == 0)
            {
                i--;
            }
            return GetElement(_root, index, i);
        }

        public Node<T> GetRandomNode()
        {
            var rand = new Random();
            var index = rand.Next(_size);
            return GetElement(index);
        }

        private void OrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                OrderTraversal(node.Children[0]);
                Console.Write(node.Value + ", ");
                OrderTraversal(node.Children[1]);
            }
        }

        private void PreOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Value + ", ");
                PreOrderTraversal(node.Children[0]);
                PreOrderTraversal(node.Children[1]);
            }
        }

        private void PostOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Children[0]);
                PostOrderTraversal(node.Children[1]);
                Console.Write(node.Value + ", ");
            }
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Math.Max(Height(node.Children[0]), Height(node.Children[1])) + 1;
            }
        }

        private void Add(Node<T> node, T element)
        {
            if (node == null)
            {
                node = new Node<T>(element, 2);
            }

            if (node.Value.CompareTo(element) != 0)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    Add(node.Children[1], element);
                }
                else
                {
                    Add(node.Children[0], element);
                }
            }
        }

        private Node<T> GetElement(Node<T> node, int index, int i)
        {
            if (index == i)
            {
                return node;
            }

            if (i >= _size)
            {
                return null;
            }

            if (i > index)
            {
                return GetElement(node.Children[0], index, i - 1);
            }
            else
            {
                return GetElement(node.Children[1], index, i + 1);
            }
        }
    }
}
