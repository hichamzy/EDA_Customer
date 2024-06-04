using EDA_Customer.Data.dbContext;
using EDA_Customer.Data.Models;
using EDA_Inventory.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace EDA_Customer.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _db;
        private IRabbitMqUtil _rabbitMqUtil;
        public ProductController(ProductDbContext db, IRabbitMqUtil rabbitMqUtil)
        {
            _db = db;
            _rabbitMqUtil = rabbitMqUtil;
        }


        [HttpGet]
        [Route("/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _db.products.ToListAsync();
        }


        [HttpPut]
        [Route("/products")]
        public async Task UpdateProduct(int id ,Product pr)
        {
            
            var oldProduct=await _db.products.FindAsync(id);
            if (oldProduct!=null)
            {
                oldProduct.ProductId = pr.ProductId;
                oldProduct.Name = pr.Name;
                oldProduct.ItemInCart = pr.ItemInCart;
                await _db.SaveChangesAsync();
            }
           

        }


        [HttpPost]
        [Route("/products")]
        public async Task PostProducts(Product product)
        {
            _db.products.Add(product);
            await _db.SaveChangesAsync();
            var p=JsonSerializer.Serialize(product);
           await _rabbitMqUtil.publishMessageQueue("inventory.product", p);
        }

       
       

    }
}
