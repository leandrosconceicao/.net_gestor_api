using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos.UserDtos;
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
        public async Task<IActionResult> AddNew([FromBody] CreateUserDto dto)
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
            return Ok(_mapper.Map<ReadUserDto>(data));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] int establishmentId, [FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            try
            {
                var users = await _coreRepository.FindUsersAsync(establishmentId, offset, limit);
                return Ok(_mapper.Map<IEnumerable<ReadUserDto>>(users));
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

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateById(int id, [FromBody] UpdateUserDto dto)
        //{
        //    try
        //    {
        //        var user = await FindUserById(id);
        //        if (user == null) return NotFound();
        //        _mapper.Map(dto, user);
        //        await _coreRepository.SaveChangeAsync();
        //        return NoContent();
        //    }
        //    catch (Exception ex) { 
        //        return BadRequest(ex.Message);
        //    }
        //}      

    }
}
