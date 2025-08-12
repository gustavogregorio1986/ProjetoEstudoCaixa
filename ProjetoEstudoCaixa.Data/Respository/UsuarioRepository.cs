using ProjetoEstudoCaixa.Data.Context;
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
        private readonly CaixaContext _context;

        public UsuarioRepository(CaixaContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            var usaurioCriado = await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usaurioCriado.Entity;
        }
    }
}
