

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RoundingPortal_API.Data;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;
using System.Security.Claims;

namespace RoundingPortal_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RoundingContext _roundingContext;
        public UserRepository(RoundingContext roundingContext)
        {
            _roundingContext = roundingContext;   
        }


        public async Task AddUserAsync(User user)
        {
            await _roundingContext.Users.AddAsync(user);
            await _roundingContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _roundingContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            List<User> users = await GetAllUsersAsync();
            User user = users.Where(e => e.Email == email).FirstOrDefault();
            return user;
        }

        public async Task<User> GetUserByClaimsAsync(ClaimsPrincipal User)
        {
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
            User user = await GetUserByEmailAsync(User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Value);
            return user;
        }
    }
}
