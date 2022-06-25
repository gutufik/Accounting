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
    /// Interaction logic for PageAddSubdiv.xaml
    /// </summary>
    public partial class SubdivisionPage : Page
    {
        private User user_;
        public SubdivisionPage(User user)
        {
            InitializeComponent();
            user_ = user;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var s = new Subdivision();
            try
            {
                s.ShortName = shortName.Text;
                s.FullName = fullName.Text;
                //DBConnect.connection.Subdivisions.Add(s);
                //DBConnect.connection.SaveChanges();
                MessageBox.Show("Новое подразделение добавлено");
                NavigationService.Navigate(new SubdivisionsPage(user_));
            }
            catch
            {
                MessageBox.Show("Invalid subdivision", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
