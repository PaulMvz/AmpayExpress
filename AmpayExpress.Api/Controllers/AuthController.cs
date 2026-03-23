using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AmpayExpress.Application.Auth;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;



namespace AmpayExpress.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : Controller
	{
		private readonly IConfiguration _config;

		public AuthController(IConfiguration config)
		{
			_config = config;
		}
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginDto login)
		{
			// 🛡️ Simulación de usuario (Luego lo traeremos de la DB)
			if (login.Usuario == "admin" && login.Password == "Abancay2026")
			{
				var secretKey = _config.GetSection("Jwt:Key").Value!;
				var key = Encoding.ASCII.GetBytes(secretKey);

				var tokenDescriptor = new SecurityTokenDescriptor
				{
					Subject = new ClaimsIdentity(new[]
					{
						new Claim(ClaimTypes.Name, login.Usuario),
						new Claim(ClaimTypes.Role, "Administrator") // Puedes agregar roles o permisos aquí
				}),
					Expires = DateTime.UtcNow.AddHours(1), // El token expirará en 1 hora
					SigningCredentials =
						new SigningCredentials(
						new SymmetricSecurityKey(key),
						SecurityAlgorithms.HmacSha256Signature),
					Issuer = _config.GetSection("Jwt:Issuer").Value,
					Audience = _config.GetSection("Jwt:Audience").Value
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				var token = tokenHandler.CreateToken(tokenDescriptor);
				var jwtToken = tokenHandler.WriteToken(token);

				return Ok(new { token = jwtToken });

			}

			return Unauthorized(); // Si falla, 401 
		}
	}
}
