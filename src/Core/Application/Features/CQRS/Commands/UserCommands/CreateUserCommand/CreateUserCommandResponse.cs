namespace Application.Features.CQRS.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommandResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
