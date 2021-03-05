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
    /// Interaction logic for ConfirmReset.xaml
    /// </summary>
    public partial class ConfirmReset : Window
    {
        ProjectInfo page;
        public ConfirmReset(ProjectInfo page)
        {
            InitializeComponent();
            this.page = page;
            Application.Current.MainWindow.Title = "WARNING";
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.SetProject(null);
            page.ResetInput();
            this.Close();
            page.IsEnabled = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
            page.IsEnabled = true;
        }
    }
}
