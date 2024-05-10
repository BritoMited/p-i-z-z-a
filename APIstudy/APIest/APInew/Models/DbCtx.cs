using Microsoft.EntityFrameworkCore;
namespace APInew.Models;

public class DbCtx : DbContext
{
    public DbSet<Pizzas> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=sabores.db");
    }
}