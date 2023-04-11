using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
    }
}
