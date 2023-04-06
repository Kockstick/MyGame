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
    /// Логика взаимодействия для ExpandRow.xaml
    /// </summary>
    public partial class ExpandRow : Border
    {
        public MainWindow mainWindow { get; set; }
        private Row row;
        public ExpandRow()
        {
            InitializeComponent();
        }

        public void Open(Row row)
        {
            this.row = row;
            QuestionsStackPanel.Children.Clear();
            Category.Text = row.Category.Text;
            foreach (var item in row.Questions)
            {
                QuestionsStackPanel.Children.Add(new ExpandQuestion(item));
            }

            Storyboard sb = (Storyboard)ExpandRowBorder.FindResource("Show");
            sb.Completed += new EventHandler(onOpen);
            sb.Begin();
        }

        private void onOpen(object sender, EventArgs e)
        {
            if(!mainWindow.RowsPanel.RowsStackPanel.Children.Contains(row))
                mainWindow.RowsPanel.RowsStackPanel.Children.Add(row);
        }

        public void Cansel()
        {
            var rows = mainWindow.RowsPanel.RowsStackPanel.Children;
            if (rows[rows.Count - 1] == row)
                rows.Remove(row);
            Storyboard sb = (Storyboard)ExpandRowBorder.FindResource("Hide");
            sb.Begin();
            mainWindow.RowsPanel.rowsCount--;
        }

        public void Ok()
        {
            if (Category.Text == "")
            {
                Cansel();
                return;
            }
            row.Category.Text = Category.Text;

            for (int i = 0; i < row.Questions.Count; i++)
            {
                var item = row.Questions[i];
                var quest = (ExpandQuestion)QuestionsStackPanel.Children[i];

                item.text = quest.QuestionTextBox.Text;
                item.answer = quest.AnswerTextBox.Text;
            }

            Storyboard sb = (Storyboard)ExpandRowBorder.FindResource("Hide");
            sb.Begin();
        }
    }
}
