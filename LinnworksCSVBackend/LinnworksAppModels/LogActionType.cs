using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class LogActionType
    {
        public LogActionType()
        {
            Logs = new HashSet<Log>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
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
        [InverseProperty("LogActionTypes")]
        public virtual Transaction Transaction { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("LogActionTypes")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(Log.ActionType))]
        public virtual ICollection<Log> Logs { get; set; }
    }
}
