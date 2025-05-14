// ************************************************************************
// <copyright file="ITransactionService.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;

    /// <summary>
    /// Defines methods for managing transactions.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Creates a new transaction for a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user associated with the transaction.</param>
        /// <param name="amount">The monetary amount of the transaction.</param>
        /// <param name="transactionType">The type of the transaction (e.g., Debit, Credit).</param>
        /// <param name="createdAt">The date and time the transaction was created.</param>
        /// <returns>The ID of the newly created transaction.</returns>
        Task<int> CreateNewTransaction(string userId, decimal amount, TransactionType transactionType, DateTime createdAt);

        /// <summary>
        /// Deletes a transaction by its ID.
        /// </summary>
        /// <param name="transaction">The transaction to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        Task Delete(Transaction transaction);

        /// <summary>
        /// Deletes a collection of transactions.
        /// </summary>
        /// <param name="transactions">The transactions to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        Task Delete(ICollection<Transaction> transactions);

        /// <summary>
        /// Retrieves a transaction by its ID.
        /// </summary>
        /// <param name="id">The ID of the transaction to retrieve.</param>
        /// <returns>The transaction if found; otherwise, <c>null</c>.</returns>
        Task<Transaction?> Get(int id);

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="transaction">The transaction to update.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task Update(Transaction transaction);
    }
}
