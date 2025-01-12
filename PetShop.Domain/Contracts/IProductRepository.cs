using PetShop.Domain.Models.Products;

namespace PetShop.Domain.Contracts
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        List<Product> GetbyGroupId(int groupId);

        Product GetById(int id);

        List<Product> GetPopular(int count);

        Task Update(Product product);

        Task Save();
    }
}