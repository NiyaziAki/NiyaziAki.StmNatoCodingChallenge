// ************************************************************************
// <copyright file="DeleteTransactionCommand.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.DeleteTransaction
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a command to delete a transaction.
    /// </summary>
    public class DeleteTransactionCommand : IRequest<IActionResult>
    {
        /// <summary>
        /// The unique identifier of the transaction to be deleted.
        /// This value is passed in the route of the request.
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
