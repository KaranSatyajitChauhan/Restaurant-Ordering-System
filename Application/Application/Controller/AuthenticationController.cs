using Application.Data;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Week_10_Class_1_DW4.Services;
using Week_6_Class_2_DW4.Models;
using static Application.Model.LoginDto;

namespace Application.Controller
{

    [Route("api/auth")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly MongoDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        // Inject Configuration (for JWT Secret)
        public AuthenticationController(IConfiguration configuration, MongoDbContext dbContext, IPasswordService passwordService, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        //public AuthenticationController(MongoDbContext dbContext) {
        //_dbContext= dbContext;
        //}


        [HttpPost("signup")]

        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var existingUser = await _dbContext.User.Find(u => u.UserName == signUpDto.UserName).FirstOrDefaultAsync();

            if (existingUser != null)
            {
                return BadRequest(new { error = "This user is already taken!" });
            }

            var hashedPassword = _passwordService.HashPassword(signUpDto.Password);

            var user = new User
            {
                UserName = signUpDto.UserName,
                Password = hashedPassword,
                Email = signUpDto.Email
            };

            await _dbContext.User.InsertOneAsync(user);
            return Ok();
        }


        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginRequest loginRequest)
        //{
        //    // Validate user (In real-world, query a database)
        //    if (loginRequest.Email == "test@example.com" && loginRequest.Password == "password123")
        //    {
        //        var token = GenerateJwtToken(loginRequest.Email);
        //        return Ok(new { token });
        //    }

        //    return Unauthorized(new { error = "Invalid email or password" });
        //}

        //private string GenerateJwtToken(string email)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.Email, email),
        //        new Claim(ClaimTypes.Name, "Test User"),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };

        //    var token = new JwtSecurityToken(
        //        _configuration["Jwt:Issuer"],
        //        _configuration["Jwt:Issuer"],
        //        claims,
        //        expires: DateTime.UtcNow.AddHours(1),
        //        signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}


    }
}
