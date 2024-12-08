using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;

namespace WebApplicationTrendCartV4.Repository
{
    public class ShoppingCartRepo : IRepo<ShoppingCart>
    {
        private readonly TrendCartContext _context;

        public ShoppingCartRepo(TrendCartContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<ShoppingCart>> GetAll()
        {
            return await _context.ShoppingCarts.ToListAsync();
        }
        public async Task<ShoppingCart> GetById(int id)
        {
            return await _context.ShoppingCarts.FindAsync(id);
        }
        public async Task Add(ShoppingCart shoppingcart)
        {
            await _context.ShoppingCarts.AddAsync(shoppingcart);
            await _context.SaveChangesAsync();
        }
        public async Task Update(ShoppingCart shoppingcart)
        {
            _context.ShoppingCarts.Update(shoppingcart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var shoppingcart = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingcart != null)
            {
                _context.ShoppingCarts.Remove(shoppingcart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
