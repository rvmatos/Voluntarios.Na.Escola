using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap() : base()
        {
            HasKey(x => x.Id);
            Ignore(p => p.Excluido);
            Map(p =>
            {
                p.Requires("Excluido").HasValue(false);
            });

            HasRequired(p => p.Criador)
               .WithMany()
               .HasForeignKey(p => p.IdUsuarioCriador);

            HasRequired(p => p.Escola)
             .WithMany()
             .HasForeignKey(p => p.IdEscola);


            HasMany(s => s.Supervisores)
                .WithMany(c => c.Eventos)
                .Map(cs =>
                {
                    cs.MapLeftKey("IdEvento");
                    cs.MapRightKey("IdSupervisor");
                    cs.ToTable("EventoSupervisor");
                });



            this.ToTable("Eventos");
        }
    }
}
