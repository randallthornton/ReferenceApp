using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Book> Books { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<Book>().HasData(new[]
        {
            new Book()
            {
                Id = 1,
                AuthorId = 1,
                SeriesId = 1,
                Title = "Red Rising",
            },
            new Book()
            {
                Id = 2,
                AuthorId = 1,
                SeriesId = 1,
                Title = "Golden Son",
            },
            new Book()
            {
                Id = 3,
                AuthorId = 1,
                SeriesId = 1,
                Title = "Morning Star"
            },
            new Book()
            {
                Id = 4,
                AuthorId = 1,
                SeriesId = 1,
                Title = "Iron Gold"
            },
            new Book()
            {
                Id = 5,
                AuthorId = 1,
                SeriesId = 1,
                Title = "Dark Age"
            },
            new Book()
            {
                Id = 6,
                AuthorId = 1,
                SeriesId = 1,
                Title = "Light Bringer"
            }
        });

        builder.Entity<Author>().HasData(new[]
        {
            new Author()
            {
                Id = 1,
                FirstName = "Pierce",
                LastName = "Brown",
            }
        });

        builder.Entity<Series>().HasData(new[]
        {
            new Series()
            {
                Id = 1,
                AuthorId = 1,
                Name = "Red Rising"
            }
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
}
