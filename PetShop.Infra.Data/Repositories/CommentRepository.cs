using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class CommentRepository(PetShopContext _context) : ICommentRepository
    {
        public async Task Add(Comment comment)
        {
            _context.Comment.Add(comment);
        }

        public async Task<List<Comment>> GetByProductId(int id)
        {
            return await _context.Comment.Where(c => c.ProductId == id)
                .OrderByDescending(c => c.CreateDate).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}