using Practice2.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.algorithm
{
    public class GraphAlgorithm
    {
        public static void HandleGraphSearch()
        {
            var element = new List<int>
            {
                0, 1, 2, 3, 4, 5
            };

            var vertices = new int[][]
            {
                new int[]{0, 1, 0, 0, 1, 1},
                new int[]{0, 0, 0, 1, 1, 0},
                new int[]{0, 1, 0, 0, 0, 0},
                new int[]{0, 0, 1, 0, 1, 0},
                new int[]{0, 0, 0, 0, 0, 0},
                new int[]{0, 0, 0, 0, 0, 0}
            };

            var graph = new Graph<int>(element, vertices);

            graph.DFS(element[0]);
            Console.WriteLine("");
            graph.BFS(element[0]);

            var _ = Console.ReadLine();        
        }
    }
}
