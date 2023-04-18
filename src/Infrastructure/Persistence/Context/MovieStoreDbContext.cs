using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MovieStoreDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MovieStoreDb;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
        public MovieStoreDbContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Movie> Movies { get;set; }
        DbSet<Actor> Actors { get;set; }
        DbSet<Order> Orders { get;set; }
        DbSet<Genre> Genres { get;set; }
        DbSet<Director> Directors { get;set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<User> Users { get;set; }

    }
}
