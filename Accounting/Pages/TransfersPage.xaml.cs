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
    /// Interaction logic for PageTransferTable.xaml
    /// </summary>
    public partial class TransfersPage : Page
    {
        public static List<Transfer> Transfers { get; set; }
        private static NavigationService NavigationService { get; }
            = (Application.Current.MainWindow as HomeWindow).MainFrame.NavigationService;
        public TransfersPage()
        {
            InitializeComponent();
            Transfers = DataAccess.GetTransfers();
            this.DataContext = this;

            NavigationService.Navigated += RefreshList;
        }
        private void RefreshList(object sender, NavigationEventArgs e)
        {
            RefreshList();
        }
        private void RefreshList()
        {
            Transfers = DataAccess.GetTransfers();
            LvTransfers.ItemsSource = Transfers;
            LvTransfers.Items.Refresh();
        }

        private void AddTransfer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DeviceTransferPage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var transfer = LvTransfers.SelectedItem as Transfer;
            transfer.IsDeleted = true;
            DataAccess.SaveTransfer(transfer);

            RefreshList();
        }

        private void dgTransfer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Del.IsEnabled = true;
        }
    }
}
