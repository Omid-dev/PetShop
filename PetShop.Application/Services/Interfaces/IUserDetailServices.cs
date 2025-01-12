using PetShop.Domain.Models.Users;
using PetShop.Domain.ViewModels;

namespace PetShop.Application.Services.Interfaces
{
    public interface IUserDetailServices
    {
        Task<DetailUserViewModel> GetByUserId(int userId);

        Task<User_Detail> GetUserDetailByUserId(int userId);

        Task Add(User_Detail user_Detail);

        Task UpdateWithViewModel(DetailUserViewModel viewModel);

        Task Update(User_Detail user_Detail);

        Task Save();
    }
}