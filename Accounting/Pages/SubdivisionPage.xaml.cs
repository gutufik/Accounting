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
using Core;

namespace Accounting.Pages
{
    /// <summary>
    /// Interaction logic for PageAddSubdiv.xaml
    /// </summary>
    public partial class SubdivisionPage : Page
    {
        private User user_;
        public Subdivision Subdivision { get; set; }
        public SubdivisionPage(User user)
        {
            InitializeComponent();
            user_ = user;
            Subdivision = new Subdivision();
            DataContext = Subdivision;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                DataAccess.SaveSubdivision(Subdivision);

                var employee = CbPersons.SelectedItem as Employee;
                if (employee != null)
                {
                    employee.Subdivision = Subdivision;
                    if (!DataAccess.SaveEmployee(employee))
                    {
                        MessageBox.Show("Заполните данные корректно");
                        return;
                    };
                }
            
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
