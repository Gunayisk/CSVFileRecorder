using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class ItemType
    {
        public ItemType()
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
        [InverseProperty("ItemTypes")]
        public virtual Transaction Transaction { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("ItemTypes")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Sale.ItemType))]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
