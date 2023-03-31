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
    public partial class ToolButton : Border
    {
        public static readonly DependencyProperty BtnNameProperty = DependencyProperty.Register("BtnName",
            typeof(string), typeof(ToolButton), new PropertyMetadata("Default"));

        public string BtnName
        {
            get
            {
                return (string)GetValue(BtnNameProperty);
            }
            set
            {
                SetValue(BtnNameProperty, value);
            }
        }

        public static readonly DependencyProperty ColorNameProperty = DependencyProperty.Register("BtnColor",
            typeof(SolidColorBrush), typeof(ToolButton), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        public SolidColorBrush BtnColor
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

        private bool isAnim;

        public ToolButton()
        {
            InitializeComponent();
        }

        private void Thumb_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard sb = (Storyboard)ToolBtnBorder.FindResource("MouseEnter");
            sb.Begin();
        }

        private void Thumb_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard sb = (Storyboard)ToolBtnBorder.FindResource("MouseLeav");
            sb.Begin();
        }

        private void Thumb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard sb = (Storyboard)ToolBtnBorder.FindResource("Hide");
            sb.Begin();
        }
    }
}
