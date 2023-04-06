﻿using System;
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
        public List<Question> Questions { get; set; }
        public Row()
        {
            InitializeComponent();
            Questions = new List<Question>();
            Questions.Add(Q1);
            Questions.Add(Q2);
            Questions.Add(Q3);
            Questions.Add(Q4);
            Questions.Add(Q5);
        }

        public Row(RowsPanel rowsPanel) : this()
        {
            parent = rowsPanel;
        }

        public void ShowEdit()
        {
            EditBtnBorder.IsEnabled = true;
            Storyboard sb = (Storyboard)EditBtnBorder.FindResource("Show");
            sb.Begin();
        }

        public void HideEdit()
        {
            Storyboard sb = (Storyboard)EditBtnBorder.FindResource("Hide");
            sb.Begin();
            EditBtnBorder.IsEnabled = false;
        }
    }
}
