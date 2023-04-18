using Application.Dtos;
using Application.Hashing;
using Application.Interfaces.Repositories.UserRepository;
using Application.Interfaces.Token;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.UserCommands.LoginUserCommand
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserWriteRepository _userWriteRepository;

        public LoginUserCommandHandler(IUserReadRepository userReadRepository, ITokenHelper tokenHelper, IUserWriteRepository userWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _tokenHelper = tokenHelper;
            _userWriteRepository = userWriteRepository;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            User? user =await _userReadRepository.GetAsync(u=>u.Email==request.Email);
            if (user != null)
            {
                if(HashingHelper.VerifyPasswordHash(request.Password,user.PasswordSalt,user.PasswordHash))
                {
                    AccessToken token = _tokenHelper.CreateAccessToken();
                    _userWriteRepository.UpdateRefreshToken(user, token);
                    await _userWriteRepository.SaveAsync();
                    return new LoginUserCommandResponse()
                    {
                        Token = token.Token,
                        Expiration = token.Expiration.AddMinutes(5),
                        RefreshToken = token.RefreshToken
                    };
                }          
                throw new Exception("Kullanıcı adı veya şifre hatalı!");
            }
            throw new Exception("Kullanıcı bulunamadı!");
        }
    }
}
