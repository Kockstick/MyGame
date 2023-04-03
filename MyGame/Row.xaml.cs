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
        private RowsPanel parent;
        public Row()
        {
            InitializeComponent();
        }

        public Row(RowsPanel rowsPanel) : this()
        {
            parent = rowsPanel;
        }

        public void ShowEdit()
        {
            Storyboard sb = (Storyboard)EditBtnBorder.FindResource("Show");
            sb.Completed += new EventHandler(onEndShow);
            sb.Begin();
        }

        private void onEndShow(object sender, EventArgs e)
        {
            if (parent == null)
                return;

            var list = parent.RowsStackPanel.Children;

            for(int i = 0; i < list.Count; i++)
            {
                Row row = list[i] as Row;

                if(this == list[i])
                {
                    if (i == list.Count - 1)
                        return;

                    ((Row)list[i + 1]).ShowEdit();
                    return;
                }
            }
        }

        public void HideEdit()
        {
            Storyboard sb = (Storyboard)EditBtnBorder.FindResource("Hide");
            sb.Begin();
        }
    }
}
