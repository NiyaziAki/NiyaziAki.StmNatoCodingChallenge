// ************************************************************************
// <copyright file="IEntityWithPrimaryKey.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces
{
    /// <summary>
    /// Represents an entity with a primary key of a specific type.
    /// </summary>
    /// <typeparam name="TPrimaryKey">The type of the primary key.</typeparam>
    public interface IEntityWithPrimaryKey<TPrimaryKey>
    {
        /// <summary>
        /// Primary key of the entity.
        /// </summary>
        public TPrimaryKey Id { get; set; }
    }
}
