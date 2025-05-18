using AutoMapper;
using Library.API.Helper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
   
    public class BorrowController : BaseController
    {
        public BorrowController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }


        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var borrows = await unit.borrowRepository.GetAllAsync();
                if (borrows is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }
                return Ok(borrows);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("borrow/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var borrow = await unit.borrowRepository.GetByIdAsync(id);
                if (borrow is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(borrow);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(BorrowDTO borrowDTO)
        {
            try
            {
                var borrow = mapper.Map<Borrow>(borrowDTO);
                await unit.borrowRepository.AddAsync(borrow);

                return Ok(new ResponseAPI(200, "Item has been added"));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update(UpdateBorrowDTO borrowDTO)
        {
            try
            {
                var borrow = mapper.Map<Borrow>(borrowDTO);

                await unit.borrowRepository.UpdateAsync(borrow);
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
                await unit.borrowRepository.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been deleted"));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
