using EDA_Customer.Data.dbContext;
using EDA_Customer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDA_Customer.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDbContext _db;
        public CustomerController(CustomerDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("/customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomer()
        {
            return await _db.customers.ToListAsync();
        }

        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _db.products.ToListAsync();
        }



        [HttpPost]
        [Route("/products")]
        public async Task PostProducts(Product customer)
        {
            _db.products.Add(customer);
            await _db.SaveChangesAsync();
        }

        [HttpPost]
        [Route("/cutomers")]
        public async Task PostCustomer(Customer customer)
        {
            _db.customers.Add(customer);
            await _db.SaveChangesAsync();
        } 

    }
}
