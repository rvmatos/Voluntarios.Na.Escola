using System;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;
using VoluntariosNaEscola.Domain.Entities;
using VoluntariosNaEscola.Domain.Interfaces.Repository;
using VoluntariosNaEscola.Infra.Data.Repository.EntityFramework.Common;

namespace VoluntariosNaEscola.Infra.Data.Repository.EntityFramework
{
    public class VoluntarioRepository : Repository<Voluntario>, IVoluntarioRepository
    {
        public override void Delete(Voluntario entity)
        {
            // GrupoUsuario
            //for (int i = 0; i < entity.GrupoUsuario.Count; )
            //{
            //    Context.Entry(entity.GrupoUsuario.First()).State = EntityState.Deleted;
            //}



            base.Delete(entity);
        }


        public bool VincularEscola(int idEscola, int idVoluntario)
        {
            using (var context = _dbContext)
            {
                var owner = _dbContext.Voluntarios.Find(idVoluntario);
                var child = _dbContext.Escolas.Find(idEscola);

                owner.Escolas.Add(child);
                context.Voluntarios.Attach(owner);
                return context.SaveChanges() > 0;
            }
        }

        
    }
}
