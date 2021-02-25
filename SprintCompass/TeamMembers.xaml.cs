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
    /// Interaction logic for TeamMembers.xaml
    /// </summary>
    public partial class TeamMembers : Page
    {

        public TeamMembers()
        {
            InitializeComponent();
            lstTeamMember.ItemsSource = MainWindow.GetTeamList();
            Application.Current.MainWindow.Title = "Team Members";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
            MainWindow.ChangeWindowSize(800, 450);
        }

        private void btnAddTeamMember_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamMemberAdd());

            MainWindow.ChangeWindowSize(275, 300);
        }

        private void lstTeamMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblName.Content = lstTeamMember.SelectedItem;
        }

        private static void test() {
        
        }

    }
}
