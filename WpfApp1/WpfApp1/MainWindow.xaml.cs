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
using ClosedXML.Excel;
using System.Data;
using System.IO;
using Excel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FileStream stream = File.Open("2003.xls", FileMode.Open, FileAccess.Read);

            // Choose one of either 1 or 2
            // 1. Reading from a binary Excel file ('97-2003 format; *.xls)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            // 4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            // 6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
              this.DataContext = result;
            //foreach (DataTable item in result.Tables)
            //{
            //    MyTab.Items.Add(new TabItem { Header = item.TableName, Content = new DataGrid { ItemsSource = new DataView(item) } });
            //}
        }
    }
}
