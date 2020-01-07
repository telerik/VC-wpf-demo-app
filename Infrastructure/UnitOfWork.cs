using Domain.Models;
using Infrastructure.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IGenericRepository<Student> StudentRepository =>
            new GenericRepository<Student>(_dbContext);

        public IGenericRepository<Discipline> DisciplineRepository =>
            new GenericRepository<Discipline>(_dbContext);

        public IGenericRepository<Exam> ExamRepository =>
            new GenericRepository<Exam>(_dbContext);


        public UnitOfWork()
        {
            _dbContext = new StudentDbContext();
        }
        
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
