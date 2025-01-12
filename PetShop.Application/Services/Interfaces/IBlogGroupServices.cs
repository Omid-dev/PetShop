using PetShop.Domain.Models.Blog.Group;

namespace PetShop.Application.Services.Interfaces
{
    public interface IBlogGroupServices
    {
        Task<List<BlogGroup>> GettAll();

        Task<BlogGroup> GetById(int? id);

        Task<string> GetTitle(int id);

        Task SaveAsync();
    }
}