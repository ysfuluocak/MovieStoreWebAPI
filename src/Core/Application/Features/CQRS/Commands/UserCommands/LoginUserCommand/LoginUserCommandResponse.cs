namespace Application.Features.CQRS.Commands.UserCommands.LoginUserCommand
{
    public class LoginUserCommandResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
