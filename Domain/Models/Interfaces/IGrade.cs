namespace Domain.Models
{
    public interface IGrade
    {
        Discipline Discipline { get; set; }

        int Id { get; set; }

        int Score { get; set; }

        Student Student { get; set; }
    }
}