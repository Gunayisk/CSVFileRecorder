using LinnworksCSVBackend.Common.Requests;
using LinnworksCSVBackend.LinnworksAppModels;
using LinnworksCSVBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : CrudController<Sale>
    {


        protected LinnworksAppContext _context;
        //public readonly IHttpContextAccessor _accessor;
        public readonly ISaleService _saleService;
        public WeatherForecastController(ISaleService saleService/*, IHttpContextAccessor accessor*/):base(saleService/*, accessor*/)
        {
           
            _saleService = saleService;
            //_accessor = accessor;
            _context = new LinnworksAppContext();
        }

   

        [HttpGet]
        public IEnumerable<Country> Get()
        {

            var rng = new Random();
            var models =_context.Countries.ToList();
            return models;
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
              

            //})
            //.ToArray();
        }

        [HttpPost]
        [Route("FileUpload")]
        [RequestSizeLimit(737280000)]
        public IEnumerable<Sale> FileUpload([FromForm]IFormFile file)
        {
            List<Sale> sales = new List<Sale>();
            if (file.FileName.EndsWith(".csv"))
            {
                using (var sreader = new StreamReader(file.OpenReadStream()))
                {
                    string[] headers = sreader.ReadLine().Split(',');     
                    while (!sreader.EndOfStream)                         
                    {
                        string[] rows = sreader.ReadLine().Split(',');
                        string str = rows[0].ToString();
                        //var num = 0;
                        for ( var num = 0; num < headers.Count(); num++)
                        {
                            Sale sale = new Sale
                            {
                               OrderPriority = rows[5],
                              
                            };
                            SaveRequest<Sale> request = new Common.Requests.SaveRequest<Sale>()
                            {
                                Data = sale
                            };
                            var response = _saleService.Add(request);
                        }
                        
                    }
                }
            }
            else
            {
                return sales;
            }
            return sales;
        }


    }
}
