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
using System.Collections.ObjectModel;

namespace Accounting.Pages
{
    /// <summary>
    /// Interaction logic for PageAutn.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public PageAuth()
        {
            InitializeComponent();
            
            this.DataContext = this;
        }
        private void registerClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageReg());
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>(DBConnect.connection.User.ToList());
            var user = users.Where(a => a.Login == txtLogin.Text && a.Password == txtPassword.Password).FirstOrDefault();
            if (user != null)
            {
                Windows.HomeWindow homeWindow = new Windows.HomeWindow(user);
                homeWindow.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
