using System;
using System.Globalization;
using System.Windows;

namespace MyGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnsPanel.parent = this;
            RowsPanel.mainWindow = this;
            ExpandRow.mainWindow = this;
            OpenQuestion.mainWindow = this;
        }
    }
}
