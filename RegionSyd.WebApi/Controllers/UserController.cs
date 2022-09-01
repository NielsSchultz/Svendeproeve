using Microsoft.AspNetCore.Mvc;
using RegionSyd.Common.DTOs;
using RegionSyd.WebApi.Services.Interfaces;

namespace RegionSyd.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        [HttpGet]
        public async Task<List<UserDTO>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUser(int id)
        {
            return await _userService.GetUser(id);
        }
        [HttpGet("ByPatient/{id}")]
        public async Task<UserDTO> GetUserByPatientID(int id)
        {
            return await _userService.GetUserByPatientID(id);
        }

        [HttpPost]
        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            return await _userService.CreateUser(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
        [HttpPut]
        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            return await _userService.UpdateUser(userDTO);
        }
    }
}
