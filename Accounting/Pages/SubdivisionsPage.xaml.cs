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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Core;
using Accounting.Windows;

namespace Accounting.Pages
{
    /// <summary>
    /// Interaction logic for PageSubdivisions.xaml
    /// </summary>
    public partial class SubdivisionsPage : Page
    {
        public static List<Subdivision> Subdivisions { get; set; }
        private static NavigationService NavigationService { get; }
            = (Application.Current.MainWindow as HomeWindow).MainFrame.NavigationService;
        private User user_;
        public SubdivisionsPage(User user)
        {
            InitializeComponent();
            Subdivisions = DataAccess.GetSubdivisions();
            user_ = user;
            if (user_.RoleId != 1)
            {
                Add.Visibility = Visibility.Hidden;
                Del.Visibility = Visibility.Hidden;
            }
            this.DataContext = this;

            NavigationService.Navigated += RefreshList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SubdivisionPage(user_));
        }
        private void RefreshList(object sender, NavigationEventArgs e)
        {
            Subdivisions = DataAccess.GetSubdivisions();
            LvSubdivisions.ItemsSource = Subdivisions;
            LvSubdivisions.Items.Refresh();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            //var user = dgSubdiv.SelectedItem as Subdiv;
            //DBConnect.connection.Subdivision.Remove(DBConnect.connection.Subdivision.Find(user.ID));
            //DBConnect.connection.SaveChanges();
            NavigationService.Navigate(new SubdivisionsPage(user_));
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Del.IsEnabled = true;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var subdivisions_ = Subdivisions.ToList();
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Подразделения";

            worksheet.Cells[1][1] = "ID";
            worksheet.Cells[2][1] = "ShortName";
            worksheet.Cells[3][1] = "FullName";

            var rowIndex = 2;

            for (int i = 0; i < subdivisions_.Count(); i++)
            {
                worksheet.Cells[1][rowIndex] = subdivisions_[i].Id;
                worksheet.Cells[2][rowIndex] = subdivisions_[i].ShortName;
                worksheet.Cells[3][rowIndex] = subdivisions_[i].FullName;
                rowIndex++;
            }
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();

            application.Visible = true;
        }

        private void Word_Click(object sender, RoutedEventArgs e)
        {
            var subdivisions_ = Subdivisions.ToList();
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            var tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;

            Word.Table table = document.Tables.Add(tableRange, subdivisions_.Count, 3);
            table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            for (int i = 0; i < subdivisions_.Count; i++)
            {
                var cellRange = table.Cell(i + 1, 1).Range;
                cellRange.Text = subdivisions_[i].Id.ToString();

                cellRange = table.Cell(i + 1, 2).Range;
                cellRange.Text = subdivisions_[i].ShortName;

                cellRange = table.Cell(i + 1, 3).Range;
                cellRange.Text = subdivisions_[i].FullName;
            }


            application.Visible = true;
        }
    }
}
