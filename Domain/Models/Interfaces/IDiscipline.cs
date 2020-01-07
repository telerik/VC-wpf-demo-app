namespace Domain.Models
{
    public interface IDiscipline
    {
        int Id { get; set; }

        string Title { get; set; }

        Teacher Teacher { get; set; }
    }
}