using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Dtos;
using ProductsAPI.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork,
            IMapper mapper)

        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }



        [HttpGet("{id}")]
        //[Route("api/Products/GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int CategoryId)
        {
            var products = await _unitOfWork.Products.GetByCategoryId(CategoryId);

            if (products == null)
                return NotFound($"No product was found with Category Id :{CategoryId}");

            var data = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return Ok(data);
        }



       

        [HttpPost]
        //[Route("api/Products/AddProduct")]
        [Authorize]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto dto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var product = _mapper.Map<Product>(dto);

             product.Creation_user_id= userId;

            product.CreationDate = DateTime.Now;

            await _unitOfWork.Products.Add(product);

            _unitOfWork.Complete();

            return Ok(product);
        }




        [HttpPut("{id}")]
        //[Route("api/Products/UpdateAsync")]
        [Authorize]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ProductDto dto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var product = await _unitOfWork.Products.GetById(id);

           
            product.ArabicName = dto.ArabicName;
            product.EnglishName = dto.EnglishName;
            product.CategoryId = dto.CategoryId;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.Manufacturer = dto.Manufacturer;


            product.Update_user_id= userId;
            product.ModifiedDate = DateTime.Now;

            _unitOfWork.Products.Update(product);
            _unitOfWork.Complete();
            return Ok(product);
        }



        [HttpDelete("{id}")]
        //[Route("api/Products/DeleteAsync")]

        public async Task<IActionResult> DeleteAsync(int id)
        {

            var product = await _unitOfWork.Products.GetById(id);



            if (product == null)
                return NotFound($"No product was found with Id :{id}");

            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();

            return Ok();

        }



        [HttpGet("(\"search\")/{id}")]
        //[Route("api/Products/SearchAsync")]
        public async Task<IActionResult> SearchAsync(string productName,
            int categoryId)
        {
            var products = await _unitOfWork.Products.Search(productName, categoryId);

            var data = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return Ok(data);
        }
    }
}
