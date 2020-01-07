using System.Windows.Controls;

namespace UniversityWPF.Views
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportViewer_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            reportViewer.RefreshReport();
        }
    }
}
