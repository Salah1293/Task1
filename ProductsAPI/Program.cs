using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductsAPI;
using ProductsAPI.Dtos;
using ProductsAPI.Helpers;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();











var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
Options.UseSqlServer(ConnectionString));


//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();













builder.Services.AddCors();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program));




var app = builder.Build();


var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();


//[HttpPost]
//[Route("api/login")]
//IResult Login(UserDto user, IUsersRepository service)
//{
//    if (!string.IsNullOrEmpty(user.Email) &&
//        !string.IsNullOrEmpty(user.Password))
//    {
//        var loggedInUser = service.Get(user);
//        if (loggedInUser is null) return Results.NotFound("User not found");

//        var claims = new[]
//        {
//            new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
//            new Claim(ClaimTypes.Email, loggedInUser.Email),
//            new Claim(ClaimTypes.GivenName, loggedInUser.EnglishName),
//            new Claim(ClaimTypes.GivenName, loggedInUser.ArabicName),
//            //new Claim(ClaimTypes.MobilePhone, loggedInUser.Mobile),
//            new Claim("userId", loggedInUser.UserId)
//        };

//        //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//        var token = new JwtSecurityToken
//        (
//            issuer: builder.Configuration["Jwt:Issuer"],
//            audience: builder.Configuration["Jwt:Audience"],
//            claims: claims,
//            expires: DateTime.UtcNow.AddDays(60),
//            notBefore: DateTime.UtcNow,
//            signingCredentials: new SigningCredentials(
//                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
//                SecurityAlgorithms.HmacSha256)
//        );

//        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

//        return Results.Ok(tokenString);
//    }
//    return Results.BadRequest("Invalid user credentials");
//}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
