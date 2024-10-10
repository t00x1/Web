using Microsoft.AspNetCore.Mvc;
using Registration.Domain.Interfaces.Service;
using DomainGeneral.ModelsDTO;
using DataAccess.ModelsDB;

namespace RegistrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("test")]
        public async Task<IActionResult> rer(string id)
        {
            return Ok();
        }
        
            [HttpPost("upload")]
        public async Task<IActionResult> CreateUser(UserDTO userDto)
        {
            
           

            
            await _userService.Create(userDto);

            return Ok();
        }
    }
}
