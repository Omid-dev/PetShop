using PetShop.Domain.Models.Products;

namespace PetShop.Domain.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetByProductId(int id);

        Task Add(Comment comment);

        Task SaveAsync();
    }
}