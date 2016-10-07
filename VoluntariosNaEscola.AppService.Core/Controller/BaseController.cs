using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VoluntariosNaEscola.Application;
using VoluntariosNaEscola.Domain.Interfaces.Application.Common;
using VoluntariosNaEscola.Domain.Interfaces.AppService.Common;
using VoluntariosNaEscola.Domain.Validations;

namespace VoluntariosNaEscola.AppService.Core.Controller
{
    public class BaseController<TEntity> : ApiController, IAppService<TEntity> where TEntity : class
    {

        public int IdUserLogged
        {
            get { return Convert.ToInt32((User.Identity as ClaimsIdentity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid).Value); }
        }

        private readonly IApplication<TEntity> _appBase;
        public BaseController(IApplication<TEntity> appBase)
        {
            _appBase = appBase;
        }


        [HttpGet]
        public virtual HttpResponseMessage GetAll()
        {
            var result = _appBase.GetAll();
            return Request.CreateResponse<IEnumerable<TEntity>>(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public virtual HttpResponseMessage Get(int id)
        {
            var result = _appBase.Get(id);
            return Request.CreateResponse<TEntity>(HttpStatusCode.OK, result);
        }

        [HttpPost]
        public virtual HttpResponseMessage Add(TEntity entity)
        {
            var result = new ValidationResult();

            try
            {
                result = _appBase.Add(entity);
                result.Model = entity;
            }
            catch (Exception ex)
            {
                result.Add("Ocorreu um erro inesperado: " + ex.Message);
            }


            if (result.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
        }

        [HttpPost]
        public virtual HttpResponseMessage Delete(int id)
        {
            var result = new ValidationResult();

            try
            {
                result = _appBase.Delete(id);
            }
            catch (Exception ex)
            {
                result.Add("Ocorreu um erro inesperado: " + ex.Message);
            }
            if (result.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
        }

        [HttpPost]
        public virtual HttpResponseMessage Update(TEntity entity)
        {
            var result = new ValidationResult();

            try
            {
                result = _appBase.Update(entity);
                result.Model = entity;
            }
            catch (Exception ex)
            {
                result.Add("Ocorreu um erro inesperado: " + ex.Message);
            }


            if (result.IsValid)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result);
        }

        public void Disposable()
        {
            _appBase.Dispose();

        }
    }
}
