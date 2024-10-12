
using Gestor.Domain.Dtos;
using Gestor.Domain.Interfaces;
using Gestor.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthenticationRepository repo) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserDto.Login dto)
        {
            try
            {
                var user = repo.AuthUser(dto.Email, Crypto.GetHashedPassword(dto.Password));
                if (user == null)
                {
                    return Unauthorized();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
