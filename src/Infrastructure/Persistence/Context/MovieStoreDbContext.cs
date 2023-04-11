using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MovieStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MovieStoreDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        DbSet<Movie> Movies { get;set; }
        DbSet<Actor> Actors { get;set; }
        DbSet<Order> Orders { get;set; }
        DbSet<Genre> Genres { get;set; }
        DbSet<Director> Directors { get;set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<User> Users { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId);

            // Movie ve Actor arasında n-n ilişkisi
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(ma => ma.ActorId);

            // Movie ve Director arasında 1-1 ilişkisi
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(d => d.DirectorId);
        }
    }
}
