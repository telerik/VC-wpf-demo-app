using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Documents.Spreadsheet.FormatProviders.OpenXml.Xlsx;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Interaction logic for SpreadsheetView.xaml
    /// </summary>
    public partial class SpreadsheetView : UserControl
    {
        private readonly XlsxFormatProvider _formatProvider;

        public SpreadsheetView()
        {
            InitializeComponent();
            _formatProvider = new XlsxFormatProvider();
        }

        private void RadSpreadsheet_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (Stream input = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Spreadsheets/students-grades.xlsx"), FileMode.Open))
                {
                    this.radSpreadsheet.Workbook = _formatProvider.Import(input);
                }
            }
            catch
            {
                MessageBox.Show("Student grades spreadsheet not found!");
            }
        }
    }
}
