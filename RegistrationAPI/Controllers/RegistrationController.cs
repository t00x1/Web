using DomainGeneral.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
       
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(UserDTO user)
        {
            return Ok();
        }
      
    }
}
