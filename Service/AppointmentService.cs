using Domain.Models;
using Infrastructure.Interfaces;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IModelDataAnnotationCheck modelDataAnnotationCheck, IUnitOfWork unitOfWork)
        {
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
            _unitOfWork = unitOfWork;
        }

        public void AddAppointment(string description,
                              DateTime examTimeStart,
                              DateTime examTimeEnd,
                              string location)
        {
            string disciplineTitle = description.Split(' ').First();

            var discipline = (from d in _unitOfWork.DisciplineRepository.Entities
                              where d.Title.Equals(disciplineTitle)
                              select d).First();

            var exam = new Exam
            {
                Description = description,
                Hall = location,
                Discipline = discipline,
                ExaminationTimeStart = examTimeStart,
                ExaminationTimeEnd = examTimeEnd
            };

            _modelDataAnnotationCheck.ValidateModelDataAnnotations(exam);

            _unitOfWork.ExamRepository.Add(exam);
            _unitOfWork.Commit();
        }

        public void RemoveAppointment(string summary)
        {
            var exam = (from e in _unitOfWork.ExamRepository.Entities
                        where e.Description.Equals(summary)
                        select e).First();

            _unitOfWork.ExamRepository.Remove(exam);
            _unitOfWork.Commit();
        }

        public void ChangeAppointment(string description,
                              DateTime examTimeStart,
                              DateTime examTimeEnd,
                              string location,
                              string changedPropertry)
        {
            if (changedPropertry != "Summary")
            {
                var exam = (from e in _unitOfWork.ExamRepository.Entities
                            where e.Description.Equals(description)
                            select e).First();

                _unitOfWork.ExamRepository.Remove(exam);
                _unitOfWork.Commit();
            }
            else
            {
                var exam = (from e in _unitOfWork.ExamRepository.Entities
                            where e.Hall.Equals(location)
                            select e).First();

                _unitOfWork.ExamRepository.Remove(exam);
                _unitOfWork.Commit();
            }

            this.AddAppointment(description, examTimeStart, examTimeEnd, location);
        }

        public ICollection<Exam> GetAppointments()
        {
            return _unitOfWork.ExamRepository.Entities.ToList();
        }
    }
}
