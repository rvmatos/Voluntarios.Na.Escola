using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class EscolaMap : BaseMapping<Escola>
    {
        public EscolaMap() : base()
        {
            
            HasRequired(p => p.Diretor)
               .WithMany()
               .HasForeignKey(p => p.IdDiretor);

            HasRequired(p => p.Endereco)
               .WithMany()
               .HasForeignKey(p => p.IdEndereco);

            HasMany(s => s.Supervisores)
                .WithMany(c => c.Escolas)
                .Map(cs =>
                {
                    cs.MapLeftKey("IdEscola");
                    cs.MapRightKey("IdSupervisor");
                    cs.ToTable("EscolaSupervisor");
                });

            

            this.ToTable("Escolas");
        }
    }
}
