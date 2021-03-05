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
    public partial class SubtaskMenu : Page
    {
        Sprint sprint;
        public SubtaskMenu(Sprint s)
        {
            InitializeComponent();
            sprint = s;
            Application.Current.MainWindow.Title = "Subtask Menu";
            lstSubtasks.ItemsSource = sprint.GetSubtasksName();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            sprint.GetSubtasks().Add(new Subtask(txtSubtaskName.Text));
            lstSubtasks.ItemsSource = sprint.GetSubtasksName();
            txtSubtaskName.Text = "";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SprintMenu());
            //d:DesignHeight="450" d:DesignWidth="800"
            MainWindow.ChangeWindowSize(830, 510);
        }
    }
}
