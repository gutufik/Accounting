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
    /// Interaction logic for PageEmployees.xaml
    /// </summary>
    public partial class PageEmployees : Page
    {
        public static IEnumerable<Empl> empls { get; set; }
        public static User user_;
        public PageEmployees(User user)
        {
            InitializeComponent();
            //employees = new ObservableCollection<Employee>(DBConnect.connection.Employee.ToList());
            empls = from e in DBConnect.connection.Employee.ToList()
                    join s in DBConnect.connection.Subdivision.ToList()
                    on e.SubdivID equals s.SubdivID
                    join p in DBConnect.connection.Position.ToList()
                    on e.PositionID equals p.PositionID
                    select new Empl 
                    {
                        ID = e.ID,
                        Name = e.Name,
                        Position = p.Name,
                        Subdivision = s.FullName
                    };
            user_ = user;

            if (user_.RoleID != 1)
            {
                Del.Visibility = Visibility.Hidden;
            }
            this.DataContext = this;
        }

        private void dgEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Del.IsEnabled = true;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var user = dgEmp.SelectedItem as Empl;
            DBConnect.connection.Employee.Remove(DBConnect.connection.Employee.Find(user.ID));
            DBConnect.connection.SaveChanges();
            NavigationService.Navigate(new PageEmployees(user_));
        }
    }
    public class Empl
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Subdivision { get; set; }
    }
}
