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
    /// <summary>
    /// Логика взаимодействия для OpenQuestion.xaml
    /// </summary>
    public partial class OpenQuestion : Border
    {
        private Question question;
        public MainWindow mainWindow { get; set; }

        public OpenQuestion()
        {
            InitializeComponent();
        }

        public void Open(Question question)
        {
            this.question = question;
            QuestionLabel.Content = "Вопрос: " + question.text;
            AnswerLabel.Content = "Ответ: ";

            Storyboard sb = (Storyboard)OpenQBorder.FindResource("Show");
            //sb.Completed += new EventHandler(onOpen);
            sb.Begin();
        }

        public void ShowAnswer(object sender, MouseButtonEventArgs e)
        {
            AnswerLabel.Content = "Ответ: " + question.answer;
        }

        public void SetScore(object sender, MouseButtonEventArgs e)
        {
            if (mainWindow.PlayersPanel.currentPlayer == null)
                return;

            mainWindow.PlayersPanel.currentPlayer.score += question.score;
            Close(sender, e);
        }

        public void Close(object sender, MouseButtonEventArgs e)
        {
            Storyboard sb = (Storyboard)OpenQBorder.FindResource("Hide");
            //sb.Completed += new EventHandler(onOpen);
            sb.Begin();
        }
    }
}
