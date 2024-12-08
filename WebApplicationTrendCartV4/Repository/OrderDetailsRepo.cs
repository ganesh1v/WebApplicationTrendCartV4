using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;

namespace WebApplicationTrendCartV4.Repository
{
    public class OrderDetailsRepo : IRepo<OrderDetail>
    {
        private readonly TrendCartContext _context;

        public OrderDetailsRepo(TrendCartContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<OrderDetail>> GetAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public async Task<OrderDetail> GetById(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }
        public async Task Add(OrderDetail orderdetail)
        {
            await _context.OrderDetails.AddAsync(orderdetail);
            await _context.SaveChangesAsync();
        }
        public async Task Update(OrderDetail orderdetail)
        {
            _context.OrderDetails.Update(orderdetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)

        {
            var orderdetail = await _context.OrderDetails.FindAsync(id);
            if (orderdetail != null)
            {
                _context.OrderDetails.Remove(orderdetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
