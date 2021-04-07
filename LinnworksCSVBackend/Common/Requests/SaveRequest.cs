using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.Common.Requests
{
    public class SaveRequest<T>
    {
        public T Data { get; set; }
    }
}
