using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoundingPortal_API.Interfaces;
using RoundingPortal_API.Models;

namespace RoundingPortal_API.Controllers
{
    [Authorize(Roles = "technical_assistant, developer")]
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            User found_user = await _userRepository.GetUserByEmailAsync(user.Email);

            if (found_user == null) {
                await _userRepository.AddUserAsync(user);
                found_user = await _userRepository.GetUserByEmailAsync(user.Email);
            }
            


            return Ok(found_user);
        }

        [HttpGet("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = await _userRepository.GetAllUsersAsync();

            return Ok(users);
        }
    }
}
