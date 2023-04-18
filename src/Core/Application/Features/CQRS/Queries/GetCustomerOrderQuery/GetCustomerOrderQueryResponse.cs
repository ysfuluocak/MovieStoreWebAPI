namespace Application.Features.CQRS.Queries.GetCustomerOrderQuery
{
	public class GetCustomerOrderQueryResponse
    {
        public string MovieName { get; set; }
        public string OrderDate { get; set; }
        public decimal Price { get; set; }
    }
}
