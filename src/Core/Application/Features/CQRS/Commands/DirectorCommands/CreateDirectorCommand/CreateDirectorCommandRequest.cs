using MediatR;

namespace Application.Features.CQRS.Commands.DirectorCommands.CreateDirectorCommand
{
    public class CreateDirectorCommandRequest : IRequest<CreateDirectorCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
