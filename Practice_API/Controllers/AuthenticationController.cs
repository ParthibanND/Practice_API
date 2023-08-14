using BussinessLayer.Repository;
using Data.Model.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authentication;
        public AuthenticationController(IAuthentication authentication) 
        {
            _authentication = authentication;
        }
        [HttpGet]
        public IActionResult Authenticator(string name, string email)
        {
            var result = _authentication.Authenticater(name, email);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }

       
    }
}
