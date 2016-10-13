using System.Data.Entity.ModelConfiguration;
using VoluntariosNaEscola.Domain.Entities;

namespace VoluntariosNaEscola.Infra.Data.Context.Mapping
{
    public  class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuarios");
            HasKey(x => x.Id);
            //Ignore(p => p.Excluido);
            //Map(p =>
            //{
            //    p.Requires("Excluido").HasValue(false);
            //});

            
        }
    }
}
