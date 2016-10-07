﻿using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public class HabilidadeMap : BaseMapping<Habilidade>
    {
        public HabilidadeMap() : base()
        {
            HasMany(s => s.Eventos)
             .WithMany(c => c.HabilidadesRequeridas)
             .Map(cs =>
             {
                 cs.MapLeftKey("IdHabilidade");
                 cs.MapRightKey("IdEvento");
                 cs.ToTable("HabilidadeEvento");
             });

            HasMany(s => s.Voluntarios)
             .WithMany(c => c.Habilidades)
             .Map(cs =>
             {
                 cs.MapLeftKey("IdHabilidade");
                 cs.MapRightKey("IdVoluntario");
                 cs.ToTable("HabilidadeVoluntario");
             });
            this.ToTable("Habilidades");
        }
    }
}
