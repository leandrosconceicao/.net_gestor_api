using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _coreRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _coreRepository = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] UserDto.Create dto)
        {
            try
            {
                User? user = _mapper.Map<User>(dto);

                var idCreated = await _coreRepository.AddUserAsync(user);
                return CreatedAtAction(nameof(FindOneById), new { id = idCreated }, user);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id)
        {
            var data = await _coreRepository.FindUserByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(_mapper.Map<UserDto.Read>(data));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] int establishmentId, [FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            try
            {
                var users = await _coreRepository.FindUsersAsync(establishmentId, offset, limit);
                return Ok(_mapper.Map<IEnumerable<UserDto.Read>>(users));
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
                var isUserDeleted = await _coreRepository.DeleteUserAsync(id);
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
