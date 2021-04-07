using LinnworksCSVBackend.LinnworksAppModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.Services.Interfaces
{
    public class SaleService : GenericService<Sale>, ISaleService
    {
        private readonly LinnworksAppContext _context;
        //private readonly IHttpContextAccessor _accessor;
        public SaleService(LinnworksAppContext context/*, IHttpContextAccessor accessor*/) : base(context/*, accessor*/)
        {
            _context = context;
            //_accessor = accessor;
        }
    }
}
