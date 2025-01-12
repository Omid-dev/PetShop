using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PetShopContext _context;

        public ProductRepository(PetShopContext context)
        {
            this._context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        public List<Product> GetbyGroupId(int groupId)
        {
            return _context.Product.Where(p => p.GroupId == groupId).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Product.Find(id);
        }

        public List<Product> GetPopular(int count)
        {
            return _context.Product.OrderByDescending(p => p.Visited).Take(count).ToList();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Update(product);
        }
    }
}