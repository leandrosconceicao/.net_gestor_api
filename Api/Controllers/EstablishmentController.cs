using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;
using Gestor.Repository.Implementations;
using Microsoft.AspNetCore.Mvc;
using Gestor.Domain.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstablishmentController(IEstablishmentRepository repo, IEstablishmentHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] EstablishmentDto.CreateEstablishment dto)
        {
            try
            {
                var newData = handler.Create(dto);
                var newInsertedId = await repo.AddEstablishmentAsync(newData);
                var createdData = await repo.FindEstablishmentById(newInsertedId);
                return CreatedAtAction(nameof(FindOneById), new { id = newInsertedId }, handler.Read(createdData));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id)
        {
            try
            {
                var data = await repo.FindEstablishmentById(id);
                if (data == null) return NotFound();
                return Ok(handler.Read(data));
            }
            catch (Exception ex) {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            try
            {
                IEnumerable<Establishment> establishments = await repo.FindEstablishmentAsync(offset, limit);
                return Ok(handler.Read(establishments));
            }
            catch (Exception ex) {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await repo.DeleteEstablishmentAsync(id);
                if (!data)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] EstablishmentDto.UpdateEstablishment dto)
        {
            try
            {
                var establishment = await repo.FindEstablishmentById(id);
                if (establishment == null) return NotFound();
                var updated = handler.Update(dto, establishment);
                var rowsAffected = await repo.UpdateEstablishmentAsync(id, updated);
                return NoContent();
            }
            catch (Exception ex) {
                return Problem(ex.Message);
            }
        }
    }
}
