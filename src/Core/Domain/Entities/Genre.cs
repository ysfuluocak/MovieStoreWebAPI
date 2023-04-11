using Domain.Entities.Common;

namespace Domain.Entities
{
    public  class Genre : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Customer> Customers { get; set; }

    }
}
