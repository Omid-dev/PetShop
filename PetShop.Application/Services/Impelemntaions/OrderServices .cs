using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Orders;

namespace PetShop.Application.Services.Impelemntaions
{
    public class OrderServices(IOrderRepository repository) : IOrderServises
    {
        public async Task Add(Order order)
        {
            await repository.Add(order);
        }

        public async Task<Order> GeById(int id)
        {
            return await repository.GeById(id);
        }

        public async Task<Order> GetByUserId(int id)
        {
            return await repository.GetByUserId(id);
        }

        public async Task<List<Order>> GettAll()
        {
            return await repository.GettAll();
        }

        public async Task SaveAsync()
        {
            await repository.SaveAsync();
        }

        public async Task Update(Order order)
        {
            await repository.Update(order);
        }
    }
}