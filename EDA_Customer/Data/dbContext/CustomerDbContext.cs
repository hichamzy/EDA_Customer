using EDA_Customer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EDA_Customer.Data.dbContext
{
    public class CustomerDbContext : DbContext

    {
        public  CustomerDbContext()
        {
        }
        public CustomerDbContext(DbContextOptions dbContextOptions):base(dbContextOptions) { 
        
            
        }

        public DbSet<Customer> customers {  get; set; }
        public DbSet<Product> products { get; set; }

    }
}
