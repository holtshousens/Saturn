using Saturn.Domain.Enums;
using Saturn.Domain.Interface;
using System.Collections.Generic;

namespace Saturn.Domain
{
    public class Card : ICard
    {
        public int CardId { get; set; }
        public CardTypeEnum CardType { get; set; }
        public string CardOwner { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
