﻿using System;
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
        public static List<Device> devices { get; set; }
        public static List<Subdivision> subdivisions { get; set; }
        public DeviceTransferPage()
        {
            InitializeComponent();
            devices = DataAccess.GetDevices();
            subdivisions = DataAccess.GetSubdivisions();
            this.DataContext = this;
        }

        private void BtnTransfer_Click(object sender, RoutedEventArgs e)
        {
            var t = new Transfer();
            //try
            //{
            //    t.DeviceID = (CbDevice.SelectedItem as Device).DeviceID;
            //    t.Date = DateTime.Now;
            //    t.FinRespPerson = (from em in DBConnect.connection.Employee.ToList()
            //                       where em.SubdivID ==
            //                     (CbSubdiv.SelectedItem as Subdivision).SubdivID
            //                       select em.ID).FirstOrDefault();
            //    DBConnect.connection.Transfer.Add(t);
                
            //    var device = DBConnect.connection.Device.SingleOrDefault(d => d.DeviceID == t.DeviceID);
            //    device.SubdivID = (int)DBConnect.connection.Employee.SingleOrDefault(em => em.ID == t.FinRespPerson).SubdivID;
                
            //    DBConnect.connection.SaveChanges();
            //    MessageBox.Show("Новая передача зарегистрирована");
            //    NavigationService.Navigate(new PageTransferTable());
            //}
            //catch
            //{
            //    MessageBox.Show("Invalid Transfer", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //RespPerson.Text = (from em in DBConnect.connection.Employee.ToList()
            //           where em.SubdivID ==
            //         ((sender as ComboBox).SelectedItem as Subdivision).SubdivID
            //           select em.Name).FirstOrDefault();
        }
    }
}