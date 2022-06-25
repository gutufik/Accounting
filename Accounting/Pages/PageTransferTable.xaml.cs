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
    /// Interaction logic for PageTransferTable.xaml
    /// </summary>
    public partial class PageTransferTable : Page
    {
        public static List<Transfer> transfers { get; set; }
        public PageTransferTable()
        {
            InitializeComponent();
            transfers = DataAccess.GetTransfers();
            this.DataContext = this;
        }

        private void AddTransfer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageDeviceTransfer());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            //var user = dgTransfer.SelectedItem as Transf;
            //DBConnect.connection.Transfer.Remove(DBConnect.connection.Transfer.Find(user.DeviceID, user.Date));
            //DBConnect.connection.SaveChanges();
            //NavigationService.Navigate(new PageTransferTable());
        }

        private void dgTransfer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Del.IsEnabled = true;
        }
    }
}
