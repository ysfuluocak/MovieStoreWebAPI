using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Genre> FavouriteGenres { get; set; }
        public ICollection<Order> Orders { get; set; }
        
    }
}
