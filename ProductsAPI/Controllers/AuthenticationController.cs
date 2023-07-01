using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductsAPI.Dtos;
using ProductsAPI.Helpers;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationController(IConfiguration configuration , IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        [Route("api/login")]
        public IActionResult Login(UserDto user)
        {
            if (!string.IsNullOrEmpty(user.Email) &&
                !string.IsNullOrEmpty(user.Password))
            {
                var loggedInUser = _unitOfWork.Users.Get(user);
                if (loggedInUser is null) return NotFound("User not found");

                var claims = new[]
                {
            //new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
            new Claim(ClaimTypes.Email, loggedInUser.Email),
            new Claim(ClaimTypes.GivenName, loggedInUser.EnglishName),
            new Claim(ClaimTypes.GivenName, loggedInUser.ArabicName),
           // new Claim(ClaimTypes.MobilePhone, loggedInUser.Mobile),
            new Claim("userId", loggedInUser.UserId),
            new Claim("password", loggedInUser.Password)
        };

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                        SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenString);
            }
            return BadRequest("Invalid user credentials");
        }
    }
}



