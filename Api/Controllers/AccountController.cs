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

    public class AccountController : ControllerBase
    {

        private readonly IAccountRepository _coreRepo;

        private readonly IMapper _mapper;

        public AccountController(IAccountRepository repo, IMapper mapper)
        {
            _coreRepo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody] AccountDto dto)
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
            var query = await GetAccountById(id);
            return query == null ? NotFound() : Ok(_mapper.Map<AccountDto>(query));
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
                return Ok(_mapper.Map<IEnumerable<AccountDto>>(query));
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
                _coreRepo.Delete(query);
                await _coreRepo.SaveChangeAsync();
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