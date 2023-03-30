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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyGame
{
    public partial class Player : Border
    {
        public static readonly DependencyProperty ColorNameProperty = DependencyProperty.Register("PlayerColor",
            typeof(SolidColorBrush), typeof(Player), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public SolidColorBrush PlayerColor
        {
            get
            {
                return (SolidColorBrush)GetValue(ColorNameProperty);
            }
            set
            {
                SetValue(ColorNameProperty, value);
            }
        }

        private Color _color;
        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                PlayerColor = new SolidColorBrush(_color);
            }
        }

        public PlayersPanel parent { get; set; }

        public bool isCurrent { get; set; }
        private bool isAnim;

        public Player()
        {
            InitializeComponent();
        }

        public Player(PlayersPanel parent, Color color) : this()
        {
            this.parent = parent;
            this.color = color;
        }

        public void Create(bool isCurrent)
        {
            if (isAnim)
                return;

            this.isCurrent = isCurrent;
            isAnim = true;
            Storyboard sb = (Storyboard)PlayerBorder.FindResource("CreatePlayer");
            sb.Completed += new EventHandler(create);
            sb.Begin();
        }

        private void create(object sender, EventArgs e)
        {
            isAnim = false;
            if(isCurrent)
                parent.currentPlayer = this;
        }

        public void Select()
        {
            if (isAnim)
                return;

            isCurrent = true;
            Storyboard sb = (Storyboard)PlayerBorder.FindResource("SelectPlayer");
            sb.Begin();
        }

        public void UnSelect()
        {
            if (isAnim)
                return;

            isCurrent = false;
            Storyboard sb = (Storyboard)PlayerBorder.FindResource("UnSelectPlayer");
            sb.Begin();
        }

        public void Delete()
        {
            if (isAnim)
                return;

            isAnim = true;
            Storyboard sb = (Storyboard)PlayerBorder.FindResource("DeletePlayer");
            sb.Completed += new EventHandler(delete);
            sb.Begin();
        }

        private void delete(object sender, EventArgs e)
        {
            isAnim = false;
            if (isCurrent && parent.PlayersStackPanel.Children.Count > 0)
            {
                Player player = (Player)parent.PlayersStackPanel.Children[0];
                parent.currentPlayer = player;
            }
            parent.PlayersStackPanel.Children.Remove(this);
        }
    }
}
