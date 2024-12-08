using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;

namespace WebApplicationTrendCartV4.Repository
{
    public class ProductsRepo : IRepo<Product>
    {
        private readonly TrendCartContext _context;

        public ProductsRepo(TrendCartContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task Add(Product product)
        {

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
