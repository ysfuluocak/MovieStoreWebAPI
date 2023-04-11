using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Director : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
