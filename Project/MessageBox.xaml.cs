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

namespace ProjectVideo
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class messageBox : Window
    {
        public messageBox()
        {
            InitializeComponent();
        }
        public messageBox(String a)
        {
            InitializeComponent();
            lbMess.Text = a;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
     
            this.Close();
        }
    }
}
