﻿using System.Collections.Generic;

namespace Saturn.Domain.Interface
{
    public interface ITransactionGroup
    {
        int TransactionGroupId { get; set; }
        string TransactionGroupName { get; set; }
        ICollection<Transaction> Transactions { get; set; }
    }
}