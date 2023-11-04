using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffsetConverter>();
    }
}
