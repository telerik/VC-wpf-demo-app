using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Discipline : IDiscipline
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required]
        public Teacher Teacher { get; set; }
    }
}
