using PetShop.Domain.Models.Orders;

namespace PetShop.Domain.Contracts
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAll();

        Task<List<OrderDetail>> GetByOrderId(int id);

        Task<OrderDetail> GetByProdcutIdANDOrderId(int productId, int orderId);

        Task<OrderDetail> GetByProdcutIdANDUserId(int productId, int userId);

        Task<OrderDetail> GeById(int id);

        Task<int> SumAmountByOrderId(int orderId);

        Task Add(OrderDetail order);

        Task Delete(OrderDetail order);

        Task SaveAsync();
    }
}