using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Orders;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class OrderRepository(PetShopContext _context) : IOrderRepository
    {
        public async Task Add(Order order)
        {
            _context.Order.Add(order);
        }

        public async Task<Order> GeById(int id)
        {
            return await _context.Order.Include(o => o.User).Include(o => o.OrderDetails)
                  .SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> GetByUserId(int id)
        {
            return await _context.Order.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                   .Where(u => u.User.Id == id
                 && !u.IsFinally && !u.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GettAll()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _context.Order.Update(order);
        }
    }
}