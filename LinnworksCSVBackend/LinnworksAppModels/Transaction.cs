using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class Transaction
    {
        public Transaction()
        {
            Countries = new HashSet<Country>();
            ItemTypes = new HashSet<ItemType>();
            LogActionTypes = new HashSet<LogActionType>();
            Logs = new HashSet<Log>();
            Regions = new HashSet<Region>();
            Sales = new HashSet<Sale>();
            SalesChannels = new HashSet<SalesChannel>();
            Users = new HashSet<User>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("user_id")]
        public Guid? UserId { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("update_date", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Country.Transaction))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(ItemType.Transaction))]
        public virtual ICollection<ItemType> ItemTypes { get; set; }
        [InverseProperty(nameof(LogActionType.Transaction))]
        public virtual ICollection<LogActionType> LogActionTypes { get; set; }
        [InverseProperty(nameof(Log.Transaction))]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty(nameof(Region.Transaction))]
        public virtual ICollection<Region> Regions { get; set; }
        [InverseProperty(nameof(Sale.Transaction))]
        public virtual ICollection<Sale> Sales { get; set; }
        [InverseProperty(nameof(SalesChannel.Transaction))]
        public virtual ICollection<SalesChannel> SalesChannels { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
