using Api.Data;
using Api.Data.Dtos.EstablishmentDtos;
using Api.Models;
using Api.Models.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstablishmentController : ControllerBase
    {
        private readonly ICoreRepository _repo;
        private readonly IMapper _mapper;
        public EstablishmentController(ICoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] CreateEstablishmentDto dto)
        {
            try
            {
                var establishment = _mapper.Map<Establishment>(dto);

                _repo.Add(establishment);
                await _repo.SaveChangeAsync();
                return CreatedAtAction(nameof(FindOneById), new { id = establishment.Id }, establishment);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult FindOneById(int id)
        {
            var data = GetEstablishment(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IEnumerable<Establishment>> FindAll([FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            IEnumerable<Establishment> establishments = await _repo.FindAllEstablishments(offset, limit);
            return _mapper.Map<List<Establishment>>(establishments);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try
            {
                var data = GetEstablishment(id);
                if (data == null) return NotFound();
                _repo.Delete(data);
                await _repo.SaveChangeAsync();
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
            var establishment = GetEstablishment(id);
            if (establishment == null) return NotFound();
            _mapper.Map(dto, establishment);
            await _repo.SaveChangeAsync();
            return NoContent();
        }


        private async Task<Establishment?> GetEstablishment(int id) {
            try
            {
                return await _repo.FindEstablishmentById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        

    }
}
