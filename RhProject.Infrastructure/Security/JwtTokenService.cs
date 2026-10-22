using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RhProject.Application.Interfaces.Security;
using RhProject.Application.Response.Auth;
using RhProject.Domain.Entities;
using RhProject.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using UsuarioEntity = RhProject.Domain.Entities.Usuario;

namespace RhProject.Infrastructure.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public LoginResponse GerarToken(UsuarioEntity usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),

                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),

                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var expiracao = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiracao,
                signingCredentials: credenciais);

            var tokenGerado = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponse
            {
                AccessToken = tokenGerado,
                TokenType = "Bearer",
                ExpiresAt = expiracao
            };
        }
    }
}