namespace backend.Models;

public record BookSeries
{
    public int Id { get; set; }
    public int SeriesId { get; set; }
    public int BookId { get; set; }
    public int Sequence { get; set; }

    public virtual Book Book { get; set; }
}