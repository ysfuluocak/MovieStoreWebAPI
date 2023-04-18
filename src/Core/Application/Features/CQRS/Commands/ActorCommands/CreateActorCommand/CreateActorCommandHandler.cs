using Application.Interfaces.Repositories.ActorRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.ActorCommands.CreateActorCommand
{
    public class CreateActorCommandHandler : IRequestHandler<CreateActorCommandRequest, CreateActorCommandResponse>
    {
        private readonly IActorWriteRepository _actorWriteRepository;

        public CreateActorCommandHandler(IActorWriteRepository actorWriteRepository)
        {
            _actorWriteRepository = actorWriteRepository;
        }

        public async Task<CreateActorCommandResponse> Handle(CreateActorCommandRequest request, CancellationToken cancellationToken)
        {
            var actor = new Actor()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,

            };
            await _actorWriteRepository.AddAsync(actor);
            await _actorWriteRepository.SaveAsync();
            return new();
        }
    }
}
