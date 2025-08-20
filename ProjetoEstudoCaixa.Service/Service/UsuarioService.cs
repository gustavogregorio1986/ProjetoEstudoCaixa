using ProjetoEstudoCaixa.Data.Respository.Interface;
using ProjetoEstudoCaixa.Dominio.Dominio;
using ProjetoEstudoCaixa.Dominio.Enum;
using ProjetoEstudoCaixa.Service.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Service.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            return await _usuarioRepository.AdicionarUsuario(usuario);
        }

        public async Task<Usuario> ObterPorEmailSenhaPerfil(string email, string senha, EnumPerfil perfil)
        {
            return await _usuarioRepository.ObterPorEmailSenhaPerfil(email, senha, perfil);
        }
    }
}
