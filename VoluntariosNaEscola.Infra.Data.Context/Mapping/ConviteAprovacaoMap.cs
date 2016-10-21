using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class ConviteAprovacaoMap : EntityTypeConfiguration<ConviteAprovacao>
    {

        public ConviteAprovacaoMap() : base()
        {
            HasKey(x => x.Id);
            Ignore(p => p.Excluido);
            Map(p =>
            {
                p.Requires("Excluido").HasValue(false);
            });

            HasRequired(s => s.Diretor)
                    .WithMany(s => s.Aprovadores)
                    .HasForeignKey(s => s.IdDiretor);


            ToTable("ConviteAprovacao");
        }
    }
}
