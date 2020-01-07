using Infrastructure;
using Infrastructure.Interfaces;
using Service;
using Service.Common;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace UniversityWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public UnityContainer Container { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Container = new UnityContainer();
            Container.RegisterType<MainWindow>();
            Container.RegisterType<IUniversityLocalContext, UniversityLocalContext>();
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IModelDataAnnotationCheck, ModelDataAnnotationCheck>();
            Container.RegisterType<IStudentService, StudentService>(new TransientLifetimeManager());
            Container.RegisterType<ITeacherService, TeacherService>(new TransientLifetimeManager());
            Container.RegisterType<IAppointmentService, AppointmentService>(new TransientLifetimeManager());

            Container.Resolve<MainWindow>().Show();

            Current.Resources.Add("IoC", Container);
        }
    }
}
