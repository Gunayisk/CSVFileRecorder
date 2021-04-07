using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    [Table("SalesChannel")]
    [Index(nameof(Id), Name = "IX_SalesChannel")]
    public partial class SalesChannel
    {
        public SalesChannel()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("update_date", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("user_id")]
        public Guid? UserId { get; set; }
        [Column("transaction_id")]
        public long? TransactionId { get; set; }

        [ForeignKey(nameof(TransactionId))]
        [InverseProperty("SalesChannels")]
        public virtual Transaction Transaction { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("SalesChannels")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Sale.SalesChannel))]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
