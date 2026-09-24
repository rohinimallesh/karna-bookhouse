using Microsoft.EntityFrameworkCore;
using KarnaBookHouse.API.Models;

namespace KarnaBookHouse.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}