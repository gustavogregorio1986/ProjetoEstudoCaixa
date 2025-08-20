using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstudoCaixa.Data.DTO;
using ProjetoEstudoCaixa.Dominio.Dominio;
using ProjetoEstudoCaixa.Dominio.Enum;
using ProjetoEstudoCaixa.Helper;
using ProjetoEstudoCaixa.Service.Service.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetoEstudoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
          private readonly IUsuarioService _usuarioService;
          private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper, IConfiguration config)
          {
              _usuarioService = usuarioService;
              _mapper = mapper;
              _config = config;
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Usuário não pode ser nulo.");

            // Cria hash da senha
            usuarioDTO.Senha = Service.Criptografia.PasswordHelper.HashPassword(usuarioDTO.Senha);

            // Mapeia DTO para entidade
            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            // Salva usuário no banco
            var usuarioCriado = await _usuarioService.AdicionarUsuario(usuario);

            // Mapeia de volta para DTO (senha não será retornada por causa do [JsonIgnore])
            var usuarioRetorno = _mapper.Map<UsuarioDTO>(usuarioCriado);

            return Ok(usuarioRetorno);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuarioLogin)
        {
            if (usuarioLogin == null)
                return BadRequest("Dados inválidos.");

            var usuarioDb = await _usuarioService.ObterPorEmailSenhaPerfil(usuarioLogin.Email, (EnumPerfil)(int)usuarioLogin.Perfil);

            if (usuarioDb == null)
                return Unauthorized("Email ou perfil incorretos.");

            // Verifica senha
            var passwordHasher = new PasswordHasher<Usuario>();
            var resultado = passwordHasher.VerifyHashedPassword(usuarioDb, usuarioDb.Senha, usuarioLogin.Senha);

            if (resultado == PasswordVerificationResult.Success)
            {
                var token = JwtHelper.GerarToken(usuarioDb, _config);

                return Ok(new
                {
                    mensagem = "Login realizado com sucesso!",
                    token = token,
                    usuario = new
                    {
                        usuarioDb.Id,
                        usuarioDb.Email,
                        usuarioDb.Perfil
                    }
                });
            }

            return Unauthorized("Senha incorreta.");
        }

    }

}

