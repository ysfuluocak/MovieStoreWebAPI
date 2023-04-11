using Application.Interfaces.Repositories.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.ActorRepository
{
    public interface IActorReadRepository : IReadRepository<Actor>
    {
    }
}
