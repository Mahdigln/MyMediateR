using Microsoft.EntityFrameworkCore;
using MyMediateR.Models;

namespace MyMediateR.Context;

public class MyMediateRContext : DbContext
{
    public MyMediateRContext(DbContextOptions<MyMediateRContext> options)
        : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}