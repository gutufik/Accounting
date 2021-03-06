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

namespace Accounting.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame_auth.NavigationService.Navigate(new Pages.AuthorizationPage());
            this.Closing += new System.ComponentModel.CancelEventHandler(WindowClosing);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.User != null)
            {
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
                App.Current.MainWindow = homeWindow;
            }
        }
    }
}
