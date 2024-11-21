using crud_api.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_api.DAL
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
