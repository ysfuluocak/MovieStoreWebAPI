using Application.Features.CQRS.Commands.UserCommands.CreateUserCommand;
using Application.Features.CQRS.Commands.UserCommands.LoginUserCommand;
using Application.Features.CQRS.Commands.UserCommands.RefreshTokenCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromQuery]string refreshToken)
        {
            RefreshTokenCommandRequest command = new RefreshTokenCommandRequest() {RefreshToken = refreshToken};
            RefreshTokenCommandResponse response =await _mediator.Send(command);
            return Ok(response);
        }
    }
}
