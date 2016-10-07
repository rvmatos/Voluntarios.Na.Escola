using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class VoluntarioMap : EntityTypeConfiguration<Voluntario>
    {
        public VoluntarioMap() : base()
        {
            HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("IdUsuario");
            HasRequired(p => p.Endereco)
               .WithMany()
               .HasForeignKey(p => p.IdEndereco);


            HasMany(s => s.Escolas)
              .WithMany(c => c.Voluntarios)
              .Map(cs =>
              {
                  cs.MapLeftKey("IdVoluntario");
                  cs.MapRightKey("IdEscola");
                  cs.ToTable("EscolaVoluntario");
              });


            HasMany(s => s.Eventos)
            .WithMany(c => c.Voluntarios)
            .Map(cs =>
            {
                cs.MapLeftKey("IdEvento");
                cs.MapRightKey("IdEscola");
                cs.ToTable("EventoVoluntario");
            });

            this.ToTable("Voluntarios");
        }
    }
}
