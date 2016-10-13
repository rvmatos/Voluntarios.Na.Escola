using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class HabilidadeMap : EntityTypeConfiguration<Habilidade>
    {
        public HabilidadeMap()
        {
            HasKey(x => x.Id);
            Ignore(p => p.Excluido);
            Map(p =>
            {
                p.Requires("Excluido").HasValue(false);
            });

            HasMany(s => s.Eventos)
             .WithMany(c => c.HabilidadesRequeridas)
             .Map(cs =>
             {
                 cs.MapLeftKey("IdHabilidade");
                 cs.MapRightKey("IdEvento");
                 cs.ToTable("HabilidadeEvento");
             });

            HasMany(s => s.Voluntarios)
             .WithMany(c => c.Habilidades)
             .Map(cs =>
             {
                 cs.MapLeftKey("IdHabilidade");
                 cs.MapRightKey("IdVoluntario");
                 cs.ToTable("HabilidadeVoluntario");
             });
            this.ToTable("Habilidades");
        }
    }
}
