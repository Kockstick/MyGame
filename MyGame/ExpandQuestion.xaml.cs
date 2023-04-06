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
    /// <summary>
    /// Логика взаимодействия для ExpandQuestion.xaml
    /// </summary>
    public partial class ExpandQuestion : Border
    {
        public ExpandQuestion()
        {
            InitializeComponent();
        }

        public ExpandQuestion(Question question) : this()
        {
            ScoreLabel.Content = question.scoreLabel.Content;
            QuestionTextBox.Text = question.text;
            AnswerTextBox.Text = question.answer;
        }
    }
}
