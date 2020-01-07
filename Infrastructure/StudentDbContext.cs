using Domain.Models;
using Infrastructure.Interfaces;
using System.Data.Entity;

namespace Infrastructure
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext() : base(@"data source=.\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True") { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
