// ************************************************************************
// <copyright file="GetTransactionQuery.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.GetTransaction
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a query to retrieve a single transaction by its Id.
    /// </summary>
    public class GetTransactionQuery : IRequest<IActionResult>
    {
        /// <summary>
        /// The unique identifier of the transaction to retrieve.
        /// This value is passed in the route of the request.
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
