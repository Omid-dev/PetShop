using PetShop.Domain.Models.Orders;

namespace PetShop.Domain.Contracts
{
    public interface IOrderRepository
    {
        Task<List<Order>> GettAll();

        Task Update(Order order);

        Task<Order> GeById(int id);

        Task<Order> GetByUserId(int id);

        Task Add(Order order);

        Task SaveAsync();
    }
}