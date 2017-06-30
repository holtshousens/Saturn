using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain
{
    public class Merchant
    {
        public Merchant() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MerchantId { get; set; }

        public string MerchantName { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
