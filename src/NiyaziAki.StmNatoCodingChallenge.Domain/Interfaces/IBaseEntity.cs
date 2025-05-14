// ************************************************************************
// <copyright file="IBaseEntity.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces
{
    /// <summary>
    /// Represetns a base entity contract.
    /// </summary>
    /// <typeparam name="TPrivateKey">The type of the primary key.</typeparam>
    public interface IBaseEntity<TPrivateKey> : IEntityWithPrimaryKey<TPrivateKey>
        where TPrivateKey : struct ////int, long, guid
    {
    }
}
