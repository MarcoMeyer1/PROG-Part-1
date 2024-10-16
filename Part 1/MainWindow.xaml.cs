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

namespace Part_1
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

        private void btnReportIssues_Click(object sender, RoutedEventArgs e)
        {
            ReportIssues reportIssues = new ReportIssues();
            reportIssues.Show();
            this.Close();
        }
        private void btnLocalEvents_Click(object sender, RoutedEventArgs e)
        {
            LocalEvents localEvents = new LocalEvents();
            localEvents.Show();
            this.Close();
        }
    }
}
