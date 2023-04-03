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
    /// Логика взаимодействия для ButtonsPanel.xaml
    /// </summary>
    public partial class ButtonsPanel : Border
    {
        public MainWindow parent { get; set; }
        public ButtonsPanel()
        {
            InitializeComponent();
            
            foreach (var item in StackPanel.Children)
            {
                ToolButton btn = item as ToolButton;
                btn.parent = this;
            }
        }

        public void OnButtonClick(object sender, MouseButtonEventArgs e)
        {
            var btn = sender as ToolButton;
            switch (btn.Tag)
            {
                case "edit":
                    parent.RowsPanel.EditRow(true);
                    btn.Show();
                    break;
            }
        }
    }
}
