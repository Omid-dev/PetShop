using PetShop.Domain.Models.Orders;

namespace PetShop.Application.Services.Interfaces
{
    public interface IOrderServises
    {
        Task<List<Order>> GettAll();

        Task Update(Order order);

        Task<Order> GeById(int id);

        Task<Order> GetByUserId(int id);

        Task Add(Order order);

        Task SaveAsync();
    }
}