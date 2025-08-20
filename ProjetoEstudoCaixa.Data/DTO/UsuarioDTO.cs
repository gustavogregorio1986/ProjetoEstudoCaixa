using ProjetoEstudoCaixa.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoEstudoCaixa.Data.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Senha { get; set; }

        public EnumPerfil? Perfil { get; set; }
    }
}
