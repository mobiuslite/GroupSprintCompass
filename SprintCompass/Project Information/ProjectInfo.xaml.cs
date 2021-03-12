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
    /// Interaction logic for ProjectInfo.xaml
    /// </summary>
    public partial class ProjectInfo : Page
    {
        bool lockInfo;
        public ProjectInfo()
        {
            InitializeComponent();
            lockInfo = false;
            btnReset.IsEnabled = false;
            Project project = MainWindow.GetProject();

            Application.Current.MainWindow.Title = "Project Information";

            if (project != null) {

                disableInput();

                txtHoursPer.Text = project.HourPerPoint.ToString();
                txtProjName.Text = project.ProjectName;
                txtTeamName.Text = project.TeamName;
                txtTotalCost.Text = project.AppCost.ToString();
                txtTotalPoints.Text = project.EstimatedStoryPoints.ToString();

                calendar.SelectedDate = project.ProjectStartDate;
                calendar.IsEnabled = false;

                btnReset.IsEnabled = true;

            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu());
            MainWindow.ChangeWindowSize(800, 450);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string projectName = txtProjName.Text;
            string teamName = txtTeamName.Text;
            DateTime? date = calendar.SelectedDate;
            string hoursPerString = txtHoursPer.Text;
            string totalPointsString = txtTotalPoints.Text;
            string totalCostString = txtTotalCost.Text;

            if (projectName == "" || teamName == "" || date == null) {

                    lblFeedback.Foreground = Brushes.Red;
                    lblFeedback.Text = "Please fill out project information";

            } else {

                if (int.TryParse(hoursPerString, out int hoursResult)) {

                    if (int.TryParse(totalPointsString, out int pointsResult))
                    {

                        if (double.TryParse(totalCostString, out double totalCost))
                        {
                            if (lockInfo)
                            {

                                lblFeedback.Foreground = Brushes.Green;
                                lblFeedback.Text = $"Project {projectName} created!";
                                Project project = new Project(teamName, projectName, (DateTime)date, hoursResult, pointsResult, totalCost, new List<Sprint>());
                                Serializer.Serialize(project, App.PROJECT_INFO_FILE);

                                disableInput();
                                btnReset.IsEnabled = true;

                                MainWindow.SetProject(project);

                            }
                            else {
                                lblFeedback.Foreground = Brushes.Orange;
                                lblFeedback.Text = $"WARNING: This info cannot be changed without complete deletion. Be sure that all information is correct";

                                btnConfirm.Background = Brushes.Green;
                                btnConfirm.Content = "Confirm?";
                                lockInfo = true;

                            }
                        }
                        else
                        {
                            lblFeedback.Foreground = Brushes.Red;
                            lblFeedback.Text = "Total cost not a number";

                        }

                    }
                    else {

                        lblFeedback.Foreground = Brushes.Red;
                        lblFeedback.Text = "Total points not an integer";

                    }
                
                }
                else
                {

                    lblFeedback.Foreground = Brushes.Red;
                    lblFeedback.Text = "Hours per SP not an integer";

                }
            }

            

        }

        private void disableInput() {

            txtHoursPer.IsReadOnly = true;
            txtProjName.IsReadOnly = true;
            txtTeamName.IsReadOnly = true;
            txtTotalCost.IsReadOnly = true;
            txtTotalPoints.IsReadOnly = true;

            btnConfirm.IsEnabled = false;

        }

        public void ResetInput() {

            txtHoursPer.IsReadOnly = false;
            txtProjName.IsReadOnly = false;
            txtTeamName.IsReadOnly = false;
            txtTotalCost.IsReadOnly = false;
            txtTotalPoints.IsReadOnly = false;
            calendar.IsEnabled = true;

            btnConfirm.IsEnabled = true;
            btnReset.IsEnabled = false;

            txtHoursPer.Text = "";
            txtProjName.Text = "";
            txtTeamName.Text = "";
            txtTotalCost.Text ="";
            txtTotalPoints.Text = "";

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            ConfirmReset reset = new ConfirmReset(this);
            reset.Show();
        }
    }
}
