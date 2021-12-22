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
    /// Interaction logic for PageTransferTable.xaml
    /// </summary>
    public partial class PageTransferTable : Page
    {
        public static IEnumerable<Transf> transfers { get; set; }
        public PageTransferTable()
        {
            InitializeComponent();
            transfers = from t in DBConnect.connection.Transfer.ToList()
                        join d in DBConnect.connection.Device.ToList()
                        on t.DeviceID equals d.DeviceID
                        join e in DBConnect.connection.Employee.ToList()
                        on t.FinRespPerson equals e.ID
                        join s in DBConnect.connection.Subdivision.ToList()
                        on e.SubdivID equals s.SubdivID
                        select new Transf 
                        {
                            DeviceID = d.DeviceID,
                            Device = d.DeviceName,
                            Date = (DateTime)t.Date,
                            RespPerson = e.Name,
                            Subdivision = s.FullName
                        };
            this.DataContext = this;
        }

        private void AddTransfer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageDeviceTransfer());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var user = dgTransfer.SelectedItem as Transf;
            DBConnect.connection.Transfer.Remove(DBConnect.connection.Transfer.Find(user.DeviceID, user.Date));
            DBConnect.connection.SaveChanges();
            NavigationService.Navigate(new PageTransferTable());
        }

        private void dgTransfer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Del.IsEnabled = true;
        }
    }
    public class Transf
    {
        public int DeviceID { get; set; }
        public string Device { get; set; }
        public DateTime Date { get; set; }
        public string Subdivision { get; set; }
        public string RespPerson { get; set; }
    }
}
