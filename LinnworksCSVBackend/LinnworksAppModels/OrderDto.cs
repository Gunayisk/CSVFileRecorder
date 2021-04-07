using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public class OrderDto
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string Item_Type { get; set; }
        public string Sales_Channel { get; set; }
        public string Order_Priority { get; set; }
        public DateTime Order_Date { get; set; }
        public long OrderID { get; set; }
        public DateTime ShipDate { get; set; }
        public long UnitsSold { get; set; }
        public string UnitPrice { get; set; }
        public string UnitCost { get; set; }
        public long TotalRevenue { get; set; }
        public long TotalCost { get; set; }
        public long TotalProfit { get; set; }
    }
}
