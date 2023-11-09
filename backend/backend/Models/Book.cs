using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models;

public record Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int? SeriesId { get; set; }

    public virtual Author Author { get; set; }
    public virtual Series Series { get; set; }
}

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).HasMaxLength(150);
        builder.Property(x => x.AuthorId);

        builder.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
    }
}
