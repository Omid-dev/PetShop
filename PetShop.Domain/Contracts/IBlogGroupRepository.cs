using PetShop.Domain.Models.Blog.Group;

namespace PetShop.Domain.Contracts
{
    public interface IBlogGroupRepository
    {
        Task<List<BlogGroup>> GettAll();

        Task<BlogGroup> GetById(int? id);

        Task<string> GetTitle(int id);

        Task SaveAsync();
    }
}