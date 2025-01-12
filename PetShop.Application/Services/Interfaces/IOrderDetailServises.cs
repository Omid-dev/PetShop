using PetShop.Domain.Models.Orders;

namespace PetShop.Application.Services.Interfaces
{
    public interface IOrderDetailServises
    {
        Task<List<OrderDetail>> GetAll();

        Task<List<OrderDetail>> GetByOrderId(int id);

        Task<OrderDetail> GetByProdcutIdANDOrderId(int productId, int orederId);

        Task<OrderDetail> GetByProdcutIdANDUserId(int productId, int userId);

        Task<OrderDetail> GeById(int id);

        Task<int> SumAmountByOrderId(int orderId);

        Task Add(OrderDetail order);

        Task Delete(OrderDetail order);

        Task SaveAsync();
    }
}