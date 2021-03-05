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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<TeamMember> teamMembers;
        private static List<Sprint> sprints;
        public static Project project;

        public MainWindow()
        {
            InitializeComponent();
            sprints = new List<Sprint>();
            frame.Navigate(new Menu());
            ChangeWindowSize(614, 450);
            Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
            teamMembers = Serializer.Deserialize<List<TeamMember>>(App.TEAM_MEMBERS_FILE);
            project = Serializer.Deserialize<Project>(App.PROJECT_INFO_FILE);

            if(teamMembers == null)
                teamMembers = new List<TeamMember>();

        }

        internal static void AddTeamMember(string name, string position, string contact)
        {
            teamMembers.Add(new TeamMember(name, position, contact));
        }

        public static List<string> GetTeamNames() {

            List<string> names = new List<string>();
            foreach (TeamMember t in teamMembers)
            {
                names.Add(t.Name);
            }
            return names;
        }

        public static List<TeamMember> GetTeamList()
        {
            return teamMembers;
        }

        internal static void AddSprint() {

            sprints.Add(new Sprint($"Sprint {sprints.Count + 1}"));
        
        }
        public static List<Sprint> GetSprintList() {

            return sprints;
        
        }

        public static List<string> GetSprintNames()
        {

            List<string> names = new List<string>();
            foreach (Sprint s in sprints)
            {
                names.Add(s.Name);
            }
            return names;
        }

        public static void ChangeWindowSize(int w, int h) {

            Application.Current.MainWindow.Height = h;
            Application.Current.MainWindow.Width = w;

        }

        public static void SetProject(Project p) {

            project = p;
        
        }

        public static Project GetProject() {

            return project;
        
        }

    }
}
