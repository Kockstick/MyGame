using System;
using System.Windows.Controls;

namespace MyGame
{
    public partial class Question : Border
    {
        private int _score;
        public int score
        {
            get
            {
                return _score;
            }
            set
            {
                scoreLabel.Content = value.ToString();
                _score = value;
            }
        }
        public string text { get; set; }
        public string answer { get; set; }
        public bool isShowed { get; set; }

        public Question()
        {
            InitializeComponent();
        }

        public Question(int score, string text, string answer, bool isShowed) : this()
        {
            this.score = score;
            this.text = text;
            this.answer = answer;
            this.isShowed = isShowed;
        }
    }
}
