using MediatR;

namespace Application.Features.CQRS.Queries.GetCustomerOrderQuery
{
    public class GetCustomerOrderQueryRequest : IRequest<List<GetCustomerOrderQueryResponse>>
    {
        public int Id { get; set; }
    }
}
