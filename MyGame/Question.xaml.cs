using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyGame
{
    public partial class Question : Border
    {
        public static readonly DependencyProperty ColorNameProperty = DependencyProperty.Register("QColor",
            typeof(SolidColorBrush), typeof(Question), new PropertyMetadata(new SolidColorBrush(Colors.Pink)));

        public SolidColorBrush QColor
        {
            get
            {
                return (SolidColorBrush)GetValue(ColorNameProperty);
            }
            set
            {
                _color = value.Color;
                SetValue(ColorNameProperty, value);
            }
        }

        public static readonly DependencyProperty BtnNameProperty = DependencyProperty.Register("BtnScore",
            typeof(string), typeof(Question), new PropertyMetadata("0"));

        public string BtnScore
        {
            get
            {
                return (string)GetValue(BtnNameProperty);
            }
            set
            {
                if(int.TryParse(value, out score))
                    SetValue(BtnNameProperty, value);
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
                QColor = new SolidColorBrush(_color);
            }
        }

        public int score;
        public string text { get; set; }
        public string answer { get; set; }

        public MainWindow mainWindow { get; set; }

        private bool _isShowed;
        public bool isShowed 
        {
            get
            {
                return _isShowed;
            }
            set
            {
                _isShowed = value;
                if (!_isShowed)
                    return;

                IsEnabled = false;
                Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        public Question()
        {
            InitializeComponent();
        }

        public void EditMode(bool isEdit)
        {
            if(!isShowed)
                IsEnabled = !isEdit;
        }

        public Question(int score, string text, string answer, bool isShowed) : this()
        {
            this.score = score;
            this.text = text;
            this.answer = answer;
            this.isShowed = isShowed;
        }

        private void scoreLabel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (mainWindow == null)
                return;

            mainWindow.OpenQuestion.Open(this);
            isShowed = true;
        }
    }
}
