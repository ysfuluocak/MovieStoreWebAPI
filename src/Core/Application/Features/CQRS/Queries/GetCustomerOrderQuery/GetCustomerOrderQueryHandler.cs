using Application.Interfaces.Repositories.CustomerRepository;
using MediatR;

namespace Application.Features.CQRS.Queries.GetCustomerOrderQuery
{
    public class GetCustomerOrderQueryHandler : IRequestHandler<GetCustomerOrderQueryRequest, List<GetCustomerOrderQueryResponse>>
    {
        private readonly ICustomerReadRepository _customerReadRepository;

        public GetCustomerOrderQueryHandler(ICustomerReadRepository customerReadRepository)
        {
            _customerReadRepository = customerReadRepository;
        }

        public async Task<List<GetCustomerOrderQueryResponse>> Handle(GetCustomerOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerReadRepository.GetOrderByCustomerIdAsync(request.Id);
            var response = new List<GetCustomerOrderQueryResponse>();
            foreach (var order in customer.Orders)
            {
                response.Add(new() { MovieName = order.Movie.Name, OrderDate = order.DateOfPurchase.ToString("dd/MM/yyyy"), Price = order.TotalPrice });
            }
            return response;
            
        }
    }
}
