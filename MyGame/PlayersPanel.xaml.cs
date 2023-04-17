using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyGame
{
    public partial class PlayersPanel : Border
    {
        private Player _currentPlayer;
        public Player currentPlayer
        {
            get
            {
                return _currentPlayer;
            }
            set
            {
                if(_currentPlayer != null)
                    _currentPlayer.UnSelect();

                _currentPlayer = value;
                _currentPlayer.Select();
            }
        }

        private List<Color> colors = new List<Color>()
        {
            Colors.Violet,
            Colors.Yellow,
            Colors.Green,
            Colors.Blue,
            Colors.Magenta,
            Colors.Cyan,
            Colors.Red,
            Colors.Pink,
            Colors.Purple,
            Colors.Orange,
            Colors.Orchid,
            Colors.YellowGreen
        };

        private List<Player> players = new List<Player>();

        public PlayersPanel()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            if(colors.Count == 0)
                return;

            Random random = new Random();
            Color color = colors[random.Next(colors.Count)];

            Player player = new Player(this, color);
            players.Add(player);
            player.NamePlayer.Text = "Player " + players.Count;
            PlayersStackPanel.Children.Add(player);
            player.Create(players.Count == 1);
            colors.Remove(color);
        }

        private void Remove_Click(object sender, MouseButtonEventArgs e)
        {
            if (PlayersStackPanel.Children.Count == 0)
                return;
            Player player = (Player)PlayersStackPanel.Children[PlayersStackPanel.Children.Count - 1];

            colors.Add(player.color);
            players.Remove(player);
            player.Delete();
        }

        private void Skip_Click(object sender, MouseButtonEventArgs e)
        {
            Skip();
        }

        public void Skip()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (currentPlayer == players[i])
                {
                    if (i == players.Count - 1)
                        i = -1;
                    currentPlayer = players[i + 1];
                    return;
                }
            }
        }
    }
}
