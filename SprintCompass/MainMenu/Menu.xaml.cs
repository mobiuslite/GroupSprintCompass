﻿using SprintCompass.Sprint_Information;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SprintCompass
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
            Application.Current.MainWindow.Title = "Menu";

            btnSprint.IsEnabled = !MainWindow.disableSprintBtn;

        }

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamMembers());
            MainWindow.ChangeWindowSize(500, 500);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnProj_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProjectInfo());
            //Height="401" Width="395"
            MainWindow.ChangeWindowSize(400, 481);
        }

        private void btnSprint_Click(object sender, RoutedEventArgs e)
        {
            //d: DesignHeight = "450" d: DesignWidth = "800"
            NavigationService.Navigate(new SprintMenu());
            MainWindow.ChangeWindowSize(830, 510);
        }
    }
}
