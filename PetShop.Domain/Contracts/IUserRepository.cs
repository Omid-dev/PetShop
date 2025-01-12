using PetShop.Domain.Models.Users;

namespace PetShop.Domain.Contracts
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);

        Task<User> GetByIdAsync(int id);

        Task<int> GetIdByName(string name);

        User GetByEamil(string email);

        Task<bool> EmailIsExist(string email);

        Task<bool> PhoneNumberIsExist(string phoneNumber);

        Task Update(User user);

        Task SaveAsync();
    }
}