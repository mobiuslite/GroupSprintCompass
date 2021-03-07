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
    /// Interaction logic for Sprint.xaml
    /// </summary>
    public partial class SprintMenu : Page
    {
        public SprintMenu()
        {
            InitializeComponent();
            lstSprints.ItemsSource = MainWindow.GetSprintNames();
            Application.Current.MainWindow.Title = "Sprint Menu";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AddSprint();
            lstSprints.ItemsSource = MainWindow.GetSprintNames();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Serializer.Serialize(MainWindow.GetProject(), App.PROJECT_INFO_FILE);
            NavigationService.Navigate(new Menu());
            MainWindow.ChangeWindowSize(800, 450);
        }

        private void btnUserStories_Click(object sender, RoutedEventArgs e)
        {
            if (lstSprints.SelectedItem == null)
            {
            }
            else
            {

                List<Sprint> sprints = MainWindow.GetSprintList();


                NavigationService.Navigate(new UserStoryMenu(sprints.Find(x => x.Name == lstSprints.SelectedItem.ToString())));
                //Title="Subtasks" Height="466.667" Width="659.091">
                MainWindow.ChangeWindowSize(690, 750);
            }
        }
    }
}
