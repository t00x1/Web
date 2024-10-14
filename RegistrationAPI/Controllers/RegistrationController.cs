using Microsoft.AspNetCore.Mvc;
using Registration.Domain.Interfaces.Service;
using DomainGeneral.ModelsDTO;
using DataAccess.ModelsDB;
using InfrastructureGeneral.Settings;


namespace RegistrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IUserService _userService;
    
        public  RegistrationController(IUserService userService)
        {
         

                _userService = userService;
               
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticateRequest model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromBody] UserDTO userDto)
        {
            try
            {
               await _userService.Create(userDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new CustomException(ex));
            }
        }
    }
}
