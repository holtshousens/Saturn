namespace Saturn.DAL.DataObjects
{
    public class TransactionType
    {
        public TransactionType() { }

        [Key]
        public int TransactionTypeId { get; set; }

        public string TransactionTypeGroup { get; set; }

        public string TransactionTypeName { get; set; }
    }
}
