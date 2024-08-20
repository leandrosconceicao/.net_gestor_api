using AutoMapper;
using Gestor.Domain.Entities;
using Gestor.Helpers.Models.AccountDtos;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class AccountController(IAccountRepository repo, IMapper mapper) : ControllerBase
    {

        private readonly IAccountRepository _coreRepo = repo;

        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] CreateAccountDto dto)
        {
            try
            {
                var account = _mapper.Map<Account>(dto);
                _coreRepo.Add(account);
                await _coreRepo.SaveChangeAsync();
                return CreatedAtAction(nameof(FindOneById), new {id = account.Id}, account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id)
        {
            try
            {
                var query = await GetAccountById(id);
                return query == null ? NotFound() : Ok(_mapper.Map<ReadAccountDto>(query));
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindAll(
            [FromQuery(Name = "branch_code")] int establishmentId,
            [FromHeader] int offset = 0,
            [FromHeader] int limit = 50
        )
        {
            try
            {
                var query = await _coreRepo.FindAll(establishmentId, offset, limit);
                return Ok(_mapper.Map<IEnumerable<ReadAccountDto>>(query));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id,[FromBody] JsonPatchDocument<Account> document) {
            if (document == null) return BadRequest();
            var account = await GetAccountById(id);
            if (account == null) return NotFound();
            document.ApplyTo(account);
            if (!TryValidateModel(account)) {
                return BadRequest(ModelState);
            }
            await _coreRepo.SaveChangeAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var query = await GetAccountById(id);
                if (query == null) return NotFound();
                bool isDeleted = await _coreRepo.Delete(query.Id);
                if (!isDeleted) {
                    return BadRequest("Nenhum dado foi excluido");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<Account?> GetAccountById(int id)
        {
            return await _coreRepo.FindById(id);
        }

    }
}