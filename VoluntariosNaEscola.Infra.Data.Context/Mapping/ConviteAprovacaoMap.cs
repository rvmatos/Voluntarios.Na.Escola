using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class ConviteAprovacaoMap : BaseMapping<ConviteAprocao>
    {

        public ConviteAprovacaoMap() : base()
        {
            HasRequired(s => s.Diretor)
                    .WithMany(s => s.Aprovadores)
                    .HasForeignKey(s => s.IdDiretor);


            ToTable("ConviteAprovacao");
        }
    }
}
