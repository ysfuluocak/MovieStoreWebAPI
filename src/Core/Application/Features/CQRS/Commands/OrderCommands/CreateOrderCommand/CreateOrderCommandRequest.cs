using MediatR;

namespace Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommand
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public int CustomerId { get; set; }
        public string MovieName { get; set; }
        public decimal MoviePrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
