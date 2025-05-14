// ************************************************************************
// <copyright file="IUnitOfWork.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore.Storage;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces;

    /// <summary>
    /// Represents a unit of work pattern to manage database transactions and repositories.
    /// It provides a mechanism for handling transactions and ensures that changes to the database
    /// are committed or rolled back as a single operation. It also allows access to repositories
    /// for entities that implement <see cref="IEntityWithPrimaryKey{TPrimaryKey}"/>.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Begins a new database transaction asynchronously.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token for the operation.</param>
        /// <returns>A task representing the asynchronous operation, with a transaction object.</returns>
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Begins a new database transaction asynchronously.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token for the operation.</param>
        /// <returns>A task representing the asynchronous operation, with a transaction object.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Commits the transaction asynchronously, making all changes permanent.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token for the operation.</param>
        /// <returns>A task representing the asynchronous commit operation.</returns>
        Task CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Commits the transaction asynchronously, making all changes permanent.
        /// </summary>
        /// <param name="cancellationToken">An optional cancellation token for the operation.</param>
        /// <returns>A task representing the asynchronous commit operation.</returns>
        Task RollbackAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a repository for a specific entity type and primary key asynchronously.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to get the repository for.</typeparam>
        /// <typeparam name="TPrimaryKey">The type of the primary key of the entity.</typeparam>
        /// <returns>A repository for the specified entity type and primary key.</returns>
        IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()
            where TEntity : class, IEntityWithPrimaryKey<TPrimaryKey>;
    }
}
