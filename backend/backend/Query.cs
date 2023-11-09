using backend.Models;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace backend;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks(ApplicationDbContext context)
    {
        return context.Books.AsNoTracking().AsQueryable();
    }
}
