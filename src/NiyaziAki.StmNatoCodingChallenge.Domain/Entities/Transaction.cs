// ************************************************************************
// <copyright file="Transaction.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Entities
{
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;

    /// <summary>
    /// Represents a financial transaction performed by a user.
    /// </summary>
    public class Transaction : BaseEntity<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class with the specified user ID, amount, and transaction type.
        /// The <see cref="CreatedAt"/> property is set to the current date and time.
        /// </summary>
        /// <param name="userId">The primary key of the user associated with the transaction.</param>
        /// <param name="amount">The amount used in the transaction.</param>
        /// <param name="transactionType">The type of the transaction.</param>
        public Transaction(string userId, decimal amount, TransactionType transactionType)
        {
            this.UserId = userId;
            this.Amount = amount;
            this.TransactionType = transactionType;
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class with the specified user ID, amount, transaction type, and creation date.
        /// </summary>
        /// <param name="userId">The primary key of the user associated with the transaction.</param>
        /// <param name="amount">The amount used in the transaction.</param>
        /// <param name="transactionType">The type of the transaction.</param>
        /// <param name="createdAt">The date and time when the transaction was created.</param>
        public Transaction(string userId, decimal amount, TransactionType transactionType, DateTime createdAt)
           : this(userId, amount, transactionType)
        {
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// The private key of the user associated with the transaction.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// The date and time of the transaction.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The user of the transaction.
        /// </summary>
        public virtual User? User { get; set; }
    }
}
