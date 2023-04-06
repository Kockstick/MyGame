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
    /// Логика взаимодействия для Row.xaml
    /// </summary>
    public partial class Row : StackPanel
    {
        public static readonly DependencyProperty ColorNameProperty = DependencyProperty.Register("RowColor",
            typeof(SolidColorBrush), typeof(Row), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        public SolidColorBrush RowColor
        {
            get
            {
                return (SolidColorBrush)GetValue(ColorNameProperty);
            }
            set
            {
                SetValue(ColorNameProperty, value);
                _color = value.Color;
                foreach (var item in Questions)
                {
                    item.QColor = value;
                }
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
                RowColor = new SolidColorBrush(_color);
            }
        }

        private RowsPanel parent;
        public List<Question> Questions { get; set; }
        public Row()
        {
            InitializeComponent();
            Questions = new List<Question>();
            Questions.Add(Q1);
            Questions.Add(Q2);
            Questions.Add(Q3);
            Questions.Add(Q4);
            Questions.Add(Q5);        }

        public Row(RowsPanel rowsPanel) : this()
        {
            parent = rowsPanel;

            if (parent == null || parent.mainWindow == null)
                return;

            for (int i = 1; i <= Questions.Count; i++)
            {
                Questions[i-1].mainWindow = parent.mainWindow;
                Questions[i - 1].score = i * 100;
            }
        }

        public void ShowEdit()
        {
            EditBtnBorder.IsEnabled = true;

            foreach (var item in Questions)
                item.EditMode(true);

            Storyboard sb = (Storyboard)EditBtnBorder.FindResource("Show");
            sb.Begin();
        }

        public void HideEdit()
        {
            foreach (var item in Questions)
                item.EditMode(false);

            Storyboard sb = (Storyboard)EditBtnBorder.FindResource("Hide");
            sb.Begin();
            EditBtnBorder.IsEnabled = false;
        }

        private void EditBtnBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            parent.mainWindow.ExpandRow.Open(this);
            parent.mainWindow.BtnsPanel.ShowThirdGroup();
        }
    }
}
