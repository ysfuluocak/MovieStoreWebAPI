using Application.Features.CQRS.Commands.MovieCommands.CreateMovieCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieCommandRequest request)
        {
           await _mediator.Send(request);
            return Ok();
        }
    }
}
