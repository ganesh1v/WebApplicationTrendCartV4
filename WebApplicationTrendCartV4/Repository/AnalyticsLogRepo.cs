using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;

namespace WebApplicationTrendCartV4.Repository
{
    public class AnalyticsLogRepo : IRepo<AnalyticsLog>
    {
        private readonly TrendCartContext _context;

        public AnalyticsLogRepo(TrendCartContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<AnalyticsLog>> GetAll()
        {
            return await _context.AnalyticsLogs.ToListAsync();
        }

        public async Task<AnalyticsLog> GetById(int id)
        {
            return await _context.AnalyticsLogs.FindAsync(id);
        }
        public async Task Add(AnalyticsLog analyticslog)
        {
            await _context.AnalyticsLogs.AddAsync(analyticslog);
            await _context.SaveChangesAsync();
        }
        public async Task Update(AnalyticsLog analyticslog)
        {
            _context.AnalyticsLogs.Update(analyticslog);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var analyticslog = await _context.AnalyticsLogs.FindAsync(id);
            if (analyticslog != null)
            {
                _context.AnalyticsLogs.Remove(analyticslog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
