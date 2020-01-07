namespace UniversityWPF.Models
{
    public class BarModel : IBarModel
    {
        private string _discipline;
        private string _specialty;
        private double _grade;

        public BarModel(string specialty, string discipline, double grade)
        {
            this._specialty = specialty;
            this._discipline = discipline;
            this._grade = grade;
        }

        public string DisciplineName
        {
            get
            {
                return this._discipline;
            }
        }

        public string SpecialtyName
        {
            get
            {
                return this._specialty;
            }
        }

        public double Grade
        {
            get
            {
                return this._grade;
            }
        }
    }
}
