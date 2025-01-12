using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Blog.Group;

namespace PetShop.Application.Services.Impelemntaions
{
    public class BlogServices(IBlogRepository repository) : IBlogServises
    {
        public async Task<Blog> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<Blog>> GetAll()
        {
            return await repository.GetAll();
        }

        public Task<List<Blog>> GetByGroupId(int id)
        {
            return repository.GetByGroupId(id);
        }

        public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }
    }
}