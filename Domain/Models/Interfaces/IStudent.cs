using System.Collections.Generic;

namespace Domain.Models.Interfaces
{
    public interface IStudent : IPerson
    {
        string Course { get; set; }
        
        string Specialty { get; set; }
    }
}
