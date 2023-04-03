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
    /// Логика взаимодействия для RowsPanel.xaml
    /// </summary>
    public partial class RowsPanel : Border
    {
        public RowsPanel()
        {
            InitializeComponent();
            RowsStackPanel.Children.Add(new Row(this));
            RowsStackPanel.Children.Add(new Row(this));
            RowsStackPanel.Children.Add(new Row(this));
            RowsStackPanel.Children.Add(new Row(this));
            RowsStackPanel.Children.Add(new Row(this));
            RowsStackPanel.Children.Add(new Row(this));
        }

        public void EditRow(bool isEdit)
        {
            if (RowsStackPanel.Children.Count == 0)
                return;

            ((Row)RowsStackPanel.Children[0]).ShowEdit();
        }

        public void AddRow()
        {
            RowsStackPanel.Children.Add(new Row());
        }

        public void AddRow(Row row)
        {
            RowsStackPanel.Children.Add(row);
        }
    }
}
