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

            Project project = MainWindow.GetProject();

            if (project != null) {

                disableInput();

                txtHoursPer.Text = project.StoryPointHours.ToString();
                txtProjName.Text = project.ProjectName;
                txtTeamName.Text = project.TeamName;
                txtTotalCost.Text = project.AppCost.ToString();
                txtTotalPoints.Text = project.EstimatedStoryPoints.ToString();

                calendar.SelectedDate = project.StartDate;
                calendar.IsEnabled = false;

            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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

                                MainWindow.SetProject(project);

                            }
                            else {
                                lblFeedback.Foreground = Brushes.Orange;
                                lblFeedback.Text = $"WARNING: This info cannot be changed later. Be sure that all information is correct";

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
    }
}
