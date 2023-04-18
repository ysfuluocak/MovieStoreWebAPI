using Application.Interfaces.Repositories.DirectorRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.DirectorCommands.CreateDirectorCommand
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommandRequest, CreateDirectorCommandResponse>
    {
        private readonly IDirectorWriteRepository _directorWriteRepository;

        public CreateDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository)
        {
            _directorWriteRepository = directorWriteRepository;
        }

        public async Task<CreateDirectorCommandResponse> Handle(CreateDirectorCommandRequest request, CancellationToken cancellationToken)
        {

            var director = new Director()
            {

                FirstName = request.FirstName,
                LastName = request.LastName,

            };
            await _directorWriteRepository.AddAsync(director);
            await _directorWriteRepository.SaveAsync();
            return new();
        }
    }
}
