// ************************************************************************
// <copyright file="Repository.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces;

    /// <summary>
    /// Represents a repository for managing entities of type <typeparamref name="TEntity"/>.
    /// Implements methods for basic CRUD operations using a database context.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository manages.</typeparam>
    /// <typeparam name="TPrimaryKey">The type of the primary key of the entity.</typeparam>
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntityWithPrimaryKey<TPrimaryKey>
    {
        private readonly StmNatoCodingChallengeContext databaseContext;
        private readonly DbSet<TEntity> entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity, TPrimaryKey}"/> class.
        /// The constructor requires a <see cref="StmNatoCodingChallengeContext"/> to interact with the database.
        /// </summary>
        /// <param name="databaseContext">The database context used to perform database operations.</param>
        public Repository(StmNatoCodingChallengeContext databaseContext)
        {
            this.databaseContext = databaseContext;
            this.entities = this.databaseContext.Set<TEntity>();
        }

        /// <summary>
        /// Adds a new entity to the database asynchronously.
        /// This method should be implemented to persist the entity in the database.
        /// </summary>
        /// <param name="entity">The entity to add to the database.</param>
        /// <returns>A task representing the asynchronous operation, with the result being the primary key of the added entity.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not yet implemented.</exception>
        public async Task<TPrimaryKey> AddAsync(TEntity entity)
        {
            await this.entities.AddAsync(entity);
            await this.databaseContext.SaveChangesAsync();
            return entity.Id;
        }

        /// <summary>
        /// Deletes the specified entity from the database asynchronously.
        /// This method should be implemented to remove the entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete from the database.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not yet implemented.</exception>
        public async Task DeleteAsync(TEntity entity)
        {
            this.entities.Remove(entity);
            await this.databaseContext.SaveChangesAsync(true);
        }

        /// <summary>
        /// Deletes a range of entities from the database asynchronously.
        /// This method should be implemented to remove a collection of entities from the database.
        /// </summary>
        /// <param name="entities">The collection of entities to delete from the database.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not yet implemented.</exception>
        public async Task DeleteRangeAsync(ICollection<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
            await this.databaseContext.SaveChangesAsync(true);
        }

        /// <summary>
        /// Asynchronously retrieves an entity by its primary key, with optional eager loading of related entities.
        /// </summary>
        /// <param name="id">The primary key of the entity to retrieve.</param>
        /// <param name="include">An optional function to apply eager loading for related entities.</param>
        /// <returns>A task that represents the asynchronous operation.
        /// The task result is the entity with the specified primary key, or <c>null</c> if not found.</returns>
        public async Task<TEntity> GetByIdAsync(TPrimaryKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = this.databaseContext.Set<TEntity>().AsQueryable();

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        /// <summary>
        /// Updates an existing entity in the database asynchronously.
        /// This method should be implemented to update the entity in the database.
        /// </summary>
        /// <param name="entity">The entity to update in the database.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not yet implemented.</exception>
        public async Task UpdateAsync(TEntity entity)
        {
            this.entities.Update(entity);
            await this.databaseContext.SaveChangesAsync(true);
        }
    }
}
