﻿using System;

namespace Saturn.Domain.Interfaces
{
    public interface ITransaction
    {
        double TransactionAmount { get; set; }
        DateTime TransactionDate { get; set; }
        int TransactionId { get; set; }
        DateTime TransactionLoadDateTime { get; set; }
        string TransactionName { get; set; }
    }
}