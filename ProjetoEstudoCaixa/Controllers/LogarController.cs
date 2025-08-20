using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoEstudoCaixa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogarController : ControllerBase
    {
        [Authorize(Roles = "Adm")]
        [HttpGet("admin/perfil")]
        public IActionResult DashboardAdmin()
        {
            return Ok("Bem-vindo, administrador!");
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("cliente/perfil")]
        public IActionResult PerfilCliente()
        {
            return Ok("Bem-vindo, cliente!");
        }
    }
}
