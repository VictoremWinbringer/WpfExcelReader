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
using Microsoft.Win32;

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
        }

        private void btnSelectExcel_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Excel documents(*.xls;*.xlsx)|*.xls;*.xlsx";


            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                if (openFileDialog.FileName.Length > 0)
                {
                    txbSelectedExcelFile.Text = openFileDialog.FileName;
                }
            }

        }

        private void btnViewExcel_Click(object sender, RoutedEventArgs e)
        {
            string excel = txbSelectedExcelFile.Text;
            if (string.IsNullOrEmpty(excel) || !File.Exists(excel))
            {
                MessageBox.Show("The file is invalid. Please select an existing file again.");
            }
            else
            {

                using (FileStream stream = File.Open(excel, FileMode.Open, FileAccess.Read))
                using (IExcelDataReader excelReader = excel.ToLower()
                    .Contains(".xlsx") ?
                    ExcelReaderFactory.CreateOpenXmlReader(stream)
                : ExcelReaderFactory.CreateBinaryReader(stream))
                {

                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet result = excelReader.AsDataSet(); 
                    this.DataContext = result;
                }

            }
        }
    }
}
