using Application.Dtos;
using Application.Interfaces.Repositories.UserRepository;
using Application.Interfaces.Token;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.UserCommands.CreateTokenCommand
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommandRequest, CreateTokenCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserWriteRepository _userWriteRepository;

        public CreateTokenCommandHandler(IUserReadRepository userReadRepository, ITokenHelper tokenHelper, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _tokenHelper = tokenHelper;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<CreateTokenCommandResponse> Handle(CreateTokenCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await _userReadRepository.GetAsync(u => u.Email == request.Email);
            AccessToken token = _tokenHelper.CreateAccessToken();
            _userWriteRepository.UpdateRefreshToken(user, token);
            //user.RefreshToken = token.RefreshToken;
            //user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            await _userWriteRepository.SaveAsync();
            return new CreateTokenCommandResponse()
            {
                Token = token.Token,
                Expiration = token.Expiration,
                RefreshToken = token.RefreshToken
            };
        }
    }
}
