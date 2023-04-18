using MediatR;

namespace Application.Features.CQRS.Commands.UserCommands.RefreshTokenCommand
{
    public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}

