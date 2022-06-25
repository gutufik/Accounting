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
    /// Interaction logic for PageEmployees.xaml
    /// </summary>
    public partial class PageEmployees : Page
    {
        public static List<Employee> employees { get; set; }
        public static User user_;
        public PageEmployees(User user)
        {
            InitializeComponent();
            //employees = new ObservableCollection<Employee>(DBConnect.connection.Employee.ToList());
            employees = DataAccess.GetEmployees();
            user_ = user;

            if (user_.RoleId != 1)
            {
                Del.Visibility = Visibility.Hidden;
            }
            this.DataContext = this;
        }

        private void dgEmp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Del.IsEnabled = true;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            //var user = dgEmp.SelectedItem as Empl;
            //DBConnect.connection.Employee.Remove(DBConnect.connection.Employee.Find(user.ID));
            //DBConnect.connection.SaveChanges();
            //NavigationService.Navigate(new PageEmployees(user_));
        }
    }
}
