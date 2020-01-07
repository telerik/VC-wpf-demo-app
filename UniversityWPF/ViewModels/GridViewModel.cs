using Domain.Models;
using Service;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Unity;
using UniversityWPF.Commands;

namespace UniversityWPF.ViewModels
{
    public class GridViewModel : INotifyPropertyChanged
    {
        private IStudentService _studentService;
        private ObservableCollection<Student> _students;
        private UnityContainer _unityContainer;

        private ICommand _addStudentCommand;
        private ICommand _deleteStudentCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public GridViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            Students = new ObservableCollection<Student>(_studentService.GetAll());
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }

            set
            {
                _students = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddStudentCommand
        {
            get
            {
                return this._addStudentCommand
                       ?? (this._addStudentCommand = new RelayCommand(this.AddStudentClicked));
            }
        }

        public ICommand DeleteStudentCommand
        {
            get
            {
                return this._deleteStudentCommand
                       ?? (this._deleteStudentCommand = new RelayCommand(this.DeleteStudent));
            }
        }

        private void AddStudentClicked(object args)
        {
            var rowEditEndedEventArgs = args as GridViewRowEditEndedEventArgs;
            var student = rowEditEndedEventArgs.EditedItem as Student;

            _unityContainer = (UnityContainer)Application.Current.Resources["IoC"];
            _studentService = (StudentService)_unityContainer.Resolve<IStudentService>();
            _studentService.AddStudent(student.Name, student.Email, student.Specialty, student.Course);
        }

        private void DeleteStudent(object args)
        {
            var deletedEventArgs = args as GridViewDeletingEventArgs;
            var student = deletedEventArgs.Items.Cast<Student>().First();

            _studentService.DeleteStudent(student.Id);
        }
    }
}
