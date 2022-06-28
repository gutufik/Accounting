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
            User.Employee = new Employee() {PositionId = 2, SubdivisionId = 1 };
            DataContext = User;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            User.Password = txtPassword.Password;
            User.RoleId = 2;
            if (DataAccess.RegisterUser(User))
            {
                App.User = User;
                Application.Current.MainWindow.Close();
            }
            else
                MessageBox.Show("Заполните корректно все поля");
        }
    }
}
