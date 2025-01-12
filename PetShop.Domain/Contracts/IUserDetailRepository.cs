using PetShop.Domain.Models.Users;

namespace PetShop.Domain.Contracts
{
    public interface IUserDetailRepository
    {
        Task<User_Detail> GetByUserId(int userId);

        Task Update(User_Detail user_Detail);

        Task Add(User_Detail user_Detail);

        Task Save();
    }
}