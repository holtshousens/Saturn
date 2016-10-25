using System;

namespace Saturn.DAL.DataObjects
{
    public class Transaction
    {
        public Transaction() { }

        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Account { get; set; }

        public double TransactionAmount { get; set; }

        //public string Subcategory { get; set; }

        //public string Memo { get; set; }

        public DateTime TransactionLoadDate { get; set; }

        //public Guid AccountTypeRefNo { get; set; }

        //public Guid MerchantsRefNo { get; set; }

        //public Guid TransactionGroupRefNo { get; set; }

}
}
