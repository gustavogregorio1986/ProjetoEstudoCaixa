using ProjetoEstudoCaixa.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Service.Service.Interface
{
    public interface IUsuarioService
    {
        Task<Usuario> AdicionarUsuario(Usuario usuario);
    }
}
