using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Orders;

namespace PetShop.Application.Services.Impelemntaions
{
    public class OrderDetailServices(IOrderDetailRepository repository) : IOrderDetailServises
    {
        public async Task Add(OrderDetail order)
        {
            await repository.Add(order);
        }

        public async Task Delete(OrderDetail order)
        {
            await repository.Delete(order);
        }

        public async Task<OrderDetail> GeById(int id)
        {
            return await repository.GeById(id);
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<List<OrderDetail>> GetByOrderId(int id)
        {
            return await repository.GetByOrderId(id);
        }

        public async Task<OrderDetail> GetByProdcutIdANDOrderId(int productId, int orederId)
        {
            return await repository.GetByProdcutIdANDOrderId(productId, orederId);
        }

        public async Task<OrderDetail> GetByProdcutIdANDUserId(int productId, int userId)
        {
            return await repository.GetByProdcutIdANDUserId(productId, userId); ;
        }

        public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }

        public Task<int> SumAmountByOrderId(int orderId)
        {
            return repository.SumAmountByOrderId(orderId);
        }
    }
}