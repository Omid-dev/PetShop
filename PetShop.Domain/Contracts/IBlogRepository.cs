using PetShop.Domain.Models.Blog.Group;

namespace PetShop.Domain.Contracts
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAll();

        Task<Blog> GetById(int id);

        Task<List<Blog>> GetByGroupId(int id);

        Task SaveAsync();
    }
}