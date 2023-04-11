using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Genre> FavouriteGenres { get; set; }
        public ICollection<Order> Orders { get; set; }
        
    }
}
