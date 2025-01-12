using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Blog.Group;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class BlogRepository(PetShopContext _context) : IBlogRepository
    {
        public async Task<Blog> GetById(int id)
        {
            return await _context.Blog.Include(b => b.User).Include(b => b.BlogGroup).
               Where(b => b.Id == id).SingleOrDefaultAsync();
        }

        public Task<List<Blog>> GetAll()
        {
            return _context.Blog.Include(b => b.BlogGroup).Include(b => b.User)
            .Where(b => !b.IsDeleted && !b.BlogGroup.IsDeleted).ToListAsync();
        }

        public async Task<List<Blog>> GetByGroupId(int id)
        {
            return await _context.Blog.Where(b => !b.IsDeleted && b.BlogGroup.Id == id && !b.BlogGroup.IsDeleted)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}