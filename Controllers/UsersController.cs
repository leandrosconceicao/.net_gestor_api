using Api.Data;
using Api.Data.Dtos.UserDtos;
using Api.Models;
using Api.Models.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IMapper _mapper;
        public UsersController(ICoreRepository repo, IMapper mapper)
        {
            _coreRepository = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _coreRepository.Add(user);
            await _coreRepository.SaveChangeAsync();
            return CreatedAtAction(nameof(FindOneById),new {id = user.Id}, user );
        }

        [HttpGet("{id}")]
        public IActionResult FindOneById(int id)
        {
            var data = FindUserById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            try
            {
                IEnumerable<User> users = await _coreRepository.FindAllUsers(offset, limit);
                if (users == null) return Ok();
                return Ok(_mapper.Map<List<User>>(users));
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
                var data = await FindUserById(id);
                if (data == null) return NotFound();
                _coreRepository.Delete(data);
                await _coreRepository.SaveChangeAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                var establishment = await FindUserById(id);
                if (establishment == null) return NotFound();
                _mapper.Map(dto, establishment);
                await _coreRepository.SaveChangeAsync();
                return NoContent();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }


        private async Task<User?> FindUserById(int id) {
            return await _coreRepository.FindUserById(id);
        }

        

    }
}
