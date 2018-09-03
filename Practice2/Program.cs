using Practice2.algorithm;
using Practice2.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            var actions = new List<Action>
            {
                Algorithm.HandleLinkedListSum,
                Algorithm.HandlePeople,
                Algorithm.HandleDialNumberWord,
                MatrixAlgorithm.TicTacToe,
                MatrixAlgorithm.ZeroMatrix,
                ThreadAlgorithm.HandleFizzBuzz,
                GraphAlgorithm.HandleGraphSearch
            };

            string _;

            foreach (Action action in actions)
            {
                Console.WriteLine("Click y to execute " + action.Method.Name + "?");
                var c = Console.ReadKey();
                Console.Clear();
                if (c.KeyChar == 'y')
                {
                    action();
                    _ = Console.ReadLine();
                }
                Console.Clear();
            }
            Console.WriteLine("Done!");
            _ = Console.ReadLine();
        }
    }
}
