using Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniversityWPF.Models;

namespace UniversityWPF.ViewModels
{
    public class ChartViewModel
    {
        private IStudentService _studentService;

        private IEnumerable<BarModel> _b1;
        private IEnumerable<BarModel> _b2;
        private IEnumerable<BarModel> _b3;
        
        public ChartViewModel(IStudentService studentService)
        {
            _studentService = studentService;
            this.PopulateChartModel();
        }

        public ObservableCollection<IChartModel> FunnelData { get; private set; }

        public IEnumerable<IBarModel> B1
        {
            get
            {
                if (this._b1 == null)
                {
                    this._b1 = new List<BarModel>() {
                        new BarModel("Networking", "Algebra", 66),
                        new BarModel("Electronics", "Algebra", 80),
                        new BarModel("Computer Science", "Algebra", 78)
                    };
                }

                return this._b1;
            }
        }

        public IEnumerable<IBarModel> B2
        {
            get
            {
                if (this._b2 == null)
                {
                    this._b2 = new List<BarModel>() {
                        new BarModel("Networking", "Programming", 94),
                        new BarModel("Electronics", "Programming", 76),
                        new BarModel("Computer Science", "Programming", 100)
                    };
                }

                return this._b2;
            }
        }
        
        public IEnumerable<IBarModel> B3
        {
            get
            {
                if (this._b3 == null)
                {
                    this._b3 = new List<BarModel>() {
                        new BarModel("Networking", "Physics", 67),
                        new BarModel("Electronics", "Physics", 44),
                        new BarModel("Computer Science", "Physics", 59)
                    };
                }

                return this._b3;
            }
        }

        private void PopulateChartModel()
        {
            var students = _studentService.GetAll();
            FunnelData = new ObservableCollection<IChartModel>();

            int networkingStudensCount = 0;
            int electronicsStudentsCount = 0;
            int computerScienceStudentsCount = 0;

            foreach (var student in students)
            {
                if (student.Specialty.Equals("Networking"))
                {
                    networkingStudensCount++;
                }
                else if (student.Specialty.Equals("Computer Science"))
                {
                    computerScienceStudentsCount++;
                }
                else if (student.Specialty.Equals("Electronics"))
                {
                    electronicsStudentsCount++;
                }
            }

            FunnelData.Add(new ChartModel { Value = 20, Label = "Networking" });
            FunnelData.Add(new ChartModel { Value = computerScienceStudentsCount, Label = "Computer Science" });
            FunnelData.Add(new ChartModel { Value = electronicsStudentsCount, Label = "Electronics" });
        }
    }
}
