using Practice2.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.algorithm
{
    public class DataStuctureAlgorithm
    {
        public static void HandleLinkedListSum()
        {
            Console.WriteLine("Enter 2 number: xxx yyy");
            string line = Console.ReadLine();

            var firstNumber = line.Substring(0, 3);
            var secondNumber = line.Substring(4, 3);

            LinkedList<int> firstValue = new LinkedList<int>();
            LinkedList<int> secondValue = new LinkedList<int>();

            firstValue.AddFirst(Convert.ToInt32(char.GetNumericValue(firstNumber[0])));
            firstValue.AddFirst(Convert.ToInt32(char.GetNumericValue(firstNumber[1])));
            firstValue.AddFirst(Convert.ToInt32(char.GetNumericValue(firstNumber[2])));

            secondValue.AddFirst(Convert.ToInt32(char.GetNumericValue(secondNumber[0])));
            secondValue.AddFirst(Convert.ToInt32(char.GetNumericValue(secondNumber[1])));
            secondValue.AddFirst(Convert.ToInt32(char.GetNumericValue(secondNumber[2])));

            var result = LinkedListSum(firstValue, secondValue).Last;

            while (result != null)
            {
                Console.Write(result.Value);
                result = result.Previous;
            }
        }

        public static void HandleCustomStack()
        {
            var stack = new CustomStack<int>();
            stack.Stack(1);
            stack.Stack(2);
            stack.Stack(3);
            Console.WriteLine(stack);
            var min = stack.Min();
            Console.WriteLine(min);
        }

        public static void HandleSortedBinaryTree()
        {
            var element = new int[]
            {
                1, 2, 3, 4, 5, 6, 7
            };

            var element1 = new int[]
            {
                1, 2, 3, 4, 5, 6
            };

            var element2 = new int[]
            {
                1, 2, 3, 4, 5
            };

            var element3 = new int[]
            {
                1, 2, 3, 4
            };

            var element4 = new int[]
            {
                1, 2, 3
            };

            var binaryTree = new BinaryTree<int>(element);
            var binaryTree1 = new BinaryTree<int>(element1);
            var binaryTree2 = new BinaryTree<int>(element2);
            var binaryTree3 = new BinaryTree<int>(element3);
            var binaryTree4 = new BinaryTree<int>(element4);

            binaryTree.PreOrderTraversal();
            Console.WriteLine($"Height {binaryTree.Height()}");
            binaryTree1.PreOrderTraversal();
            Console.WriteLine($"Height {binaryTree1.Height()}");
            binaryTree2.PreOrderTraversal();
            Console.WriteLine($"Height {binaryTree2.Height()}");
            binaryTree3.PreOrderTraversal();
            Console.WriteLine($"Height {binaryTree3.Height()}");
            binaryTree4.PreOrderTraversal();
            Console.WriteLine($"Height {binaryTree4.Height()}");

            for (int i =0; i < 10; i++)
            {
                var r = binaryTree.GetRandomNode().Value;
                Console.WriteLine($"Random value {r}");
            }
        }

        private static LinkedList<int> LinkedListSum(LinkedList<int> first, LinkedList<int> second)
        {
            var resultLinkedList = new LinkedList<int>();

            var firstNode = first.First;
            var secondNode = second.First;
            var carried = 0;

            while (firstNode != null || secondNode != null)
            {
                var result = firstNode.Value + secondNode.Value + carried;
                if (result > 9)
                {
                    result = result % 10;
                    carried = 1;
                }
                else
                {
                    carried = 0;
                }

                resultLinkedList.AddLast(result);

                firstNode = firstNode.Next;
                secondNode = secondNode.Next;
            }

            if (carried == 1)
            {
                resultLinkedList.AddLast(carried);
            }

            return resultLinkedList;
        }
    }
}
