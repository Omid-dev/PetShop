using PetShop.Domain.Models.Products;

namespace PetShop.Domain.Contracts
{
    public interface IGroupsRepository
    {
        List<Groups> GettAll();

        Groups GetGroupById(int? id);

        void Save();
    }
}