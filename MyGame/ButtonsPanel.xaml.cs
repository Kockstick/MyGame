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

            ShowFirstGroup();
        }

        public void OnButtonClick(object sender, MouseButtonEventArgs e)
        {
            var btn = sender as ToolButton;
            switch (btn.Tag)
            {
                case "edit":
                    parent.RowsPanel.EditRow(true);
                    ShowSecondGroup();
                    break;
                case "ready":
                    parent.RowsPanel.EditRow(false);
                    ShowFirstGroup();
                    break;
                case "add":
                    ShowThirdGroup();
                    parent.RowsPanel.AddRow();
                    break;
                case "ok":
                    ShowSecondGroup();
                    parent.ExpandRow.Ok();
                    break;
                case "cansel":
                    ShowSecondGroup();
                    parent.ExpandRow.Cansel();
                    break;
                case "delete":
                    parent.RowsPanel.Delete();
                    break;
            }
        }

        public void ShowFirstGroup()
        {
            BtnOpen.Show();
            BtnSave.Show();
            BtnEdit.Show();
            BtnAdd.Hide();
            BtnDelete.Hide();
            BtnReady.Hide();
            BtnOk.Hide();
            BtnCansel.Hide();
        }

        public void ShowSecondGroup()
        {
            BtnOpen.Hide();
            BtnSave.Hide();
            BtnEdit.Hide();

            if (parent.RowsPanel.CanCreate())
                BtnAdd.Show();
            else
                BtnAdd.Hide();

            BtnDelete.Show();
            BtnReady.Show();
            BtnOk.Hide();
            BtnCansel.Hide();
        }

        public void ShowThirdGroup()
        {
            BtnOpen.Hide();
            BtnSave.Hide();
            BtnEdit.Hide();
            BtnAdd.Hide();
            BtnDelete.Hide();
            BtnReady.Hide();
            BtnOk.Show();
            BtnCansel.Show();
        }
    }
}
