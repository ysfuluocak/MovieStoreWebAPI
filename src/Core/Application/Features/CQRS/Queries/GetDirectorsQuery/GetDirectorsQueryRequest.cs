using MediatR;

namespace Application.Features.CQRS.Queries.GetDirectorsQuery
{
    public class GetDirectorsQueryRequest : IRequest<List<GetDirectorsQueryResponse>>
    {
    }
}
