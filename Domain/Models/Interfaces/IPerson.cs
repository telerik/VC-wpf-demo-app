namespace Domain.Models.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }

        string Name { get; set; }

        string Email { get; set; }
    }
}
