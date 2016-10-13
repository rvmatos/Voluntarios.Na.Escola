using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class SupervisorMap : EntityTypeConfiguration<Supervisor>
    {
        public SupervisorMap()
        {
            this.ToTable("Supervisores");
            HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("IdUsuario");
        
        }
    }
}
