using Microsoft.EntityFrameworkCore;
using WebHost.Models;

namespace WebHost.data;

public class MyContext:DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
}