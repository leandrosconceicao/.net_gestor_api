using Gestor.Domain.Entities;
using Gestor.Domain.Dtos;
using Gestor.Repository.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Gestor.Domain.Interfaces;

namespace Api.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class AccountController(IAccountRepository repository, IAccountHandler accountHandler) : ControllerBase
    {

        [HttpPost]
        public IActionResult AddNew([FromBody] AccountDto.Create dto)
        {
            try
            {
                var account = accountHandler.Create(dto);
                repository.Add(account);
                return CreatedAtAction(nameof(FindOneById), new {id = account.Id}, account);
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
                var query = await GetAccountById(id);
                return query == null ? NotFound() : Ok(accountHandler.Read(query));
            }
            catch (Exception ex) {
                return Problem(ex.Message);
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
                var query = await repository.FindAll(establishmentId, offset, limit);
                return Ok(accountHandler.Read(query ?? []));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id,[FromBody] JsonPatchDocument<Account> document) {
            if (document == null) return Problem();
            var account = await GetAccountById(id);
            if (account == null) return NotFound();
            document.ApplyTo(account);
            if (!TryValidateModel(account)) {
                return BadRequest(ModelState);
            }
            await repository.SaveChangeAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var query = await GetAccountById(id);
                if (query == null) return NotFound();
                bool isDeleted = await repository.Delete(query.Id);
                if (!isDeleted) {
                    return Problem("Nenhum dado foi excluido");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        private async Task<Account?> GetAccountById(int id)
        {
            return await repository.FindById(id);
        }

    }
}