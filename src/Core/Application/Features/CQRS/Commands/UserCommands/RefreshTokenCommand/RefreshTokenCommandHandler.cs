using Application.Dtos;
using Application.Interfaces.Repositories.UserRepository;
using Application.Interfaces.Token;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.UserCommands.RefreshTokenCommand
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ITokenHelper _tokenHelper;

        public RefreshTokenCommandHandler(IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, ITokenHelper tokenHelper)
        {
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            User? user =await _userReadRepository.GetAsync(u=>u.RefreshToken == request.RefreshToken);
            if (user is not null && user.RefreshTokenExpireDate>DateTime.UtcNow)
            {
                AccessToken token = _tokenHelper.CreateAccessToken();
                _userWriteRepository.UpdateRefreshToken(user,token);
                await _userWriteRepository.SaveAsync();
                return new RefreshTokenCommandResponse()
                {
                    Token = token.Token,
                    Expiration = token.Expiration.AddMinutes(5),
                    RefreshToken = token.RefreshToken
                };
            }
            throw new Exception("Refresh tokun süresi doldu!");
        }
    }
}

