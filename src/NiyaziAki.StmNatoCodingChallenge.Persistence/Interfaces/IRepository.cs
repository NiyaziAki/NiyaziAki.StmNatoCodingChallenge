// ************************************************************************
// <copyright file="IRepository.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces
{
    using System.Threading.Tasks;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces;

    /// <summary>
    /// A generic repository interface for accessing and manipulating entities with a primary key.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
    public interface IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntityWithPrimaryKey<TPrimaryKey>
    {
        /// <summary>
        /// Asynchronously retrieves an entity by its primary key, with optional eager loading of related entities.
        /// </summary>
        /// <param name="id">The primary key of the entity to retrieve.</param>
        /// <param name="include">An optional function to apply eager loading for related entities.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result is the entity with the specified primary key, or <c>null</c> if not found.</returns>
        Task<TEntity> GetByIdAsync(TPrimaryKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The primary key of the added entity.</returns>
        Task<TPrimaryKey> AddAsync(TEntity entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Deletes a range of entities from the repository.
        /// </summary>
        /// <param name="entities">The collection of entities to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteRangeAsync(ICollection<TEntity> entities);
    }
}
