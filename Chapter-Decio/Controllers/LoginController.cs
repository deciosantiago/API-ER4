using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Chapter_Decio.Interfaces;
using Chapter_Decio.Models;
using Chapter_Decio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Chapter_Decio.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;
        private IUsuarioRepository? iUsuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        public object JwtRegisteredClainNames { get; private set; }

        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioEncontrado = _iUsuarioRepository.Login(login.Email, login.Senha);
            
            if (usuarioEncontrado == null)
            {
                return Unauthorized(new {msg = "E-mail e/ou senha inválidos" });
            }

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioEncontrado.Tipo)
            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
            var meuToken = new JwtSecurityToken(
                issuer: "chapter.webapi",
                claims: minhasClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credenciais
                );

            return Ok(
                
                new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
                
                );


        }

    }
}
