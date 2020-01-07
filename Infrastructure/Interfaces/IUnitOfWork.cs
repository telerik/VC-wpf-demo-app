using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> StudentRepository { get; }

        IGenericRepository<Discipline> DisciplineRepository { get; }

        IGenericRepository<Exam> ExamRepository { get; }

        void Commit();
        void RejectChanges();
        void Dispose();
    }
}
