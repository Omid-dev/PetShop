using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Orders;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class OrderDetailRepository(PetShopContext _context,
        IOrderRepository orderRepository) : IOrderDetailRepository
    {
        public async Task Add(OrderDetail order)
        {
            _context.OrderDetail.Add(order);
        }

        public async Task Delete(OrderDetail order)
        {
            _context.OrderDetail.Remove(order);
        }

        public async Task<OrderDetail> GeById(int id)
        {
            return await _context.OrderDetail.Include(od => od.Order).ThenInclude(od => od.User)
                .SingleOrDefaultAsync(od => od.Id == id);
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            return await _context.OrderDetail.ToListAsync();
        }

        public async Task<List<OrderDetail>> GetByOrderId(int id)
        {
            return await _context.OrderDetail.Where(od => od.OrderId == id).ToListAsync();
        }

        public async Task<OrderDetail> GetByProdcutIdANDOrderId(int productId, int orderId)
        {
            return await _context.OrderDetail.SingleOrDefaultAsync(od => od.ProdcutId == productId
             && od.OrderId == orderId);
         
        }

        public async Task<OrderDetail> GetByProdcutIdANDUserId(int productId, int userId)
        {
            return await _context.OrderDetail.SingleOrDefaultAsync(od => od.ProdcutId == productId
           && od.Order.UserId == userId);
            
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> SumAmountByOrderId(int orderId)
        {
            var order = await orderRepository.GeById(orderId);
            return order.OrderDetails.Sum(od => od.Price * od.Count);
        }
    }
}