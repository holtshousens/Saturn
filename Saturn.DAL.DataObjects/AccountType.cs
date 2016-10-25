using System.ComponentModel.DataAnnotations;

namespace Saturn.DAL.DataObjects
{
    public class AccountType
    {
        public AccountType() { }

        [Key]
        public int AccountTypeId { get; set; }

        public string sortCode { get; set; }

        public string accountNumber { get; set; }

        public string accountType { get; set; }

    }
}
