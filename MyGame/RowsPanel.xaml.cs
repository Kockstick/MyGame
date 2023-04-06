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
        public MainWindow mainWindow { get; set; }
        public RowsPanel()
        {
            InitializeComponent();
        }

        public void EditRow(bool isEdit)
        {
            if (RowsStackPanel.Children.Count == 0)
                return;

            foreach (var item in RowsStackPanel.Children)
            {
                if(isEdit)
                    ((Row)item).ShowEdit();
                else 
                    ((Row)item).HideEdit();
            }
        }

        public void AddRow()
        {
            Row row = new Row(this);
            mainWindow.ExpandRow.Open(row);
        }

        public void Delete()
        {
            RowsStackPanel.Children.Remove(RowsStackPanel.Children[RowsStackPanel.Children.Count - 1]);
        }
    }
}
