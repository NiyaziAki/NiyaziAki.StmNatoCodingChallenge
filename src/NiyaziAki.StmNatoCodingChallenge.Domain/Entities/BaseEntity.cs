// ************************************************************************
// <copyright file="BaseEntity.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Entities
{
    using NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces;

    /// <summary>
    /// REpresenta a base entity implementation.
    /// </summary>
    /// <typeparam name="TPrivateKey">The type of the primary key.</typeparam>
    public abstract class BaseEntity<TPrivateKey> : IBaseEntity<TPrivateKey>
        where TPrivateKey : struct
    {
        /// <summary>
        /// PRimary key of the entity.
        /// </summary>
        public TPrivateKey Id { get; set; }

        /// <summary>
        /// Returns the primary key of the entity.
        /// </summary>
        /// <returns>A string that represents the id of the entity.</returns>
        public override string? ToString()
        {
            return this.Id.ToString();
        }
    }
}
