using Gestor.Domain.Entities;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/product/extras")]
    [ApiController]
    public class ProductExtrasController : ControllerBase
    {
        private readonly IProductExtraRepository _repository;

        public ProductExtrasController(IProductExtraRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ProductExtrasController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int establishmentId, [FromHeader] int offset = 0, int limit = 50)
        {
            try
            {
                var productExtras = await _repository.FindProductExtrasAsync(establishmentId, limit, offset);
                return Ok(productExtras);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var productExtra = await _repository.FindProductExtraById(id);
                if (productExtra == null)
                {
                    return NotFound();
                }
                return Ok(productExtra);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductExtrasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductExtra productExtra)
        {
            try
            {
                var newProductId = await _repository.AddProductExtraAsync(productExtra);
                var newProductExtra = await _repository.FindProductExtraById(newProductId);
                return CreatedAtAction(nameof(GetById), new { Id = newProductId}, newProductExtra);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// PUT api/<ProductExtrasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<ProductExtrasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
