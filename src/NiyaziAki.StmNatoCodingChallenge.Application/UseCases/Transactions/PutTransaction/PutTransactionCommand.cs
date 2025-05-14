// ************************************************************************
// <copyright file="PutTransactionCommand.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.PutTransaction
{
    using System;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;

    /// <summary>
    /// Represents a command to update an existing transaction. It contains all the necessary details.
    /// </summary>
    public class PutTransactionCommand : IRequest<IActionResult>
    {
        /// <summary>
        /// The unique identifier of the transaction that needs to be updated.
        /// This value is passed via the route parameter.
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The private key of the user associated with the transaction.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// The date and time of the transaction.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
