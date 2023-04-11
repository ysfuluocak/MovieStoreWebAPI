using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string MovieDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public ICollection<MovieActor> Actors { get; set; }
        public Genre Genre {get; set; }
        public Director Director { get; set; }

    }
}
