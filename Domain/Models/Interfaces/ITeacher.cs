namespace Domain.Models.Interfaces
{
    public interface ITeacher : IPerson
    {
        string Rank { get; set; }
    }
}
