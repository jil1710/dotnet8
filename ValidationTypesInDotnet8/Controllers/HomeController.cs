using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ValidationTypesInDotnet8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(user);
        }
    }
}
