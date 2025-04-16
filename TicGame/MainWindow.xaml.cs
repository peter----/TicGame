using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeWPF
{
    public partial class MainWindow : Window
    {
        private Button[,] buttons = new Button[3, 3];
        private string playerX = "Player X", playerO = "Player O";
        private char currentPlayer = 'X';
        private int moveCount = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            BoardGrid.Children.Clear();
            moveCount = 0;
            currentPlayer = 'X';
            StatusText.Text = $"{playerX}'s turn (X)";
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                {
                    Button btn = new Button
                    {
                        FontSize = 32,
                        Tag = new Tuple<int, int>(row, col)
                    };
                    btn.Click += Cell_Click;
                    buttons[row, col] = btn;
                    BoardGrid.Children.Add(btn);
                }
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            var pos = (Tuple<int, int>)btn.Tag;
            if (!string.IsNullOrEmpty(btn.Content?.ToString()))  //Invalid Move
            {
                return;
            }

            btn.Content = currentPlayer.ToString();
            moveCount++;
        

            if (CheckWin(out List<(int, int)> line))
            {
                foreach (var (r, c) in line)
                    buttons[r, c].Background = Brushes.LightGreen;

                string winner = GetCurrentPlayerName();
                StatusText.Text = $"{winner} wins!";
             
                return;
            }

            if (moveCount == 9)
            {
                StatusText.Text = "It's a tie!";
             
                return;
            }

            currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            StatusText.Text = $"{GetCurrentPlayerName()}'s turn ({currentPlayer})";
        }

     


        private string GetCurrentPlayerName() => currentPlayer == 'X' ? playerX : playerO;

        private bool CheckWin(out List<(int, int)> line)
        {
            line = new List<(int, int)>();
            for (int i = 0; i < 3; i++)
            {
                if (Equal(i, 0, i, 1, i, 2)) { line.AddRange(new[] { (i, 0), (i, 1), (i, 2) }); return true; }
                if (Equal(0, i, 1, i, 2, i)) { line.AddRange(new[] { (0, i), (1, i), (2, i) }); return true; }
            }
            if (Equal(0, 0, 1, 1, 2, 2)) { line.AddRange(new[] { (0, 0), (1, 1), (2, 2) }); return true; }
            if (Equal(0, 2, 1, 1, 2, 0)) { line.AddRange(new[] { (0, 2), (1, 1), (2, 0) }); return true; }
            return false;
        }

        private bool Equal(int r1, int c1, int r2, int c2, int r3, int c3)
        {
            string a = buttons[r1, c1].Content?.ToString();
            string b = buttons[r2, c2].Content?.ToString();
            string c = buttons[r3, c3].Content?.ToString();
            return !string.IsNullOrEmpty(a) && a == b && b == c;
        }

      
    }
}