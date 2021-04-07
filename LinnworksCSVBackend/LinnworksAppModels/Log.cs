using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LinnworksCSVBackend.LinnworksAppModels
{
    public partial class Log
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("action_type_id")]
        public long? ActionTypeId { get; set; }
        [Column("create_date", TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column("update_date", TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        [Column("user_id")]
        public Guid? UserId { get; set; }
        [Column("transaction_id")]
        public long? TransactionId { get; set; }

        [ForeignKey(nameof(ActionTypeId))]
        [InverseProperty(nameof(LogActionType.Logs))]
        public virtual LogActionType ActionType { get; set; }
        [ForeignKey(nameof(TransactionId))]
        [InverseProperty("Logs")]
        public virtual Transaction Transaction { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Logs")]
        public virtual User User { get; set; }
    }
}
