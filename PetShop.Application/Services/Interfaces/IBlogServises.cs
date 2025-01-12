using PetShop.Domain.Models.Blog.Group;

namespace PetShop.Application.Services.Interfaces
{
    public interface IBlogServises
    {
        Task<List<Blog>> GetAll();

        Task<Blog> GetById(int id);

        Task<List<Blog>> GetByGroupId(int id);

        Task SaveAsync();
    }
}