using Service;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.ScheduleView;
using UniversityWPF.Commands;

namespace UniversityWPF.ViewModels
{
    public class SchedulerViewModel
    {
        private ObservableCollection<Appointment> appointments;
        private IAppointmentService _appointmentService;

        private ICommand _deleteAppointment;
        private ICommand _addAppointment;

        public SchedulerViewModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public ObservableCollection<Appointment> Appointments
        {
            get
            {
                if (this.appointments == null)
                {
                    this.appointments = this.CreateAppointments();
                }

                return this.appointments;
            }
        }

        public ICommand AddAppointment
        {
            get
            {
                return this._addAppointment
                       ?? (this._addAppointment = new RelayCommand(this.AddAppointmentClick));
            }
        }

        public ICommand DeleteAppointment
        {
            get
            {
                return this._deleteAppointment
                       ?? (this._deleteAppointment = new RelayCommand(this.DeleteAppointmentClick));
            }
        }

        private void DeleteAppointmentClick(object args)
        {
            AppointmentDeletedEventArgs appDeletedEventArgs = (AppointmentDeletedEventArgs)args;
            _appointmentService.RemoveAppointment(appDeletedEventArgs.Appointment.Subject);
        }

        private void AddAppointmentClick(object args)
        {
            AppointmentCreatedEventArgs appCreatedEventArgs = (AppointmentCreatedEventArgs)args;
            _appointmentService.AddAppointment(appCreatedEventArgs.CreatedAppointment.Subject,
                                               appCreatedEventArgs.CreatedAppointment.Start,
                                               appCreatedEventArgs.CreatedAppointment.End,
                                               "405");
        }

        private ObservableCollection<Appointment> CreateAppointments()
        {
            ObservableCollection<Appointment> apps = new ObservableCollection<Appointment>();
            var exams = _appointmentService.GetAppointments();

            foreach (var exam in exams)
            {
                apps.Add(new Appointment()
                        {
                            Subject = exam.Description,
                            Start = exam.ExaminationTimeStart,
                            End = exam.ExaminationTimeEnd,
                            Body = exam.Hall
                        });
            }

            return apps;
        }
    }
}
