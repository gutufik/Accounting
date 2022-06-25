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
using Core;

namespace Accounting.Pages
{
    /// <summary>
    /// Interaction logic for PageReg.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public User User { get; set; }
        public RegistrationPage()
        {
            InitializeComponent();

            User = new User();
            DataContext = User;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.RegisterUser(User))
            {
                Windows.HomeWindow homeWindow = new Windows.HomeWindow(User);
                homeWindow.Show();
                Application.Current.MainWindow.Close();
            }
            MessageBox.Show("Такой пользователь уже зарегистрирован");
        }
    }
}
