using Saturn.Domain.Enums;
using System.Collections.Generic;
using Saturn.Domain.Interfaces;

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
