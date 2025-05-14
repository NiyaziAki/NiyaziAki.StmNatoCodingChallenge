// ************************************************************************
// <copyright file="UnitOfWork.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Storage;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces;

    /// <summary>
    /// Implements the UnitOfWork pattern for managing database transactions and repositories.
    /// This class provides methods to begin, commit, or roll back transactions,
    /// as well as save changes and access repositories for entities.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StmNatoCodingChallengeContext databaseContext;
        private IDbContextTransaction? currentTransaction;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context used to manage database operations.</param>
        public UnitOfWork(StmNatoCodingChallengeContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Begins a new database transaction asynchronously.
        /// This will allow multiple operations to be performed atomically.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, with the transaction.</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            this.currentTransaction = await this.databaseContext.Database.BeginTransactionAsync(cancellationToken);
            return this.currentTransaction;
        }

        /// <summary>
        /// Saves all changes made in the current context to the database asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, with the number of state entries written to the database.</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.databaseContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Commits the transaction, making all changes made during the transaction permanent.
        /// If no transaction was started, an exception will be thrown.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">Thrown if no transaction was started.</exception>
        /// <returns>A task representing the asynchronous commit operation.</returns>
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (this.currentTransaction != null)
            {
                await this.databaseContext.SaveChangesAsync(cancellationToken);
                await this.currentTransaction.CommitAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Transaction is not started.");
            }
        }

        /// <summary>
        /// Rolls back the transaction, discarding all changes made during the transaction.
        /// If no transaction was started, an exception will be thrown.
        /// </summary>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <exception cref="InvalidOperationException">Thrown if no transaction was started.</exception>
        /// <returns>A task representing the asynchronous rollback operation.</returns>
        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (this.currentTransaction != null)
            {
                await this.currentTransaction.RollbackAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Transaction is not started.");
            }
        }

        /// <summary>
        /// Gets a repository for the specified entity type and primary key type.
        /// This allows access to the specific CRUD operations for the entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity for which the repository is created.</typeparam>
        /// <typeparam name="TPrimaryKey">The type of the primary key of the entity.</typeparam>
        /// <returns>A repository for the specified entity type.</returns>
        public IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()
            where TEntity : class, IEntityWithPrimaryKey<TPrimaryKey>
        {
            return new Repository<TEntity, TPrimaryKey>(this.databaseContext);
        }
    }
}
