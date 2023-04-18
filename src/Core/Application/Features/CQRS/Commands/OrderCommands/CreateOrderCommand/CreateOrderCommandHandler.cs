using Application.Interfaces.Repositories.CustomerRepository;
using Application.Interfaces.Repositories.MovieRepository;
using Application.Interfaces.Repositories.OrderRepository;
using Application.Interfaces.Repositories.UserRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IMovieReadRepository _movieReadRepository;
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly IUserReadRepository _userReadRepository;

        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, IMovieReadRepository movieReadRepository, ICustomerReadRepository customerReadRepository, IUserReadRepository userReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _movieReadRepository = movieReadRepository;
            _customerReadRepository = customerReadRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var movie =await _movieReadRepository.GetAsync(m => m.Name == request.MovieName);
            var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);
            var user = await _userReadRepository.GetByIdAsync(customer.UserId);
            var order = new Order()
            {
                // CustomerId = request.CustomerId,
                Customer = customer,
                DateOfPurchase = request.OrderDate,
                Movie = movie,
                TotalPrice = request.MoviePrice + request.MoviePrice * 18 / 100
            };
            await _orderWriteRepository.AddAsync(order);
            await _orderWriteRepository.SaveAsync();
            return new CreateOrderCommandResponse()
            {
                MovieName = movie.Name,
                MoviePrice = order.TotalPrice,
                OrderDate = order.DateOfPurchase.ToString("dd/MM/yyyy"),
                CustomerName = user.FirstName + " " + user.LastName
            };
        }
    }
}
