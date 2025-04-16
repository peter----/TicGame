using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TicGame
{
    public class GameWinLogic
    {
        public static bool CheckWin(char[,] buttons, char player, out List<(int, int)> line)
        {
            line = new List<(int, int)>();
            for (int i = 0; i < 3; i++)
            {
                if (Equal(buttons, player, i, 0, i, 1, i, 2)) { line.AddRange(new[] { (i, 0), (i, 1), (i, 2) }); return true; }
                if (Equal(buttons, player, 0, i, 1, i, 2, i)) { line.AddRange(new[] { (0, i), (1, i), (2, i) }); return true; }
            }
            if (Equal(buttons, player, 0, 0, 1, 1, 2, 2)) { line.AddRange(new[] { (0, 0), (1, 1), (2, 2) }); return true; }
            if (Equal(buttons, player, 0, 2, 1, 1, 2, 0)) { line.AddRange(new[] { (0, 2), (1, 1), (2, 0) }); return true; }
            return false;
        }

        private static bool Equal(char[,] buttons, char player, int r1, int c1, int r2, int c2, int r3, int c3)
        {
            char a = buttons[r1, c1];
            char b = buttons[r2, c2];
            char c = buttons[r3, c3];
            return a != ' ' && a == player && a == b && b == c;
        }

    }
}
