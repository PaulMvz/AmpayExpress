using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AmpayExpress.Application.Auth;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using AmpayExpress.Application.Interfaces;



namespace AmpayExpress.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpPost("login")]
		public IActionResult Login([FromBody] LoginDto login)
		{
			// 🛡️ Simulación de usuario (Luego lo traeremos de la DB) (Control total)
			if (login.Usuario == "admin" && login.Password == "Abancay2026")
			{
				//Ahora solo llamamos al servicio de autenticación para generar el token
				var token = _authService.GenerateToken(login.Usuario, "Administrador");
				return Ok(new { token });
			}

			// Usuario REPARTIDOR (Solo lectura / entrega)
			if (login.Usuario == "repartidor" && login.Password == "Ampay2026")
			{
				var token = _authService.GenerateToken(login.Usuario, "Repartidor");
				return Ok(new { token });
			}

			return Unauthorized(); // Si falla, 401 
		}
	}
}
