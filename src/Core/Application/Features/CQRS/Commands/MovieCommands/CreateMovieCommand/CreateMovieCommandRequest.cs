using MediatR;

namespace Application.Features.CQRS.Commands.MovieCommands.CreateMovieCommand
{
    public class CreateMovieCommandRequest : IRequest<CreateMovieCommandResponse>
    {
        public string Name { get; set; }
        public string MovieDate { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public List<int> Actors { get; set; }
    }
}
