using Domain.Models.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable, XmlRoot("Student")]
    public class Student : IStudent, INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _email;
        private string _specialty;
        private string _course;

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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [Required]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string Specialty
        {
            get
            {
                return _specialty;
            }
            set
            {
                _specialty = value;
                OnPropertyChanged(nameof(Specialty));
            }
        }

        [Required(AllowEmptyStrings = false)]
        public string Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
                OnPropertyChanged(nameof(Course));
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
