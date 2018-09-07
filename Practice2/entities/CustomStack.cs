using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.entities
{
    public class CustomStack<T> where T : IComparable<T>
    {
        private Node<T> _root { get; set; }
        private int _size { get; set; }
        private const int DEFAULT_SIZE = 2;
        private T _min { get; set; }

        public CustomStack()
        {
            _root = default(Node<T>);
            _size = DEFAULT_SIZE;
        }

        public void Stack(T element)
        {
            if (_root == null)
            {
                _root = new Node<T>(element, 1);
            }
            else
            {
                var node = new Node<T>(element, 1);
                node.Children[0] = new Node<T>(_root);
                _root = node;
            }
            UpdateMin(element);
        }

        public T UnStack()
        {
            var element = _root.Value;
            var node = _root.Children[0];
            _root = node;
            return element;
        }

        public T Min()
        {
            return _min;
        }

        public override string ToString()
        {
            return $"[ {ToString(_root)} ]";
        }

        private void UpdateMin(T element)
        {
            if (_min.CompareTo(default(T)) == 0)
            {
                _min = element;
            }
            else
            {
                if (_min.CompareTo(element) > 0)
                {
                    _min = element;
                }
            }
        }

        private string ToString(Node<T> node)
        {
            if (node == null)
            {
                return "";
            }
            else
            {
                return $"{node.Value.ToString()}, {ToString(node.Children[0])}";
            }

        }
    }
}
