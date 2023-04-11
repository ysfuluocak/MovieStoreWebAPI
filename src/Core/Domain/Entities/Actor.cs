using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<MovieActor> Movies { get; set; }
    }
}
