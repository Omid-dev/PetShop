using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;

namespace PetShop.Application.Services.Impelemntaions
{
    public class CommentServices(ICommentRepository repository) : ICommentServices
    {
        public async Task Add(Comment comment)
        {
            await repository.Add(comment);
        }

        public async Task<List<Comment>> GetByProductId(int id)
        {
            return await repository.GetByProductId(id);
        }

        public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }
    }
}