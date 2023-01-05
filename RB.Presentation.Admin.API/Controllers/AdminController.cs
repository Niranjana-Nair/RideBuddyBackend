using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTOModel;
using RB.Core.Application.Interface;

namespace RB.Presentation.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminLogin _adminLogin;
        public AdminController(IAdminLogin adminLogin)
        {
            _adminLogin = adminLogin;
        }

        [HttpPost]
        public IActionResult AdminLogin([FromForm]AdminLoginRequest login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            var response = _adminLogin.Login(login);
            
            return Ok(response);
        }
    }
}
