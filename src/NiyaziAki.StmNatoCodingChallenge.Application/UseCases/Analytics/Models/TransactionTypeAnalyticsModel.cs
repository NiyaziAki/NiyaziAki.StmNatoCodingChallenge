// ************************************************************************
// <copyright file="TransactionTypeAnalyticsModel.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.Models
{
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;

    /// <summary>
    /// Represents analytics data for a specific type of transaction.
    /// </summary>
    public class TransactionTypeAnalyticsModel
    {
        /// <summary>
        /// The type of the transaction (e.g., Credit, Debit).
        /// </summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// The name associated with the transaction type (e.g., "Credit" or "Debit").
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The total amount for the given transaction type.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
