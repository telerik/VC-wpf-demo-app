using Infrastructure.Local;

namespace Infrastructure
{
    public interface IUniversityLocalContext
    {
        StudentList Students { get; }

        TeacherList Teachers { get; }
    }
}