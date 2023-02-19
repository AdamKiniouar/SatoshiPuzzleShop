using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;
using System.Net;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext shopOnlineDbContext;

        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.shopOnlineDbContext = shopOnlineDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await shopOnlineDbContext.ProductCategories.ToListAsync();
           
            return categories; 
        
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await shopOnlineDbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await shopOnlineDbContext.Products
                                     .Include(p => p.ProductCategory).ToListAsync();

            return products;
        
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            var products = await shopOnlineDbContext.Products
                                     .Include(p => p.ProductCategory)
                                     .Where(p => p.CategoryId == id).ToListAsync();
            return products;
        }

        public async Task<HttpResponseMessage> ActivateProductById(int id)
        {
            var product = await shopOnlineDbContext.Products
                                     .Where(p => p.Id == id).FirstOrDefaultAsync();

            if (product != null)
            {
                product.IsActive = true;
                await shopOnlineDbContext.SaveChangesAsync();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"Product with id {id} not found")
                };
            }

        }

        public async Task<HttpResponseMessage> DeActivateProductById(int id)
        {
            var product = await shopOnlineDbContext.Products
                                     .Where(p => p.Id == id).FirstOrDefaultAsync();

            if (product != null)
            {
                product.IsActive = false;
                await shopOnlineDbContext.SaveChangesAsync();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"Product with id {id} not found")
                };
            }
        }
    }
}
