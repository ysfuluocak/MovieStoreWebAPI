using Domain.Entities.Common;

namespace Domain.Entities
{
    public class MovieActor :BaseEntity
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
