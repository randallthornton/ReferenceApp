using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace backend.Models;

public class DateTimeOffsetConverter : ValueConverter<DateTimeOffset, DateTimeOffset>
{
    public DateTimeOffsetConverter() : base(
        x => x.ToUniversalTime(),
        x => x.ToUniversalTime())
    { }
}
