
using Gestor.Domain.Dtos;
using Gestor.Domain.Interfaces;
using Gestor.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthenticationRepository repo, IHubContext<ChatHub, IChatHub> hub) : ControllerBase
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

        [HttpPost("/post_message")]
        public IActionResult PostMessage([FromBody] MessageDto dto)
        {
            hub.Clients.All.NotifyUsers(dto);
            return NoContent();
        }

    }
}
