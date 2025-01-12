using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Blog.Group;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class BlogGroupRepository(PetShopContext _context) : IBlogGroupRepository
    {
        public async Task<BlogGroup> GetById(int? id)
        {
            return await _context.BlogGroup.SingleOrDefaultAsync(bg => bg.Id == id);
        }

        public async Task<List<BlogGroup>> GettAll()
        {
            return await _context.BlogGroup.ToListAsync();
        }

        public async Task<string> GetTitle(int id)
        {
            return _context.BlogGroup.SingleOrDefault(bg => bg.Id == id).Title;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}