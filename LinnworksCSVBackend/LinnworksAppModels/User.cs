using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class User
    {
        public User()
        {
            Countries = new HashSet<Country>();
            ItemTypes = new HashSet<ItemType>();
            LogActionTypes = new HashSet<LogActionType>();
            Logs = new HashSet<Log>();
            Regions = new HashSet<Region>();
            Sales = new HashSet<Sale>();
            SalesChannels = new HashSet<SalesChannel>();
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Column("father_name")]
        [StringLength(50)]
        public string FatherName { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("update_date", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("transaction_id")]
        public long? TransactionId { get; set; }

        [ForeignKey(nameof(TransactionId))]
        public virtual Transaction Transaction { get; set; }
        [InverseProperty(nameof(Country.User))]
        public virtual ICollection<Country> Countries { get; set; }
        [InverseProperty(nameof(ItemType.User))]
        public virtual ICollection<ItemType> ItemTypes { get; set; }
        [InverseProperty(nameof(LogActionType.User))]
        public virtual ICollection<LogActionType> LogActionTypes { get; set; }
        [InverseProperty(nameof(Log.User))]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty(nameof(Region.User))]
        public virtual ICollection<Region> Regions { get; set; }
        [InverseProperty(nameof(Sale.User))]
        public virtual ICollection<Sale> Sales { get; set; }
        [InverseProperty(nameof(SalesChannel.User))]
        public virtual ICollection<SalesChannel> SalesChannels { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
