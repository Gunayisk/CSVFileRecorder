using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class Sale
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("region_id")]
        public int? RegionId { get; set; }
        [Column("countrie_id")]
        public int? CountrieId { get; set; }
        [Column("item_type_id")]
        public int? ItemTypeId { get; set; }
        [Column("sales_channel_id")]
        public int? SalesChannelId { get; set; }
        [Column("user_id")]
        public Guid? UserId { get; set; }
        [Column("transaction_id")]
        public long? TransactionId { get; set; }
        [Column("order_priority")]
        [StringLength(1)]
        public string OrderPriority { get; set; }
        [Column("order_date")]
        [StringLength(50)]
        public string OrderDate { get; set; }
        [Column("ship_date")]
        [StringLength(50)]
        public string ShipDate { get; set; }
        [Column("units_sold")]
        public int? UnitsSold { get; set; }
        [Column("unit_price")]
        public int? UnitPrice { get; set; }
        [Column("unit_cost")]
        public int? UnitCost { get; set; }
        [Column("total_revenue")]
        [StringLength(50)]
        public string TotalRevenue { get; set; }
        [Column("total_coast")]
        [StringLength(50)]
        public string TotalCoast { get; set; }
        [Column("total_profit")]
        [StringLength(50)]
        public string TotalProfit { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("update_date", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey(nameof(CountrieId))]
        [InverseProperty(nameof(Country.Sales))]
        public virtual Country Countrie { get; set; }
        [ForeignKey(nameof(ItemTypeId))]
        [InverseProperty("Sales")]
        public virtual ItemType ItemType { get; set; }
        [ForeignKey(nameof(RegionId))]
        [InverseProperty("Sales")]
        public virtual Region Region { get; set; }
        [ForeignKey(nameof(SalesChannelId))]
        [InverseProperty("Sales")]
        public virtual SalesChannel SalesChannel { get; set; }
        [ForeignKey(nameof(TransactionId))]
        [InverseProperty("Sales")]
        public virtual Transaction Transaction { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Sales")]
        public virtual User User { get; set; }
    }
}
