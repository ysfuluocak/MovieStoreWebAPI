using Application.Dtos;
using Application.Hashing;
using Application.Interfaces.Repositories.UserRepository;
using Application.Interfaces.Token;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly ITokenHelper _tokenHelper;

        public CreateUserCommandHandler(IUserWriteRepository userWriteRepository, ITokenHelper tokenHelper)
        {
            _userWriteRepository = userWriteRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            await _userWriteRepository.AddAsync(user);
            await _userWriteRepository.SaveAsync();
            AccessToken token = _tokenHelper.CreateAccessToken();
            //_userWriteRepository.UpdateRefreshToken(user,token);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            await _userWriteRepository.SaveAsync();
            return new CreateUserCommandResponse() 
            {
                AccessToken = token.Token,
                Expiration = token.Expiration,
                RefreshToken = token.RefreshToken
            };
        }
    }
}
