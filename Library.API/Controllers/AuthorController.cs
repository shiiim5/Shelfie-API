using AutoMapper;
using Library.API.Helper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{

    public class AuthorController : BaseController
    {
        public AuthorController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }


        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var authors = await unit.authorRepository.GetAllAsync();
                if (authors is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }
                return Ok(authors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("author/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var author = await unit.authorRepository.GetByIdAsync(id);
                if (author is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(author);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AuthorDTO authorDTO)
        {
            try
            {
                var author = mapper.Map<Author>(authorDTO);
                await unit.authorRepository.AddAsync(author);

                return Ok(new ResponseAPI(200, "Item has been added"));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update(UpdateAuthorDTO authorDTO)
        {
            try
            {
                var author = mapper.Map<Author>(authorDTO);

                await unit.authorRepository.UpdateAsync(author);
                return Ok(new ResponseAPI(200, "Item has been updated"));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await unit.authorRepository.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been deleted"));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
