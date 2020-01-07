using Infrastructure.Local;

namespace Infrastructure
{
    public class UniversityLocalContext : IUniversityLocalContext
    {
        public StudentList Students { get; } = new StudentList();

        public TeacherList Teachers { get; } = new TeacherList();
    }
}
