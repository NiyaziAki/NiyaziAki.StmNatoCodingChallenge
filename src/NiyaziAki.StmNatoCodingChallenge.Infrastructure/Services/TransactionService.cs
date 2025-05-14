// ************************************************************************
// <copyright file="TransactionService.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces;

    /// <summary>
    /// Service for handling operations related to transactions, such as creating, deleting, retrieving, and updating transactions.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction, int> transactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to manage database transactions.</param>
        public TransactionService(IUnitOfWork unitOfWork)
        {
            this.transactionRepository = unitOfWork.GetRepository<Transaction, int>();
        }

        /// <summary>
        /// Creates a new transaction and saves it to the database.
        /// </summary>
        /// <param name="userId">The ID of the user associated with the transaction.</param>
        /// <param name="amount">The amount of the transaction.</param>
        /// <param name="transactionType">The type of the transaction (e.g., deposit, withdrawal).</param>
        /// <param name="createdAt">The date and time when the transaction was created.</param>
        /// <returns>The ID of the newly created transaction.</returns>
        public async Task<int> CreateNewTransaction(string userId, decimal amount, TransactionType transactionType, DateTime createdAt)
        {
            Transaction transaction = new Transaction(userId, amount, transactionType, createdAt);
            return await this.transactionRepository.AddAsync(transaction);
        }

        /// <summary>
        /// Deletes a single transaction from the database.
        /// </summary>
        /// <param name="transaction">The transaction to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(Transaction transaction)
        {
            await this.transactionRepository.DeleteAsync(transaction);
        }

        /// <summary>
        /// Deletes a collection of transactions from the database.
        /// </summary>
        /// <param name="transactions">The collection of transactions to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(ICollection<Transaction> transactions)
        {
            await this.transactionRepository.DeleteRangeAsync(transactions);
        }

        /// <summary>
        /// Retrieves a transaction by its ID.
        /// </summary>
        /// <param name="id">The ID of the transaction to retrieve.</param>
        /// <returns>The transaction with the specified ID, or null if not found.</returns>
        public async Task<Transaction?> Get(int id)
        {
            return await this.transactionRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Updates an existing transaction in the database.
        /// </summary>
        /// <param name="transaction">The transaction to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Update(Transaction transaction)
        {
            await this.transactionRepository.UpdateAsync(transaction);
        }
    }
}
