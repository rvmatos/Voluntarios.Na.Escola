using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class EventoMap : BaseMapping<Evento>
    {
        public EventoMap() : base()
        {           
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
