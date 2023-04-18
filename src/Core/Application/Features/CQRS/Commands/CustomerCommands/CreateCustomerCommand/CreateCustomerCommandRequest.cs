using MediatR;

namespace Application.Features.CQRS.Commands.CustomerCommands.CreateCustomerCommand
{
    public class CreateCustomerCommandRequest : IRequest<CreateCustomerCommandResponse>
    {
        public int UserId { get; set; }
    }
}
