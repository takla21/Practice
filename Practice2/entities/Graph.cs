using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class Graph<T>
    {
        private Dictionary<T, GraphNode<T>> _nodes { get; }
        private HashSet<T> _visited { get; set; }

        public Graph()
        {
            _nodes = new Dictionary<T, GraphNode<T>>();
        }

        public Graph(List<T> elements, int[][] vertices)
        {
            _nodes = new Dictionary<T, GraphNode<T>>();

            foreach (T element in elements)
            {
                _nodes.Add(element, new GraphNode<T>(element));
            }

            for (int i =0; i < elements.Count(); i++)
            {
                var from = elements[i];
                for (int j = 0; j < elements.Count(); j++)
                {
                    if (vertices[i][j] == 1)
                    {
                        var to = elements[j];
                        _nodes[from].AddChild(_nodes[to]);
                    }
                }
            }
        }

        public GraphNode<T> FindNode(T element)
        {
            return _nodes[element];
        }

        public void DFS(T start)
        {
            _visited = new HashSet<T>();
            DFS(_nodes[start]);
            Console.WriteLine("");
        }

        public void BFS(T start)
        {
            var queue = new Queue<GraphNode<T>>();
            _visited = new HashSet<T>();
            var node = _nodes[start];
            queue.Enqueue(node);
            _visited.Add(node.Value);
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.Write($"{node.Value} -> ");
                foreach (GraphNode<T> child in node.Children)
                {
                    if (!_visited.Contains(child.Value))
                    {
                        _visited.Add(child.Value);
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private void DFS(GraphNode<T> node)
        {
            if (!_visited.Contains(node.Value))
            {
                _visited.Add(node.Value);
                Console.Write($"{node.Value} -> ");
                foreach (GraphNode<T> child in node.Children)
                {
                    DFS(child);
                }
            }
        }
    }

    public class GraphNode<T>
    {
        public T Value { get; }
        public List<GraphNode<T>> Children { get; }

        public GraphNode(T value)
        {
            Value = value;
            Children = new List<GraphNode<T>>();
        }

        public void AddChild(GraphNode<T> child)
        {
            Children.Add(child);
        }
    }
}
