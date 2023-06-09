﻿using Application.Interfaces.Repositories.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories.CustomerRepository
{
    public interface ICustomerWriteRepository : IWriteRepository<Customer>
    {
    }
}
