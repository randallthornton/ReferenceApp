using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models;

public record Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
}

public record CreatePostRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(x => x.PostId);

        builder.Property(x => x.Title).HasMaxLength(255);
        builder.Property(x => x.Content).HasMaxLength(10000);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.CreatedDate);
    }
}