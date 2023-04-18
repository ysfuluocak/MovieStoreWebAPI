using Application.Interfaces.Repositories.DirectorRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.DirectorCommands.DeleteDirectorCommand
{
    public class DeleteDirectorCommandRequest : IRequest<DeleteDirectorCommandResponse>
    {
        public int Id { get; set; }
    }
    public class DeleteDirectorCommandResponse
    {

    }
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommandRequest, DeleteDirectorCommandResponse>
    {
        readonly IDirectorWriteRepository _directorWriteRepository;
        readonly IDirectorReadRepository _directorReadRepository;

        public DeleteDirectorCommandHandler(IDirectorWriteRepository directorWriteRepository, IDirectorReadRepository directorReadRepository)
        {
            _directorWriteRepository = directorWriteRepository;
            _directorReadRepository = directorReadRepository;
        }

        public async Task<DeleteDirectorCommandResponse> Handle(DeleteDirectorCommandRequest request, CancellationToken cancellationToken)
        {
            var director = await _directorReadRepository.GetByIdAsync(request.Id);
           _directorWriteRepository.Delete(director);
           await  _directorWriteRepository.SaveAsync();
            return new ();
        }
    }
}
