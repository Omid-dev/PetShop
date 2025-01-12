using Microsoft.EntityFrameworkCore;
using PetShop.Domain.Contracts;
using PetShop.Domain.Models.Users;
using PetShop.Infra.Data.Context;

namespace PetShop.Infra.Data.Repositories
{
    public class UserDatailRepository(PetShopContext _context) : IUserDetailRepository
    {
        public async Task Add(User_Detail user_Detail)
        {
            await _context.User_Detail.AddAsync(user_Detail);
        }

        public async Task<User_Detail> GetByUserId(int userId)
        {
            return await _context.User_Detail.Include(ud => ud.User).SingleOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(User_Detail user_Detail)
        {
            _context.Update(user_Detail);
        }
    }
}