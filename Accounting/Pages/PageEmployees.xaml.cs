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
    /// Interaction logic for PageEmployees.xaml
    /// </summary>
    public partial class PageEmployees : Page
    {
        public static ObservableCollection<Employee> employees { get; set; }
        public PageEmployees()
        {
            InitializeComponent();
            employees = new ObservableCollection<Employee>(DBConnect.connection.Employee.ToList());
            this.DataContext = this;
        }
    }
}
