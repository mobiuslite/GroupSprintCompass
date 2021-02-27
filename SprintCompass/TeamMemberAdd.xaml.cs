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

namespace SprintCompass
{
    /// <summary>
    /// Interaction logic for TeamMemberAdd.xaml
    /// </summary>
    public partial class TeamMemberAdd : Page
    {
        public TeamMemberAdd()
        {
            InitializeComponent();
            Application.Current.MainWindow.Title = "Add a team member";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AddTeamMember(txtName.Text, txtPosition.Text, txtContact.Text);
            lblConfirm.Content = $"{txtName.Text} added!";


            txtName.Text = "";
            txtPosition.Text = "";
            txtContact.Text = "";

            

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamMembers());
            MainWindow.ChangeWindowSize(500, 500);
        }
    }
}
