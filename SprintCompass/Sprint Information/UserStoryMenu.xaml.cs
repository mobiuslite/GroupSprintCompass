using SprintCompassLibrary;
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

namespace SprintCompass.Sprint_Information
{
    /// <summary>
    /// Interaction logic for Subtasks.xaml
    /// </summary>
    public partial class UserStoryMenu : Page
    {
        Sprint sprint;
        public UserStoryMenu(Sprint s)
        {
            InitializeComponent();
            sprint = s;
            Application.Current.MainWindow.Title = "Userstory Menu";
            lstUserstories.ItemsSource = sprint.GetUserStories();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SprintMenu());
            //d:DesignHeight="450" d:DesignWidth="800"
            MainWindow.ChangeWindowSize(830, 510);
        }

        private void btnAddUserStory_Click(object sender, RoutedEventArgs e)
        {
            sprint.GetUserStories().Add(new Userstory(txtUserStoryName.Text));
            lstUserstories.ItemsSource = sprint.GetUserStoryNames();
            txtUserStoryName.Text = "";

            lblUserStoryFeedback.Content = $"Added to userstory list!";
            lblUserStoryFeedback.Foreground = Brushes.Green;
        }

        private void btnAddSubtask_Click(object sender, RoutedEventArgs e) {

            if (lstUserstories.SelectedItem == null)
            {
                lblSubtaskFeedback.Content = "Please select a userstory";
                lblSubtaskFeedback.Foreground = Brushes.Red;
            }
            else 
            {
                Userstory userStory = sprint.GetUserStories().Find(x => x.name == lstUserstories.SelectedItem.ToString());
                userStory.subtasks.Add(new Subtask(txtSubtaskName.Text));
                txtSubtaskName.Text = "";

                lblSubtaskFeedback.Content = $"Subtask added to {userStory.name}!";
                lblSubtaskFeedback.Foreground = Brushes.Green;

                lstSubtasks.ItemsSource = userStory.GetSubtaskNames();
                //lstSubtasks.Items.Refresh();
            }

            

        }

        private void lstUserstories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstSubtasks.ItemsSource = sprint.GetUserStories().Find(x => x.name == lstUserstories.SelectedItem.ToString()).GetSubtaskNames();
        }
    }
}
