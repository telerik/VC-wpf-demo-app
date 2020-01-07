using System.Collections.Generic;
using Domain.Models;
using Domain.Models.Interfaces;

namespace Service
{
    public interface IStudentService
    {
        void AddStudent(string name, string email, string specialty, string course);
        void DeleteStudent(int id);
        void DeleteStudentFromLocalRepository(int id);
        ICollection<Student> GetAll();
        IStudent GetById(int id);
        void ValidateModelDataAnnotations(IStudent student);
    }
}