using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<BillDetails> BillDetails { get; set; } = null!;

}