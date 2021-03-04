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
using SprintCompassLibrary;

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

            var test = (TeamMember)lstTeamMember.SelectedItem;
            if (test == null || lstTeamMember.Items.Count == 0)
            {
                lblName.Content = "";
                lblSpecialty.Content = "";
                lblContact.Text = "";
            }
            else 
            {
                lblName.Content = test.Name;
                lblSpecialty.Content = test.Position;
                lblContact.Text = test.Contact;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Serializer.Serialize(MainWindow.teamMembers, App.TEAM_MEMBERS_FILE);

            NavigationService.Navigate(new Menu());
            MainWindow.ChangeWindowSize(800, 450);
        }

        private void btnAddTeamMember_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamMemberAdd());
            MainWindow.ChangeWindowSize(275, 320);
        }

        private void lstTeamMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblName.Content = ((TeamMember)lstTeamMember.SelectedItem).Name;
            lblSpecialty.Content = ((TeamMember)lstTeamMember.SelectedItem).Position;
            lblContact.Text = ((TeamMember)lstTeamMember.SelectedItem).Contact;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (TeamMember)lstTeamMember.SelectedItem;

            if(selectedItem != null)
                MainWindow.GetTeamList().Remove(selectedItem);

            lstTeamMember.Items.Refresh();
            lblName.Content = "";
            lblSpecialty.Content = "";
            lblContact.Text = "";
        }

    }
}
