using Application.Features.CQRS.Commands.DirectorCommands.CreateDirectorCommand;
using Application.Features.CQRS.Commands.DirectorCommands.DeleteDirectorCommand;
using Application.Features.CQRS.Queries.GetDirectorMoviesQuery;
using Application.Features.CQRS.Queries.GetDirectorsQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var query =new CreateDirectorCommandRequest();
            await _mediator.Send(query);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetDirectorsQueryRequest();
            List<GetDirectorsQueryResponse> response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDirectorMovies(int id)
        {
            var query = new GetDirectorMoviesQueryRequest() { Id=id};
            var response = await _mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDirectorCommandRequest() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
       
    }
}
