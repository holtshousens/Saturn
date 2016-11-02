using Saturn.DAL.DataObjects.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.DAL.DataObjects
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
