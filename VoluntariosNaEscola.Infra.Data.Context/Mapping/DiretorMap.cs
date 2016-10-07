using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class DiretorMap : EntityTypeConfiguration<Diretor>
    {
        public DiretorMap() : base()
        {
            HasKey(x => x.Id);
            this.Property(x => x.Id).HasColumnName("IdUsuario");
            HasRequired(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.IdEndereco);
            HasRequired(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.IdEndereco);

            
            this.ToTable("Diretores");


        }
    }
}
