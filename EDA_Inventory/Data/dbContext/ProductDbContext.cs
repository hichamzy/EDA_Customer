using EDA_Customer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EDA_Customer.Data.dbContext
{
    public class ProductDbContext : DbContext

    {
        public  ProductDbContext()
        {
        }
        public ProductDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) { 
        
            
        }

  
        public DbSet<Product> products { get; set; }

    }
}
