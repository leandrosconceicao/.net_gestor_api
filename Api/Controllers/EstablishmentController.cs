using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.EstablishmentDtos;
using Gestor.Repository.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstablishmentController : ControllerBase
    {
        private readonly IEstablishmentRepository _repo;
        private readonly IMapper _mapper;
        public EstablishmentController(IEstablishmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] CreateEstablishmentDto dto)
        {
            try
            {
                var newData = _mapper.Map<Establishment>(dto);
                var newInsertedId = await _repo.AddEstablishmentAsync(newData);
                var createdData = await _repo.FindEstablishmentById(newInsertedId);
                return CreatedAtAction(nameof(FindOneById), new { id = newInsertedId }, _mapper.Map<ReadEstablishmentDto>(createdData));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id)
        {
            var data = await _repo.FindEstablishmentById(id);
            if (data == null) return NotFound();
            return Ok(_mapper.Map<ReadEstablishmentDto>(data));
        }

        [HttpGet]
        public async Task<IEnumerable<ReadEstablishmentDto>> FindAll([FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            IEnumerable<Establishment> establishments = await _repo.FindEstablishmentAsync(offset, limit);
            return _mapper.Map<List<ReadEstablishmentDto>>(establishments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _repo.DeleteEstablishmentAsync(id);
                if (!data)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdateEstablishmentDto dto)
        {
            var establishment = await _repo.FindEstablishmentById(id);
            if (establishment == null) return NotFound();
            var updated = _mapper.Map(dto, establishment);
            var rowsAffected = await _repo.UpdateEstablishmentAsync(id, updated);
            return NoContent();
        }
    }
}
