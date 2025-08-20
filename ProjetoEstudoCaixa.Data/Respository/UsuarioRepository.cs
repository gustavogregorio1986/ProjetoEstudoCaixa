using Microsoft.EntityFrameworkCore;
using ProjetoEstudoCaixa.Data.Context;
using ProjetoEstudoCaixa.Data.DTO;
using ProjetoEstudoCaixa.Data.Respository.Interface;
using ProjetoEstudoCaixa.Dominio.Dominio;
using ProjetoEstudoCaixa.Dominio.Enum;
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

        public async Task<Usuario?> ObterPorEmailSenhaPerfil(string email, EnumPerfil perfil)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u =>
             u.Email == email &&
             u.Perfil == perfil
         );
        }

        
    }
}
