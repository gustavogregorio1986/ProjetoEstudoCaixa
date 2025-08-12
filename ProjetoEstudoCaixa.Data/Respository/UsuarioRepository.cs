using ProjetoEstudoCaixa.Data.Respository.Interface;
using ProjetoEstudoCaixa.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Data.Respository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
