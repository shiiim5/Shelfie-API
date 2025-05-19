using AutoMapper;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    public class BugController : BaseController
    {
        public BugController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }

        [HttpGet("not-found")]
        public async Task<ActionResult> GetNotFound()
        {
            var category = await unit.categoryRepository.GetByIdAsync(100);
            if (category == null) 
                return NotFound();
            return Ok(category);
        }


        [HttpGet("server-error")]
        public async Task<ActionResult> GetServerError()
        {
            var category = await unit.categoryRepository.GetByIdAsync(100);
            category.Name = "";
            return Ok(category);
        }

        [HttpGet("bad-request/{Id}")]
        public async Task<ActionResult> GetBadRequest(int id)
        {
            return Ok();
        }


        [HttpGet("bad-request/")]
        public async Task<ActionResult> GetBadRequest()
        {
            return BadRequest();
        }

    }
}
