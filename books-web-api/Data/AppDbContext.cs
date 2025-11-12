using books_web_api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace books_web_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<Book> Books { get; set; }
}