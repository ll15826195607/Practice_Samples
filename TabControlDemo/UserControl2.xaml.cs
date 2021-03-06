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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TabControlDemo
{
    /// <summary>
    /// UserControl2.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            this.Loaded += UserControl2_Loaded;
        }

        public Window ParentWindow { get; private set; }
        private void UserControl2_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= UserControl2_Loaded;
            this.ParentWindow = Window.GetWindow(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.tbPrint.Text = String.Format("Parent Window Height: {0}, Width: {1}", this.ParentWindow.ActualHeight, this.ParentWindow.ActualWidth);   
        }
    }
}
