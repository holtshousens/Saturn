using Saturn.DAL.DataObjects.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saturn.DAL.DataObjects
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        public CardTypeEnum CardType { get; set; }
        
        public string CardOwner { get; set; }

        public IList<Transaction> Transactions { get; set; }
    }
}
