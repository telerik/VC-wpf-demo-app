using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable, XmlRoot("Exam")]
    public class Exam : IExam, INotifyPropertyChanged
    {
        private int _id;
        private string _description;
        private DateTime _examinationTimeStart;
        private DateTime _examinationTimeEnd;
        private string _hall;
        private Discipline _discipline;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        [Required]
        public DateTime ExaminationTimeStart
        {
            get
            {
                return _examinationTimeStart;
            }
            set
            {
                _examinationTimeStart = value;
                OnPropertyChanged(nameof(ExaminationTimeStart));
            }
        }

        [Required]
        public DateTime ExaminationTimeEnd
        {
            get
            {
                return _examinationTimeEnd;
            }
            set
            {
                _examinationTimeEnd = value;
                OnPropertyChanged(nameof(ExaminationTimeEnd));
            }
        }

        [Required]
        public string Hall
        {
            get
            {
                return _hall;
            }
            set
            {
                _hall = value;
                OnPropertyChanged(nameof(Hall));
            }
        }

        [Required]
        public Discipline Discipline
        {
            get
            {
                return _discipline;
            }
            set
            {
                _discipline = value;
                OnPropertyChanged(nameof(Discipline));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
