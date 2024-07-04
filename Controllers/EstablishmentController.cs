using Api.Data;
using Api.Data.Dtos;
using Api.Models;
using Api.Models.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstablishmentController : ControllerBase
    {
        private EstablishmentContext _context;
        private IMapper _mapper;
        public EstablishmentController(EstablishmentContext ctx, IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddNew([FromBody] CreateEstablishmentDto dto)
        {
            var establishment = _mapper.Map<Establishment>(dto);

            _context.Establishments.Add(establishment);
            _context.SaveChanges();
            return CreatedAtAction(nameof(FindOneById),new {id = establishment.Id}, establishment );
        }

        [HttpGet("{id}")]
        public IActionResult FindOneById(int id)
        {
            var data = GetEstablishment(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpGet]
        public IEnumerable<Establishment> FindAll([FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            return _mapper.Map<List<Establishment>>(_context.Establishments.Skip(offset).Take(limit));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var data = GetEstablishment(id);
            if (data == null) return NotFound();
            _context.Establishments.Remove(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, [FromBody] UpdateEstablishmentDto dto)
        {
            var establishment = GetEstablishment(id);
            if (establishment == null) return NotFound();
            _mapper.Map(dto, establishment);
            _context.SaveChanges();
            return NoContent();
        }


        private Establishment? GetEstablishment(int id) {
            return _context.Establishments.FirstOrDefault(e => e.Id == id);
        }

        

    }
}
