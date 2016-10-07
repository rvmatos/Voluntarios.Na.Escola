using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class SupervisorMap : EntityTypeConfiguration<Supervisor>
    {
        public SupervisorMap() : base()
        {
            HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("IdUsuario");
            this.ToTable("Supervisores");
        }
    }
}
