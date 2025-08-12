using ProjetoEstudoCaixa.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Dominio.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public EnumPerfil? Perfil { get; set; }
    }
}
