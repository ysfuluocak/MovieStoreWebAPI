using Application.Interfaces.Repositories.DirectorRepository;
using MediatR;

namespace Application.Features.CQRS.Queries.GetDirectorsQuery
{
    public class GetDirectorsQueryHandler : IRequestHandler<GetDirectorsQueryRequest,List<GetDirectorsQueryResponse>>
    {
        private readonly IDirectorReadRepository _directorReadRepository;

        public GetDirectorsQueryHandler(IDirectorReadRepository directorReadRepository)
        {
            _directorReadRepository = directorReadRepository;
        }

        public async Task<List<GetDirectorsQueryResponse>> Handle(GetDirectorsQueryRequest request, CancellationToken cancellationToken)
        {
            var diredctors = _directorReadRepository.GetAll();
            var responseDirectors = new List<GetDirectorsQueryResponse>();
            foreach (var director in diredctors)
            {
                responseDirectors.Add(new() { FirstName = director.FirstName,LastName=director.LastName});
            }
            return responseDirectors;
        }
    }

}
