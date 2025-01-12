using PetShop.Domain.Models.Users;
using PetShop.Domain.ViewModels;

namespace PetShop.Application.Services.Interfaces
{
    public interface IUserServices
    {
        Task<User> GetByIdAsync(int id);

        Task<bool> InseretAsync(RegisterViewModel registerViewModel);

        Task<bool> EmailIsExist(string email);

        User GetByEmail(string email);

        Task<int> GetIdByName(string name);

        Task<bool> PhoneNumberIsExist(string phoneNumber);

        Task UpdateWithViewModel(DetailUserViewModel viewModel);

        Task Update(User user);

        Task Save();
    }
}