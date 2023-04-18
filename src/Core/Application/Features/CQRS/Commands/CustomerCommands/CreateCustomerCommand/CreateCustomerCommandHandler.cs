using Application.Interfaces.Repositories.CustomerRepository;
using Application.Interfaces.Repositories.UserRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.CustomerCommands.CreateCustomerCommand
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public CreateCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository, IUserReadRepository userReadRepository)
        {
            _customerWriteRepository = customerWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetByIdAsync(request.UserId);
            if (user is null)
            {
                throw new InvalidOperationException("kullanıcı bulunamadı");
            }
            var customer = new Customer()
            {
                User = user
            };
            await _customerWriteRepository.AddAsync(customer);
            await _customerWriteRepository.SaveAsync();
            return new();
        }
    }
}
