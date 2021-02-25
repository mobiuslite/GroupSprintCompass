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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> teamMembers = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Menu());
            ChangeWindowSize(614, 450);
            Application.Current.MainWindow.ResizeMode = ResizeMode.NoResize;
        }

        public static List<string> GetTeamList() {

            return teamMembers;
        
        }

        public static void AddTeamMember(string name) {

            teamMembers.Add(name);
        
        }

        public static void ChangeWindowSize(int w, int h) {

            Application.Current.MainWindow.Height = h;
            Application.Current.MainWindow.Width = w;

        }

    }
}
