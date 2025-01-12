using PetShop.Domain.Models.Products;

namespace PetShop.Application.Services.Interfaces
{
    public interface IGroupsServices
    {
        List<Groups> GettAll();

        Groups GetGroupById(int? id);
    }
}