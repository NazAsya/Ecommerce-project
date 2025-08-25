using Ecommerce.API.DTOs;
using Ecommerce.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; 
        private readonly IConfiguration _configuration;
        //_configuration: appsettings.json içindeki JWT ayarlarını almak için kullanılır.

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        //UserManager: Kullanıcı oluşturma, şifre yönetimi, kullanıcı bulma gibi işlemleri sağla. SignInManager: Giriş(login), logout, şifre kontrolü gibi işlemleri sağlar. Bu iki sınıf ASP.NET Identity'nin temel bileşenleridir.
        private string GenerateJwtToken(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Kullanıcının rollerini al
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
        };

            // Roller varsa claim olarak ekle
            foreach (var role in roles)
            {
              claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        //([FromBody] RegisterDto model): HTTP POST isteği ile gelen JSON verisini RegisterDto modeline bağla.Bu DTO, bir kullanıcıyı kaydetmek için gerekli olan Email, Password, FullName gibi bilgileri içerir
        {
            var user = new AppUser
            //Veritabanına kaydedilecek olan yeni AppUser nesnesi oluşturulur ve DTO'dan gelen verilerle doldurulur.
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
            };
            var result= await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    success = true,
                    message = "Kullanıcı başarıyla oluşturuldu.",
                    email = user.Email,
                    fullName = user.FullName
                });
            }
          return BadRequest(new
            {
                success = false,
                errors = result.Errors.Select(e => e.Description).ToList()
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result= await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
             return Unauthorized(new
            {
              success = false,
              message = "Email veya şifre hatalı"
            });
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = GenerateJwtToken(user);

            return Ok(new
            {
                success = true,
                message = "Giriş başarılı",
                email = user.Email,
                token = token
            });


        }

    }
}
