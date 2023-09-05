using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos;
using Services.Interfaces;

namespace H_M_4_Sep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository userRepository { get; set; }

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm] UserCreateDto UserDto, [FromForm] PasswordCreateDto password)
        {
            await userRepository.CreateAsync(UserDto, password);
            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromForm] Guid userId)
        {
            var res = await userRepository.DeleteAsync(userId);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] Guid userId,[FromForm]UserUpdateDto user)
        {
            var res = await userRepository.UpdateAsync(userId,user);
            return Ok(res);
        }
    }
}
