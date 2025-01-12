using PetShop.Application.Services.Interfaces;
using PetShop.Application.Utility;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Users;
using PetShop.Domain.ViewModels;

namespace PetShop.Application.Services.Impelemntaions
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository repository;

        public UserServices(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> EmailIsExist(string email)
        {
            if (await repository.EmailIsExist(email))
                return true;
            return false;
        }

        public User GetByEmail(string email)
        {
            return repository.GetByEamil(email);
        }

        public Task<User> GetByIdAsync(int id)
        {
            return repository.GetByIdAsync(id);
        }

        public Task<int> GetIdByName(string name)
        {
            return repository.GetIdByName(name);
        }

        public async Task<bool> InseretAsync(RegisterViewModel registerViewModel)
        {
            User user = new User()
            {
                Name = registerViewModel.Name,
                Family = registerViewModel.Family,
                PhoneNumber = registerViewModel.PhoneNumber,
                Email = registerViewModel.Email,
                Password = HasherPassword.HashPassword(registerViewModel.Password),
                CreateDate = DateTime.Now,
                IsAdmin = false,
                IsDeleted = false,
            };
            await repository.InsertAsync(user);
            await repository.SaveAsync();
            return true;
        }

        public async Task<bool> PhoneNumberIsExist(string phoneNumber)
        {
            if (await repository.EmailIsExist(phoneNumber))
                return true;
            return false;
        }

        public async Task Save()
        {
            await repository.SaveAsync();
        }

        public async Task Update(User user)
        {
            await repository.Update(user);
        }

        public async Task UpdateWithViewModel(DetailUserViewModel viewModel)
        {
            var user = await repository.GetByIdAsync(viewModel.UserId);
            user.Id = viewModel.UserId;
            user.CreateDate = user.CreateDate;
            user.IsAdmin = user.IsAdmin;
            user.Name = viewModel.Name;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.Family = viewModel.Family;
            user.Email = viewModel.Email;
            user.ModifiedDate = DateTime.Now;
            await repository.Update(user);
        }
    }
}