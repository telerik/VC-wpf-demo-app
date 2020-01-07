using Domain.Models;
using Domain.Models.Interfaces;
using Infrastructure;
using Infrastructure.Interfaces;
using Service.Common;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class StudentService : IStudentService
    {
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUniversityLocalContext _universityLocalContext;

        public StudentService(IModelDataAnnotationCheck modelDataAnnotationCheck, 
                              IUnitOfWork unitOfWork, 
                              IUniversityLocalContext universityLocalContext)
        {
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
            _unitOfWork = unitOfWork;
            _universityLocalContext = universityLocalContext;
        }

        public void AddStudent(string name,
                               string email,
                               string specialty,
                               string course)
        {
            var student = new Student
            {
                Name = name,
                Email = email,
                Specialty = specialty,
                Course = course
            };

            ValidateModelDataAnnotations(student);

            //DB
            try
            {
                _unitOfWork.StudentRepository.Add(student);
            }
            catch
            {
                _unitOfWork.RejectChanges();
            }

            _unitOfWork.Commit();

            //LOCAL
            try
            {
                var id = _universityLocalContext.Students.Count + 1;
                student.Id = id;
                _universityLocalContext.Students.Add(student);
            }
            catch { }
        }

        public void DeleteStudent(int id)
        {
            var student = (from s in _unitOfWork.StudentRepository.Entities
                               where s.Id.Equals(id)
                               select s).First();

            _unitOfWork.StudentRepository.Remove(student);
            _unitOfWork.Commit();
        }

        public void DeleteStudentFromLocalRepository(int id)
        {
            var student = (from s in _universityLocalContext.Students
                           where s.Id.Equals(id)
                           select s).First();

            _universityLocalContext.Students.Remove(student);
        }

        public ICollection<Student> GetAll()
        {
            return _unitOfWork.StudentRepository.Entities.ToList();
        }

        public IStudent GetById(int id)
        {
            return (from s in _unitOfWork.StudentRepository.Entities
                           where s.Id.Equals(id)
                           select s).First();
        }

        public void ValidateModelDataAnnotations(IStudent student)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(student);
        }
    }
}
