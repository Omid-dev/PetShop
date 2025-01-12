using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Users;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetShopContext _context;

        public UserRepository(PetShopContext context)
        {
            this._context = context;
        }

        public async Task<bool> EmailIsExist(string email)
        {
            return await _context.User.AnyAsync(u => u.Email.Trim().ToLower() == email);
        }

        public User GetByEamil(string email)
        {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GetIdByName(string name)
        {
            return _context.User.SingleOrDefault(u => u.Name == name).Id;
        }

        public async Task InsertAsync(User user)
        {
            await _context.User.AddAsync(user);
        }

        public async Task<bool> PhoneNumberIsExist(string phoneNumber)
        {
            return await _context.User.AnyAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Update(user);
        }
    }
}