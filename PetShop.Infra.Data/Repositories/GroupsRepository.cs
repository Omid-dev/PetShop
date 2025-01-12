using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Products;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly PetShopContext _context;

        public GroupsRepository(PetShopContext context)
        {
            this._context = context;
        }

        public Groups GetGroupById(int? id)
        {
            return _context.Group.Single(g => g.Id == id);
        }

        public List<Groups> GettAll()
        {
            return _context.Group.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}