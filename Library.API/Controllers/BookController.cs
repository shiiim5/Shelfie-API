using AutoMapper;
using Library.API.Helper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{

    public class BookController : BaseController
    {
        public BookController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }


        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var books = await unit.bookRepository.GetAllAsync(x=>x.category,x=>x.photos);
                var result = mapper.Map<List<BookDTO>>(books);
                if (books is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));

            }
        }

        [HttpGet("book/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var book = await unit.bookRepository.GetByIdAsync(id,x=>x.category,x=>x.photos);

                var result = mapper.Map<BookDTO>(book);
                if (book is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] AddBookDTO bookDTO)
        {
            try
            {
              
                await unit.bookRepository.AddAsync(bookDTO);

                return Ok(new ResponseAPI(200, "Item has been added"));

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));

            }

        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update([FromForm] UpdateBookDTO bookDTO)
        {
            try
            {
                await unit.bookRepository.UpdateAsync(bookDTO);
                return Ok(new ResponseAPI(200, "Item has been updated"));

            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));

            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await unit.bookRepository.GetByIdAsync(id,x=>x.photos,x=>x.category);
                await unit.bookRepository.DeleteAsync(book);

                return Ok(new ResponseAPI(200, "Item has been deleted"));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
