using Microsoft.EntityFrameworkCore;
using WebApplicationTrendCartV4.Models;

namespace WebApplicationTrendCartV4.Repository
{
    public class UserProfileRepo : IRepo<UserProfile>
    {
        private readonly TrendCartContext _context;

        public UserProfileRepo(TrendCartContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _context.UserProfiles.ToListAsync();
        }
        public async Task<UserProfile> GetById(int id)
        {
            return await _context.UserProfiles.FindAsync(id);
        }
        public async Task Add(UserProfile userprofile)
        {
            await _context.UserProfiles.AddAsync(userprofile);
            await _context.SaveChangesAsync();
        }
        public async Task Update(UserProfile userprofile)
        {
            _context.UserProfiles.Update(userprofile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var userprofile = await _context.UserProfiles.FindAsync(id);
            if (userprofile != null)
            {
                _context.UserProfiles.Remove(userprofile);
                await _context.SaveChangesAsync();
            }

        }
    }
}
