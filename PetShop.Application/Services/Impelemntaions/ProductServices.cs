using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;
using PetShop.Domain.ViewModels;

namespace PetShop.Application.Services.Impelemntaions
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;

        public ProductServices(IProductRepository repository)
        {
            this._repository = repository;
        }

        public List<ShowProductViewModel> GetAll()
        {
            return _repository.GetAll()?.Where(p => p.IsDeleted == false).Select(p => new ShowProductViewModel()
            {
                Id = p.Id,
                GroupId = p.GroupId,
                ImageName = p.ImageName,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            })?.ToList();
        }

        public Product GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Product> GetPopular(int count)
        {
            return _repository.GetPopular(count);
        }

        public async Task Save()
        {
            await _repository.Save();
        }

        public async Task Update(Product product)
        {
            await _repository.Update(product);
        }

        List<Product> IProductServices.GetbyGroupId(int groupId)
        {
            return _repository.GetbyGroupId(groupId).Where(p => p.IsDeleted == false).ToList();
        }
    }
}