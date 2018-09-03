using Practice2.extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.algorithm
{
    public class MatrixAlgorithm
    {
        public static void ZeroMatrix()
        {
            var matrix = new int[][]
            {
                new int[]{ 1, 1, 0},
                new int[]{ 1, 1, 0},
                new int[]{ 1, 1, 1}
            };

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Type coordinate: x y");
            string line = Console.ReadLine();
            int x = Convert.ToInt32(char.GetNumericValue(line[0]));
            int y = Convert.ToInt32(char.GetNumericValue(line[2]));

            ZeroMatrix(x, y, ref matrix);

            Console.WriteLine("");

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public static void TicTacToe()
        {
            const char X = 'x';
            const char O = 'o';
            const char E = '\0';

            var games = new List<char[][]>
            {
                new char[][]
            {
                new char[3]{O, O, X},
                new char[3]{X, O, O},
                new char[3]{O, X, X},
            },
                new char[][]
            {
                new char[3]{O, O, X},
                new char[3]{X, E, X},
                new char[3]{O, X, X},
            },
                new char[][]
            {
                new char[3]{E, E, E},
                new char[3]{X, O, X},
                new char[3]{O, X, O},
            },
                new char[][]
            {
                new char[3]{O, O, X},
                new char[3]{X, O, X},
                new char[3]{O, X, O},
            },
                new char[][]
            {
                new char[3]{O, O, X},
                new char[3]{O, X, O},
                new char[3]{X, X, O},
            }
            };

            foreach (char[][] game in games)
            {
                var ticTacToe = new TicTacToe(game);
                Console.WriteLine("game");
                for (int i = 0; i < game.Length; i++)
                {
                    for (int j = 0; j < game.Length; j++)
                    {
                        Console.Write(game[i][j] + ",");
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("did someone win? " + ticTacToe.IsSomeoneWon());
            }
        }

        private static void ZeroMatrix(int x, int y, ref int[][] matrix)
        {
            if (matrix[x][y] == 0)
            {
                for (var i = 0; i < matrix[x].Length; i++)
                {
                    matrix[x][i] = 0;
                }

                for (var i = 0; i < matrix.Length; i++)
                {
                    matrix[i][y] = 0;
                }
            }
        }
    }
}
