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
        public static IEnumerable<Empl> empls { get; set; }
        public PageEmployees()
        {
            InitializeComponent();
            //employees = new ObservableCollection<Employee>(DBConnect.connection.Employee.ToList());
            empls = from e in DBConnect.connection.Employee.ToList()
                    join s in DBConnect.connection.Subdivision.ToList()
                    on e.SubdivID equals s.SubdivID
                    join p in DBConnect.connection.Position.ToList()
                    on e.PositionID equals p.PositionID
                    select new Empl 
                    {
                        ID = e.ID,
                        Name = e.Name,
                        Position = p.Name,
                        Subdivision = s.FullName
                    };
            this.DataContext = this;
        }
    }
    public class Empl
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Subdivision { get; set; }
    }
}
