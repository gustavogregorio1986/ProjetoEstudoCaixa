using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEstudoCaixa.Data.DTO;
using ProjetoEstudoCaixa.Dominio.Dominio;
using ProjetoEstudoCaixa.Service.Service.Interface;

namespace ProjetoEstudoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
          private readonly IUsuarioService _usuarioService;
          private readonly IMapper _mapper;

          public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
          {
              _usuarioService = usuarioService;
              _mapper = mapper;
          }

        [HttpPost]
        [Route("AdicionarUsuario")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return BadRequest("Usuário não pode ser nulo.");

            var senhaHash = Service.Criptografia.PasswordHelper.HashPassword(usuarioDTO.Senha);
            usuarioDTO.Senha = senhaHash;

            var usuario = _mapper.Map<Usuario>(usuarioDTO);

            var usuarioCriado = await _usuarioService.AdicionarUsuario(usuario);

            var usuarioRetorno = _mapper.Map<UsuarioDTO>(usuarioCriado);

            return Ok(usuarioRetorno);
        }

    }
}
