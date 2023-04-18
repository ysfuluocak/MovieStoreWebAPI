using Application.Features.CQRS.Commands.CustomerCommands.CreateCustomerCommand;
using Application.Features.CQRS.Queries.GetCustomerOrderQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrders(int id)
        {
            var query = new GetCustomerOrderQueryRequest() { Id = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
