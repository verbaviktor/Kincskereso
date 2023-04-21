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

namespace Kincskereso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        void Feltolt()
        {
            
        }

        private void Dice()
        {
            Random rnd = new Random();
            int roll = rnd.Next(6);

            MessageBox.Show((roll + 1).ToString());
            Image img = new Image();
            img.Source = new BitmapImage(new Uri($"dice/{roll + 1}.png", UriKind.Relative));
            dice.Content = img;

        }
    }
}
