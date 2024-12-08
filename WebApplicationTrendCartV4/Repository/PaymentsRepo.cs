using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;

namespace WebApplicationTrendCartV4.Repository
{
    public class PaymentsRepo : IRepo<Payment>
    {
        private readonly TrendCartContext _context;

        public PaymentsRepo(TrendCartContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Payment>> GetAll()

        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment> GetById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }
        public async Task Add(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
