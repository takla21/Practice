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
        }
    }
}
