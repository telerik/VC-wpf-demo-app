using System.Data.Entity;
using Domain.Models;

namespace Infrastructure
{
    public interface IStudentDbContext
    {
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Grade> Grades { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }
    }
}