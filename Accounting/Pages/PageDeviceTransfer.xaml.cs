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
    /// Interaction logic for PageDeviceTransfer.xaml
    /// </summary>
    public partial class PageDeviceTransfer : Page
    {
        public static ObservableCollection<Device> devices { get; set; }
        public static ObservableCollection<Subdivision> subdivisions { get; set; }
        public PageDeviceTransfer()
        {
            InitializeComponent();
            devices = new ObservableCollection<Device>(DBConnect.connection.Device.ToList());
            subdivisions = new ObservableCollection<Subdivision>(DBConnect.connection.Subdivision.ToList());
            this.DataContext = this;
        }

        private void BtnTransfer_Click(object sender, RoutedEventArgs e)
        {
            var t = new Transfer();
            try
            {
                t.DeviceID = (CbDevice.SelectedItem as Device).DeviceID;
                t.Date = DateTime.Now;
                t.FinRespPerson = (from em in DBConnect.connection.Employee.ToList()
                                   where em.SubdivID ==
                                 (CbSubdiv.SelectedItem as Subdivision).SubdivID
                                   select em.ID).FirstOrDefault();
                DBConnect.connection.Transfer.Add(t);
                DBConnect.connection.SaveChanges();
                MessageBox.Show("Новая передача зарегистрирована");
                NavigationService.Navigate(new PageTransferTable());
            }
            catch
            {
                MessageBox.Show("Invalid Transfer", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RespPerson.Text = (from em in DBConnect.connection.Employee.ToList()
                       where em.SubdivID ==
                     ((sender as ComboBox).SelectedItem as Subdivision).SubdivID
                       select em.Name).FirstOrDefault();
                            //{
                            //    ID = em.ID,
                            //    Name = em.Name,
                            //    PositionID = em.PositionID,
                            //    SubdivID = em.SubdivID
                            //};
        }
    }
}
