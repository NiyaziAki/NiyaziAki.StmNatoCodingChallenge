// ************************************************************************
// <copyright file="TransactionType.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Enums
{
    /// <summary>
    /// Defines the types of financial transactions.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// A transaction where money is deducted from the account.
        /// </summary>
        Debit = 1,

        /// <summary>
        ///  A transaction where money is added to the account.
        /// </summary>
        Credit = 2,
    }
}
