using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class AcaoMap : BaseMapping<Acao>
    {
        public AcaoMap() : base()
        {
            HasRequired(s => s.Evento)
                    .WithMany(s => s.Acoes)
                    .HasForeignKey(s => s.IdEvento);

            this.ToTable("Acoes");
        }
    }
}
