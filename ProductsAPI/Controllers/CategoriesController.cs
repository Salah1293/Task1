using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Dtos;
using ProductsAPI.Models;
using System.Security.Claims;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CategoriesController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }



        [HttpGet]
        //[Route("api/Categories/GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _unitOfWork.Category.GetAll();

            var data = _mapper.Map<IEnumerable<CategoryDetailsDto>>(categories);

            return Ok(data);

        }



        [HttpPost]
        //[Route("api/Categories/CreateAsync")]
        [Authorize]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryDto dto)
        {
            var userId = User.FindFirstValue("userId");
            var category = _mapper.Map<Category>(dto);

            category.Creation_user_id = userId;

            category.CreationDate = DateTime.Now;

            await _unitOfWork.Category.Add(category);

            _unitOfWork.Complete();

            return Ok(category);
        }


        [HttpPut("{id}")]
        //[Route("api/Categories/UpdateAsync")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] CategoryDto dto)
        {

            var userId = User.FindFirstValue("userId");
            var category = await _unitOfWork.Category.GetById(id);

            category.ArabicName = dto.ArabicName;
            category.EnglishName = dto.EnglishName;
            category.StartDate = dto.StartDate;
            category.EndDate = dto.EndDate;

            category.Update_user_id = userId;

            category.ModifiedDate = DateTime.Now;

            _unitOfWork.Category.Update(category);
            _unitOfWork.Complete();
            return Ok(category);
        }



        [HttpDelete("(\"search\")/{id}")]
        //[Route("api/Categories/DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var category = await _unitOfWork.Category.GetById(id);



            if (category == null)
                return NotFound($"No category was found with Id :{id}");


            _unitOfWork.Category.Delete(category);
            _unitOfWork.Complete();

            return Ok();

        }






    }
}
