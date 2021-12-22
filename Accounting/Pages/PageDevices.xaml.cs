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
    /// Interaction logic for PageDevices.xaml
    /// </summary>
    public partial class PageDevices : Page
    {
        public static IEnumerable<Dev> devices { get; set; }
        private User user_;
        public PageDevices(User user)
        {
            InitializeComponent();
            devices = from d in DBConnect.connection.Device.ToList()
                      join s in DBConnect.connection.Subdivision.ToList()
                      on d.SubdivID equals s.SubdivID
                      select new Dev
                      {
                          ID = d.DeviceID,
                          Name = d.DeviceName,
                          Model = d.Model,
                          Date = (DateTime)(d.PurchaseDate),
                          Room = (int)d.Room,
                          Price = (int)d.Price,
                          Subdivision = s.FullName
                      };
            user_ = user;
            if (user_.RoleID != 1)
            {
                BtnBuy.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
            }
            this.DataContext = this;
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBuyDevice(user_));
        }

        private void dgDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (user_.RoleID == 1)
                BtnDel.IsEnabled = true;
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var user = dgDevice.SelectedItem as Dev;
            DBConnect.connection.Device.Remove(DBConnect.connection.Device.Find(user.ID));
            DBConnect.connection.SaveChanges();
            NavigationService.Navigate(new PageDevices(user_));
        }
    }
    public class Dev
    { 
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public DateTime Date { get; set; }
        public int Room { get; set; }
        public int Price { get; set; }
        public string Subdivision { get; set; }
    }
}
