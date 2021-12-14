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
    /// Interaction logic for PageSubdivisions.xaml
    /// </summary>
    public partial class PageSubdivisions : Page
    {
        public static IEnumerable<Subdiv> subdivisions { get; set; }
        private User user_;
        public PageSubdivisions(User user)
        {
            InitializeComponent();
            subdivisions = from s in DBConnect.connection.Subdivision.ToList()
                           select new Subdiv 
                           {
                               ID = s.SubdivID,
                               ShortName = s.ShortName,
                               FullName = s.FullName
                           };
            user_ = user;
            if (user_.RoleID != 1)
            {
                Add.Visibility = Visibility.Hidden;
            }
            this.DataContext = this;
            this.DataContext = this;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddSubdiv(user_));
        }
    }
    public class Subdiv
    { 
        public int ID { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
    }
}
