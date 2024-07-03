using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Base
{
    public abstract class BaseController<T> : ControllerBase
    {
        private DbContext Context { get; }
        public IMapper Mapper { get; }


        public BaseController(DbContext Context, IMapper Mapper)
        {
            this.Context = Context;
            this.Mapper = Mapper;
        }

        [HttpPost]
        public IActionResult Add([FromBody] T Dto)
        {
            T Data = Mapper.Map<T>(Dto);
            Context.Add(Data!);
            Context.SaveChanges();
            return Ok();
        }
    }
}
