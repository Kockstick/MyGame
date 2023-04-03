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
        public ButtonsPanel parent { get; set; }

        public ToolButton()
        {
            InitializeComponent();
        }

        private void Thumb_MouseEnter(object sender, MouseEventArgs e)
        {
            Animate("MouseEnter");
        }

        private void Thumb_MouseLeave(object sender, MouseEventArgs e)
        {
            Animate("MouseLeav");
        }

        private void Thumb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(parent != null)
                parent.OnButtonClick(sender, e);
            Animate("Hide");
            isAnim = true;
        }

        public void Show()
        {
            Animate("Show");
            isAnim = true;
        }

        private void Animate(string key)
        {
            if (isAnim)
                return;

            Storyboard sb = (Storyboard)ToolBtnBorder.FindResource(key);
            sb.Completed += new EventHandler(onEndAnim);
            sb.Begin();
        }

        private void onEndAnim(object sender, EventArgs e)
        {
            isAnim = false;
        }
    }
}
