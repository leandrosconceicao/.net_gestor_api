using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductRepository repository, IMapper mapper) : ControllerBase
    {
        private readonly IProductRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int establishmentId, [FromQuery] int limit = 50, [FromQuery] int offset = 0)
        {
            try
            {
                var products = await _repository.FindProductsAsync(establishmentId, limit, offset);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindProductById(int id)
        {
            try
            {
                var product = await _repository.FindProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto.CreateProduct dto)
        {
            try
            {
                var newData = _mapper.Map<Product>(dto);
                int newInsertedId = await _repository.AddProductAsync(newData);
                return CreatedAtAction(nameof(FindProductById), new { Id = newInsertedId }, newData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDto.UpdateProduct dto)
        {
            try
            {
                var product = _repository.FindProductById(id);
                if (product == null)
                    return NotFound();
                var updatedProduct = await _mapper.Map(dto, product);
                if (updatedProduct == null)
                {
                    return BadRequest();
                }
                _repository.UpdateProductAsync(updatedProduct);
                return Ok(product);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _repository.FindProductById(id);
                if (product == null)
                    return NotFound();
                bool isDeleted = await _repository.DeleteProductAsync(product);
                if (!isDeleted) {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
