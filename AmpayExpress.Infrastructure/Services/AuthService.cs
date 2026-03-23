using AmpayExpress.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmpayExpress.Infrastructure.Services
{
	public class AuthService : IAuthService
	{
		private readonly IConfiguration _config;
		public AuthService(IConfiguration config)
		{
			_config = config;
		}

		public string GenerateToken(string usuario, string rol)
		{
			var secretKey = _config.GetSection("Jwt:Key").Value!;
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, usuario),
					new Claim(ClaimTypes.Role, rol) // Puedes agregar roles o permisos aquí
				}),
				Expires = DateTime.UtcNow.AddHours(2), // El token expirará en 2 hora
				SigningCredentials =
					new SigningCredentials(
					new SymmetricSecurityKey(key),
					SecurityAlgorithms.HmacSha256Signature),
				Issuer = _config.GetSection("Jwt:Issuer").Value,
				Audience = _config.GetSection("Jwt:Audience").Value
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
