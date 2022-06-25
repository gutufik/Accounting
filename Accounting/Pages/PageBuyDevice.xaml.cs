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
using Core;

namespace Accounting.Pages
{
    /// <summary>
    /// Interaction logic for PageBuyDevice.xaml
    /// </summary>
    public partial class PageBuyDevice : Page
    {
        public int price { get; set; }
        public List<Subdivision> subdivisions { get; set; }
        private User user_;
        public PageBuyDevice(User user)
        {
            InitializeComponent();
            var rnd = new Random();
            price = rnd.Next(1000, 5000);
            BtnBuy.Content = $"Купить за {price}р";
            subdivisions = DataAccess.GetSubdivisions();
            user_ = user;
            this.DataContext = this;
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            var d = new Device();
            try
            {
                //d.Name = tbName.Text;
                //d.Model = tbModel.Text;
                //d.RoomNumber = int.Parse(tbRoom.Text);
                //d.PurchaseDate = DateTime.Now;
                //d.Price = price;
                //d.SubdivID = (cbSubdiv.SelectedItem as Subdivision).SubdivID;
                //DBConnect.connection.Device.Add(d);
                //DBConnect.connection.SaveChanges();
                //MessageBox.Show("Новая техника доставлена");
                //NavigationService.Navigate(new PageDevices(user_));
            }
            catch
            {
                MessageBox.Show("Invalid Device", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
