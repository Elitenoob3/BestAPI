using Microsoft.EntityFrameworkCore;
using Project.Entities;

namespace Project.Context;

public class Context : DbContext
{
    public DbSet<EMovie> Movies { get; set; }
    public DbSet<EGenre> Genres { get; set; }
    public DbSet<ECast> Casts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=moviesdb;user=root;password=anas");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var movieModelBuilder = modelBuilder.Entity<EMovie>();
        movieModelBuilder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(255).IsRequired();
        movieModelBuilder.Property(x => x.VideoSource).HasColumnName("Source").HasMaxLength(255).IsRequired();

        movieModelBuilder.HasMany(a => a.Genres)
            .WithMany(b => b.Movies)
            .UsingEntity(j => j.ToTable("MovieGenreLink"));

        movieModelBuilder.HasMany(a => a.Cast).WithOne(b => b.Movie).HasForeignKey(b => b.movieId);
        
        var genreModelBuilder = modelBuilder.Entity<EGenre>();
        genreModelBuilder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        
        var castModelBuilder = modelBuilder.Entity<ECast>();
        castModelBuilder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        castModelBuilder.Property(x => x.Role).HasMaxLength(255).IsRequired();
        
        base.OnModelCreating(modelBuilder);
    }
}