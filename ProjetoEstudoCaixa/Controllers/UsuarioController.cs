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

        // Cadastro do usuário
        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Dados inválidos.");

            var usuario = new Usuario
            {
                Email = usuarioDTO.Email,
                Perfil = usuarioDTO.Perfil
            };

            // Cria o hash da senha
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuarioDTO.Senha);

            await _usuarioService.AdicionarUsuario(usuario);

            return Ok(new { mensagem = "Usuário cadastrado com sucesso!" });
        }


        // Login do usuário
        [HttpPost("LoginUsuario")]
        public async Task<IActionResult> LoginUsuario([FromBody] UsuarioDTO usuarioLogin)
        {
            if (usuarioLogin == null)
                return BadRequest("Dados inválidos.");

            // Converte o perfil do DTO para EnumPerfil
            if (!Enum.TryParse(usuarioLogin.Perfil.ToString(), out EnumPerfil perfil))
                return BadRequest("Perfil inválido.");

            // Busca usuário pelo email e perfil
            var usuarioDb = await _usuarioService.ObterPorEmailSenhaPerfil(usuarioLogin.Email, perfil);
            if (usuarioDb == null)
                return Unauthorized("Email ou perfil incorretos.");

            // Verifica a senha
            var passwordHasher = new PasswordHasher<Usuario>();
            var resultado = passwordHasher.VerifyHashedPassword(usuarioDb, usuarioDb.Senha, usuarioLogin.Senha.Trim());

            if (resultado == PasswordVerificationResult.Success ||
                resultado == PasswordVerificationResult.SuccessRehashNeeded)
            {
                var token = JwtHelper.GerarToken(usuarioDb, _config);

                return Ok(new
                {
                    mensagem = "Login realizado com sucesso!",
                    token,
                    usuario = new { usuarioDb.Id, usuarioDb.Email, usuarioDb.Perfil }
                });
            }

            return Unauthorized("Senha incorreta.");
        }

    }

}

