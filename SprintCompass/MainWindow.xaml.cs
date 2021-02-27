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
        static List<TeamMember> teamMembers = new List<TeamMember>();

        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Menu());
            ChangeWindowSize(614, 450);
            Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
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

        public static void ChangeWindowSize(int w, int h) {

            Application.Current.MainWindow.Height = h;
            Application.Current.MainWindow.Width = w;

        }

    }
}
