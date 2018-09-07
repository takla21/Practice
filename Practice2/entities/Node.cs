using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class Node<T>
    {
        public T Value { get; }
        public List<Node<T>> Children { get; }

        public Node(T value)
        {
            Value = value;
            Children = new List<Node<T>>();
        }

        public Node(T value, int size)
        {
            Value = value;
            Children = new List<Node<T>>(2);
            for (int i = 0; i < size; i++)
            {
                Children.Add(default(Node<T>));
            }
        }

        public Node(Node<T> node)
        {
            Value = node.Value;
            Children = node.Children;
        }

        public void AddChild(Node<T> child)
        {
            Children.Add(child);
        }
    }
}
