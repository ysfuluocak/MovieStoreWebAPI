using MediatR;

namespace Application.Features.CQRS.Queries.GetDirectorMoviesQuery
{
    public class GetDirectorMoviesQueryRequest : IRequest<List<GetDirectorMoviesQueryResponse>>
    {
        public int Id { get; set; }
    }
}
