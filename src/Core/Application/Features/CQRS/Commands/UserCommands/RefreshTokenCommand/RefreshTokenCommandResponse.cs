namespace Application.Features.CQRS.Commands.UserCommands.RefreshTokenCommand
{
    public class RefreshTokenCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }

    }
}

