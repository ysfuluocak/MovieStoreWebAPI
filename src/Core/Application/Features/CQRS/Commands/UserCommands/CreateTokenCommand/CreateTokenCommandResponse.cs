namespace Application.Features.CQRS.Commands.UserCommands.CreateTokenCommand
{
    public class CreateTokenCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}