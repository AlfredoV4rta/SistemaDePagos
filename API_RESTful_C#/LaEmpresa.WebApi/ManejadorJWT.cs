using LaEmpresa.LogicaAplicacion.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace LaEmpresa.WebApi
{
    public class ManejadorJWT
    {
        internal static object GenerarToken(UsuarioDTO logueado)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var clave = Encoding.UTF8.GetBytes("clave_SecretaDeLaEmpr_esaGoated_tieneQueSerMasLarga");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Email, logueado.Email),
                        new Claim(ClaimTypes.Role, logueado.Rol.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, logueado.Id.ToString()),
                    }
                ),
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(clave),
                        SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
