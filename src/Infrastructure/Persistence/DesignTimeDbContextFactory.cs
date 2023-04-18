using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Context;

namespace Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MovieStoreDbContext> //PowerSell Üzerinden Komut yazmak için gerekli sınıf.
    {
        public MovieStoreDbContext CreateDbContext(string[] args)
        {


            DbContextOptionsBuilder<MovieStoreDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configurations.ConnectionString);
            return new(dbContextOptionsBuilder.Options);

        }
    }
}
