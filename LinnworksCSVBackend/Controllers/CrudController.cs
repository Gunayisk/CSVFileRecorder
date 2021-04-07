using LinnworksCSVBackend.Common.Requests;
using LinnworksCSVBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.Controllers
{
    public class CrudController<TEntity> : Controller where TEntity : class, new()
    {
        protected readonly IGenericService<TEntity> _genericService;
        //private IHttpContextAccessor _accessor;

        public CrudController(IGenericService<TEntity> genericService/*, IHttpContextAccessor accessor*/)
        {
            //_accessor = accessor;
            _genericService = genericService;
        }

        [HttpPost]
        public virtual JsonResult Store([FromBody]SaveRequest<TEntity> request)
        {
            var response = _genericService.Add(request);
            return Json(new { response });
        }
    }
}
