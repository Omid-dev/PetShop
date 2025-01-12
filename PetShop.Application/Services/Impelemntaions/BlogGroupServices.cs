using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Blog.Group;

namespace PetShop.Application.Services.Impelemntaions
{
    public class BlogGroupServices(IBlogGroupRepository repository) : IBlogGroupServices
    {
        public async Task<BlogGroup> GetById(int? id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<BlogGroup>> GettAll()
        {
            return await repository.GettAll();
        }

        public async Task<string> GetTitle(int id)
        {
            return await repository.GetTitle(id);
        }

        public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }
    }
}