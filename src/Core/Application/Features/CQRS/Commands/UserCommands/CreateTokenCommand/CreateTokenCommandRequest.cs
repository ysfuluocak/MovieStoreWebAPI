using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.UserCommands.CreateTokenCommand
{
    public class CreateTokenCommandRequest : IRequest<CreateTokenCommandResponse>
    {
        public string Email { get; set; }
    }
}
