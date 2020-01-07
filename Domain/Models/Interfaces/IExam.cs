using System;

namespace Domain.Models
{
    public interface IExam
    {
        string Description { get; set; }
        Discipline Discipline { get; set; }
        DateTime ExaminationTimeStart { get; set; }
        DateTime ExaminationTimeEnd { get; set; }
        string Hall { get; set; }
        int Id { get; set; }
    }
}