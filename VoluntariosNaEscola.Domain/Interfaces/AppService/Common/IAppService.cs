using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VoluntariosNaEscola.Domain.Interfaces.AppService.Common
{
    public interface IAppService<TEntity> where TEntity : class
    {
        HttpResponseMessage GetAll();
        HttpResponseMessage Get(int id);
        HttpResponseMessage Add(TEntity entity);
        HttpResponseMessage Update(TEntity entity);
        HttpResponseMessage Delete(int id);
        void Disposable();
    }
}
