using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models;

public record Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Book> Books { get; set; }
}

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Author");

        builder.HasKey(a => a.Id);

        builder.Property(x => x.FirstName).HasMaxLength(150);
        builder.Property(x => x.LastName).HasMaxLength(150);
    }
}
