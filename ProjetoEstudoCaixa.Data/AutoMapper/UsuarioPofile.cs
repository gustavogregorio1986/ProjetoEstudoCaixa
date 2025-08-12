using AutoMapper;
using ProjetoEstudoCaixa.Data.DTO;
using ProjetoEstudoCaixa.Dominio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Data.AutoMapper
{
    public class UsuarioPofile : Profile
    {
        public UsuarioPofile()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
