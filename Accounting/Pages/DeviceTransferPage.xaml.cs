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
    /// Interaction logic for PageDeviceTransfer.xaml
    /// </summary>
    public partial class DeviceTransferPage : Page
    {
        public List<Device> Devices { get; set; }
        public List<Subdivision> Subdivisions { get; set; }
        public Transfer Transfer { get; set; }

        public DeviceTransferPage()
        {
            InitializeComponent();
            Devices = DataAccess.GetDevices();
            Subdivisions = DataAccess.GetSubdivisions();
            Transfer = new Transfer();
            this.DataContext = this;
        }

        private void BtnTransfer_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var device = CbDevice.SelectedItem as Device;
                var subdivision = CbSubdiv.SelectedItem as Subdivision;

                device.Subdivision = subdivision;
                Transfer.Device = device;
                Transfer.Employee = subdivision.Employees.FirstOrDefault();
                Transfer.Date = DateTime.Now;

                if (!DataAccess.SaveTransfer(Transfer)) 
                    throw new Exception();

                //if (!DataAccess.SaveDevice(device));
                //    throw new Exception();

                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var subdivision = CbSubdiv.SelectedItem as Subdivision;
            var employee = subdivision.Employees.FirstOrDefault();
            if (employee != null)
                RespPerson.Text = $"{employee.FirstName} {employee.LastName}";
        }
    }
}
