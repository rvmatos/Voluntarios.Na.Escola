using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class EnderecoMap : BaseMapping<Endereco>
    {
        public EnderecoMap() : base()
        {
            this.ToTable("Enderecos");
        }
    }
}
