using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Grade : IGrade
    {
        public int Id { get; set; }
        
        [Required]
        public Discipline Discipline { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public Student Student { get; set; }
    }
}
