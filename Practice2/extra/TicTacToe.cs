using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.extra
{
    public class TicTacToe
    {
        public char[][] Game { get; }

        public TicTacToe(char[][] game)
        {
            Game = game;
        }

        public bool IsSomeoneWon()
        {
            var someoneWin = false;
            for (int i = 0; i < Game.Length; i++)
            {
                for (int j = 0; j < Game[i].Length; j++)
                {
                    char c = Game[i][j];
                    if (c != '\0')
                    {
                        someoneWin = someoneWin || SomeoneWon(i, j, c, 0, 1, 0); // left
                        someoneWin = someoneWin || SomeoneWon(i, j, c, 1, 0, 0); // down
                        someoneWin = someoneWin || SomeoneWon(i, j, c, 1, 1, 0); // />
                        someoneWin = someoneWin || SomeoneWon(i, j, c, 1, -1, 0); // </
                        if (someoneWin)
                        {
                            return someoneWin;
                        }
                    }
                }
            }
            return someoneWin;
        }

        private bool SomeoneWon(int i, int j, char c, int dx, int dy, int cpt)
        {
            int x = i + dx;
            int y = j + dy;
            if (cpt == 2)
            {
                return true;
            }
            if ((x < 0 || x >= Game.Length) || (y < 0 || y >= Game.Length))
            {
                return false;
            }
            if (Game[x][y] == c)
            {
                return SomeoneWon(x, y, c, dx, dy, cpt + 1);
            }
            else
            {
                return false;
            }

        }

    }
}
