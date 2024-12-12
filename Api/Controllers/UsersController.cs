using Gestor.Domain.Dtos;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Gestor.Domain.Interfaces;
using System.Data.Common;
using System.Data;
using Gestor.Domain.Exceptions;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUserRepository repo, IUserHandler userHandler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] UserDto.CreateUser dto)
        {
            try
            {
                var user = userHandler.Create(dto);

                var idCreated = await repo.AddUserAsync(user);
                return CreatedAtAction(nameof(FindOneById), new { id = idCreated }, user);
            }
            catch (Exception ex) {
                if (ex.Message.Contains("Duplicate")) throw new DuplicateDataError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id)
        {
            var data = await repo.FindUserByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(userHandler.Read(data));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] int establishmentId, [FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            try
            {
                var users = await repo.FindUsersAsync(establishmentId, offset, limit);
                return Ok(userHandler.Read(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                var isUserDeleted = await repo.DeleteUserAsync(id);
                if (!isUserDeleted) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
