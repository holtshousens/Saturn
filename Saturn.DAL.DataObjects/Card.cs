using Saturn.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }

        public CardTypeEnum CardType { get; set; }
        
        public string CardOwner { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
