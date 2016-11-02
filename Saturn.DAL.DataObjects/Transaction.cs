using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.DAL.DataObjects
{
    public class Transaction
    {
        public Transaction() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime? TransactionDate { get; set; }

        public double TransactionAmount { get; set; }

        public string TransactionName { get; set; }

        public DateTime TransactionLoadDate { get; set; }

        //[InverseProperty("CardId")]
        //[ForeignKey("CardId")]
        //public virtual int? CardId { get; set; }

    }
}
