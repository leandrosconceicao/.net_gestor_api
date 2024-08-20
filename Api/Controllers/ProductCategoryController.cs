using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Gestor.Repository.Interfaces;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.ProductDtos;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {

        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductCategoryController(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> NewCategory([FromBody] CreateProductCategoryDto dto)
        {
            try
            {
                var category = _mapper.Map<ProductCategory>(dto);
                await _repo.AddProductCategoryAsync(category);
                return CreatedAtAction(nameof(FindCategoryById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindAllCategories([FromQuery] int establishmentId, [FromHeader] int offset = 0, [FromHeader] int limit = 50)
        {
            try
            {
                var categories = await _repo.FindProductCategoriesAsync(establishmentId, limit, offset );
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> FindCategoryById(int id)
        {
            try
            {
                var category = await _repo.FindProductCategoryById(id);
                if (category == null) return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var isProductCategoryDeleted = await _repo.DeleteProductCategoryAsync(id);
                if (!isProductCategoryDeleted)
                {
                    return NotFound("Conta não foi localizada");
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