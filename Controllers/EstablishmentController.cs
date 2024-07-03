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
    public class EstablishmentController : BaseController<Establishment>
    {

        public EstablishmentController(EstablishmentContext ctx, IMapper mapper)
               : base(ctx, mapper)
        {

        }

        

    }
}
