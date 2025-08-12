using ProjetoEstudoCaixa.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Data.Respository.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> AdicionarUsuario(Usuario usuario);
    }
}
