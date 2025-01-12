using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;

namespace PetShop.Application.Services.Impelemntaions
{
    public class GroupsServices : IGroupsServices
    {
        private readonly IGroupsRepository _repository;

        public GroupsServices(IGroupsRepository repository)
        {
            this._repository = repository;
        }

        public Groups GetGroupById(int? id)
        {
            return _repository.GetGroupById(id);
        }

        public List<Groups> GettAll()
        {
            return _repository.GettAll();
        }
    }
}