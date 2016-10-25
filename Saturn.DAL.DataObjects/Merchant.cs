using System.ComponentModel.DataAnnotations;

namespace Saturn.DAL.DataObjects
{
    public class Merchant
    {
        public Merchant() { }

        [Key]
        public int MerchantId { get; set; }

        public string MerchantName { get; set; }
    }
}
