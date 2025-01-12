using PetShop.Application.Services.Interfaces;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Users;
using PetShop.Domain.ViewModels;

namespace PetShop.Application.Services.Impelemntaions
{
    public class UserDetailServices(IUserDetailRepository repository, IUserRepository
         userRepository) : IUserDetailServices

    {
        public async Task Add(User_Detail user_Detail)
        {
            await repository.Add(user_Detail);
        }

        public async Task<DetailUserViewModel> GetByUserId(int userId)
        {
            var userDetail = await repository.GetByUserId(userId);
            DetailUserViewModel detailUserViewModel = new DetailUserViewModel()
            {
                Email = userDetail.User.Email,
                Name = userDetail.User.Name,
                Family = userDetail.User.Family,
                PhoneNumber = userDetail.User.PhoneNumber,
                ApartmentName = userDetail.ApartmentName,
                City = userDetail.City,
                State = userDetail.State,
                Street = userDetail.Street,
                UserId = userDetail.UserId,
                Zip_Code = userDetail.Zip_Code,
                IdDetail = userDetail.Id,
            };

            return detailUserViewModel;
        }

        public async Task<User_Detail> GetUserDetailByUserId(int userId)
        {
            return await repository.GetByUserId(userId);
        }

        public async Task Save()
        {
            await repository.Save();
        }

        public async Task Update(User_Detail user_Detail)
        {
            await repository.Update(user_Detail);
        }

        public async Task UpdateWithViewModel(DetailUserViewModel viewModel)
        {
            var userDetail = await repository.GetByUserId(viewModel.UserId);
            if (userDetail != null)
            {
                userDetail.Id = userDetail.Id;
                userDetail.Street = viewModel.Street;
                userDetail.State = viewModel.State;
                userDetail.City = viewModel.City;
                userDetail.ApartmentName = viewModel.ApartmentName;
                userDetail.ModifiedDate = DateTime.Now;

                await repository.Update(userDetail);
            }
            else
            {
                userDetail = new User_Detail
                {
                    Zip_Code = viewModel.Zip_Code,
                    CreateDate = DateTime.Now,
                    UserId = viewModel.UserId,
                    Street = viewModel.Street,
                    State = viewModel.State,
                    City = viewModel.City,
                    ApartmentName = viewModel.ApartmentName,
                    ModifiedDate = DateTime.Now,
                };

                await repository.Add(userDetail);
            }

            await repository.Save();
        }
    }
}