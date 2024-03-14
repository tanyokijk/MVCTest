using Microsoft.EntityFrameworkCore;

namespace MVC.Models;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

    }
    public DbSet<Car> Car { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
}
