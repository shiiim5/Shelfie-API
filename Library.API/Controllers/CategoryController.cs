using AutoMapper;
using Library.API.Helper;
using Library.Core.DTOs;
using Library.Core.Entities.Books;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Library.API.Controllers
{

    public class CategoryController : BaseController
    {
        public CategoryController(IUnitOfWork unit, IMapper mapper) : base(unit, mapper)
        {
        }

        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await unit.categoryRepository.GetAllAsync();
                if (categories is null)
                {
                    return BadRequest(new ResponseAPI(400));
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Cat/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cat = await unit.categoryRepository.GetByIdAsync(id);
                if (cat is null)
                    return BadRequest(new ResponseAPI(400));
                return Ok(cat);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CategoryDTO categoryDTO)
        {
            try {
                var category = mapper.Map<Category>(categoryDTO);
                await unit.categoryRepository.AddAsync(category);

                return Ok(new ResponseAPI(200, "Item has been added" ));

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update(UpdateCategoryDTO categoryDTO)
        {
            try
            {
                var category = mapper.Map<Category>(categoryDTO);

                await unit.categoryRepository.UpdateAsync(category);
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
                await unit.categoryRepository.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been deleted"));


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

