using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Infra.Data.Repository.EntityFramework.Common;

namespace VoluntariosNaEscola.Infra.Data.Repository.EntityFramework
{
    public class EscolaRepository : Repository<Escola>, IEscolaRepository
    {
        public override void Delete(Escola entity)
        {
            // GrupoUsuario
            //for (int i = 0; i < entity.GrupoUsuario.Count; )
            //{
            //    Context.Entry(entity.GrupoUsuario.First()).State = EntityState.Deleted;
            //}



            base.Delete(entity);
        }
    }
}
