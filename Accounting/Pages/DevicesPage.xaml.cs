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
using Accounting.Windows;

namespace Accounting.Pages
{
    /// <summary>
    /// Interaction logic for PageDevices.xaml
    /// </summary>
    public partial class DevicesPage : Page
    {
        public static List<Device> Devices { get; set; }
        private User user_;
        private static NavigationService NavigationService { get; }
            = (Application.Current.MainWindow as HomeWindow).MainFrame.NavigationService;

        public DevicesPage(User user)
        {
            InitializeComponent();
            Devices = DataAccess.GetDevices();
            user_ = user;
            if (user_.RoleId != 1)
            {
                BtnBuy.Visibility = Visibility.Hidden;
                BtnDel.Visibility = Visibility.Hidden;
            }
            this.DataContext = this;

            NavigationService.Navigated += RefreshList;
        }

        private void RefreshList(object sender, NavigationEventArgs e)
        {
            RefreshList();
        }
        public void RefreshList()
        {
            Devices = DataAccess.GetDevices();
            LvDevices.ItemsSource = Devices;
            LvDevices.Items.Refresh();
        }
        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DevicePurchasePage(user_));
        }

        private void dgDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (user_.RoleId == 1)
                BtnDel.IsEnabled = true;
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var device = LvDevices.SelectedItem as Device;
            device.IsDeleted = true;
            DataAccess.SaveDevice(device);

            RefreshList();
        }
    }
}
