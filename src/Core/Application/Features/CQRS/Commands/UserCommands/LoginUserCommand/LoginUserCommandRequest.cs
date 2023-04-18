﻿using MediatR;

namespace Application.Features.CQRS.Commands.UserCommands.LoginUserCommand
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
