using Service;
using System.Windows;
using Telerik.Windows.Controls;
using UniversityWPF.ViewModels;

namespace UniversityWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly IAppointmentService _appointmentService;

        public MainWindow(IStudentService studentService,
                          ITeacherService teacherService,
                          IAppointmentService appointmentService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _appointmentService = appointmentService;

            StyleManager.ApplicationTheme = new MaterialTheme();
            InitializeComponent();

            DataContext = new InputsViewModel(_studentService, _teacherService);
        }

        private void RadTreeView_ItemClick(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            string header = (e.OriginalSource as RadTreeViewItem).Header as string;

            switch (header)
            {
                case "Inputs":
                    DataContext = new InputsViewModel(_studentService, _teacherService);
                    break;
                case "Chart":
                    DataContext = new ChartViewModel(_studentService);
                    break;
                case "Spreadsheet":
                    DataContext = new SpreadsheetViewModel();
                    break;
                case "Grid":
                    DataContext = new GridViewModel(_studentService);
                    break;
                case "Scheduler":
                    DataContext = new SchedulerViewModel(_appointmentService);
                    break;
                case "Report":
                    DataContext = new ReportViewModel();
                    break;
                default:
                    break;
            }
        }
    }
}
