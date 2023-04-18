using MediatR;

namespace Application.Features.CQRS.Commands.ActorCommands.CreateActorCommand
{
    public class CreateActorCommandRequest : IRequest<CreateActorCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
