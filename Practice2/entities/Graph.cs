using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class Graph<T>
    {
        public Node<T> Root { get; internal set; }
        private readonly Dictionary<T, Node<T>> graphStatus;

        public Graph()
        {
            Root = null;
            graphStatus = new Dictionary<T, Node<T>>();
        }

        public Graph(T[] elements, int[][] vertices)
        {
            graphStatus = new Dictionary<T, Node<T>>();

            foreach (T e in elements)
            {
                graphStatus.Add(e, new Node<T>(e));
            }

            for (int i = 0; i < elements.Length; i++)
            {
                var from = graphStatus[elements[i]];
                for (int j = 0; j < elements.Length; j++)
                {
                    if (vertices[i][j] != 0)
                    {
                        var to = graphStatus[elements[j]];
                        from.AddChildren(to);
                    }
                }
            }

            Root = graphStatus[elements[0]];
        }

        public void ChangeRoot(T element)
        {
            if (graphStatus.ContainsKey(element))
            {
                Root = graphStatus[element];
            }
        }
    }

    public class Node<T>
    {
        public T Value { get; }
        public List<Node<T>> Neighboors { get; }

        public Node(T value)
        {
            Value = value;
            Neighboors = new List<Node<T>>();
        }

        public void AddChildren(Node<T> node)
        {
            Neighboors.Add(node);
        }
    }
}
