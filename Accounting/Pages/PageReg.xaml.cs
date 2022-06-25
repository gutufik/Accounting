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
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            var u = new User();
            //try
            //{
            //    u.Name = txtName.Text;
            //    u.Login = txtLogin.Text;
            //    u.Password = txtPassword.Password;
            //    u.RoleID = 2;
            //    DBConnect.connection.User.Add(u);
            //    DBConnect.connection.SaveChanges();
            //    MessageBox.Show("Новый пользователь зарегистрирован");
            //    NavigationService.GoBack();
            //}
            //catch
            //{
            //    MessageBox.Show("Invalid User", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

        }
    }
}
