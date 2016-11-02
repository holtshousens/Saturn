using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.DAL.DataObjects
{
    public class AccountType
    {
        public AccountType() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountTypeId { get; set; }

        public string sortCode { get; set; }

        public string accountNumber { get; set; }

        public string accountType { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
