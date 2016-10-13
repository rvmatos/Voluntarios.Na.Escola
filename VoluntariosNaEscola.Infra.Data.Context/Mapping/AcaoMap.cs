using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class AcaoMap : EntityTypeConfiguration<Acao>
    {
        public AcaoMap() : base()
        {
            HasKey(x => x.Id);
            Ignore(p => p.Excluido);
            Map(p =>
            {
                p.Requires("Excluido").HasValue(false);
            });

            HasRequired(s => s.Evento)
                    .WithMany(s => s.Acoes)
                    .HasForeignKey(s => s.IdEvento);

            this.ToTable("Acoes");
        }
    }
}
