using System.Windows;

namespace TicTacToeWPF
{
    public partial class PlayerName : Window
    {
        public string PlayerX => TxtX.Text;
        public string PlayerO => TxtO.Text;

        public PlayerName()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerX) && !string.IsNullOrWhiteSpace(PlayerO))
                DialogResult = true;
            else
                MessageBox.Show("Please enter both player names.");
        }
    }
}