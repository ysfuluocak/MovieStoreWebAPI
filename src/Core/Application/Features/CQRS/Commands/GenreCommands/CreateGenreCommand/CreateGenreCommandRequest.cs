using MediatR;

namespace Application.Features.CQRS.Commands.GenreCommands.CreateGenreCommand
{
    public class CreateGenreCommandRequest : IRequest<CreateGenreCommandResponse>
    {
        public string Title { get; set; }
    }
}
