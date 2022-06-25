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
    public partial class DevicePurchasePage : Page
    {
        public int price { get; set; }
        public List<Subdivision> subdivisions { get; set; }

        public Device Device { get; set; }
        private User user_;
        public DevicePurchasePage(User user)
        {
            InitializeComponent();
            var rnd = new Random();
            Device = new Device();
            price = rnd.Next(1000, 5000);
            BtnBuy.Content = $"Купить за {price}р";
            subdivisions = DataAccess.GetSubdivisions();
            user_ = user;
            this.DataContext = this;
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.SaveDevice(Device);
            NavigationService.GoBack();
        }
    }
}
