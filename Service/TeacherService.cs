using Domain.Models;
using Domain.Models.Interfaces;
using Infrastructure;
using Service.Common;

namespace Service
{
    public class TeacherService : ITeacherService
    {
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;
        private readonly IUniversityLocalContext _universityLocalContext;

        public TeacherService(IModelDataAnnotationCheck modelDataAnnotationCheck, IUniversityLocalContext universityLocalContext)
        {
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
            _universityLocalContext = universityLocalContext;
        }

        public void AddTeacher(string name,
                               string email,
                               string rank)
        {
            var teacher = new Teacher
            {
                Name = name,
                Email = email,
                Rank = rank
            };

            ValidateModelDataAnnotations(teacher);

            try
            {
                var id = _universityLocalContext.Teachers.Count + 1;
                teacher.Id = id;
                _universityLocalContext.Teachers.Add(teacher);
            }
            catch { }
        }

        public void ValidateModelDataAnnotations(ITeacher teacher)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(teacher);
        }
    }
}
