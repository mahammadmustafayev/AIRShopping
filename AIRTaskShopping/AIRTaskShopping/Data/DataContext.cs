using AIRTaskShopping.Models;
using Microsoft.EntityFrameworkCore;

namespace AIRTaskShopping.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Product> Products =>Set<Product>();
    }
}
