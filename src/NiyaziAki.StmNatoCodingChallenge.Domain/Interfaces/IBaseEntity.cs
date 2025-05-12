// ************************************************************************
// <copyright file="IBaseEntity.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represetns a base entity contract.
    /// </summary>
    /// <typeparam name="TPrivateKey">The type of the primary key.</typeparam>
    public interface IBaseEntity<TPrivateKey>
        where TPrivateKey : struct ////int, long, guid
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        [Column(Order = 0)]
        public TPrivateKey Id { get; set; }
    }
}
