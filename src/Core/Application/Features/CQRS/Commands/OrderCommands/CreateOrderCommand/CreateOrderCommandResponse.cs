namespace Application.Features.CQRS.Commands.OrderCommands.CreateOrderCommand
{
    public class CreateOrderCommandResponse
    {
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public decimal MoviePrice { get; set; }
        public string OrderDate { get; set; }
    }
}
