using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class DiretorMap : EntityTypeConfiguration<Diretor>
    {
        public DiretorMap()
        {
            this.ToTable("Diretores");
            HasKey(x => x.Id);
          
            this.Property(x => x.Id).HasColumnName("IdUsuario");
           

           


        }
    }
}
