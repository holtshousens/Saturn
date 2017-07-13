using System.Collections.Generic;
using Saturn.Domain.Enums;

namespace Saturn.Domain.Interfaces
{
    public interface ICard
    {
        int CardId { get; set; }
        string CardOwner { get; set; }
        CardTypeEnum CardType { get; set; }
        ICollection<Transaction> Transactions { get; set; }
    }
}