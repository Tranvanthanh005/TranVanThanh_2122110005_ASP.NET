using Microsoft.EntityFrameworkCore;
using TranVanThanh_2122110005.Model;

namespace TranVanThanh_2122110005.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
<<<<<<< HEAD

=======
   
>>>>>>> 849f36551e6ac5169e4cf8c8e04f3c694f087db2
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
<<<<<<< HEAD
        public DbSet<Post> Posts { get; set; }

        public DbSet<News> News { get; set; }
=======
>>>>>>> 849f36551e6ac5169e4cf8c8e04f3c694f087db2

    }
}
