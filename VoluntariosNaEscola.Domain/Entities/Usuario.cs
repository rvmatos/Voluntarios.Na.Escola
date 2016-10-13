using System;

namespace VoluntariosNaEscola.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string Profissao { get; set; }

       
    }
}
