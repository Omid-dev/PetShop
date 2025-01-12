using PetShop.Domain.Models.Products;
using PetShop.Domain.ViewModels;

namespace PetShop.Application.Services.Impelemntaions
{
    public interface IProductServices
    {
        List<ShowProductViewModel> GetAll();

        List<Product> GetbyGroupId(int groupId);

        Product GetById(int id);

        List<Product> GetPopular(int count);

        Task Update(Product product);

        Task Save();
    }
}