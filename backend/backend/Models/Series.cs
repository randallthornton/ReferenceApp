using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models;

public record Series
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Book> Books { get; set; }
    public virtual Author Author { get; set; }
}

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(150);

        builder.HasOne(x => x.Author).WithMany().HasForeignKey(x => x.AuthorId);
        builder.HasMany(x => x.Books).WithOne(x => x.Series).HasForeignKey(x => x.SeriesId);
    }
}
