// ************************************************************************
// <copyright file="PostTransactionCommand.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.PostTransaction
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;

    /// <summary>
    /// Command used to post a new transaction. It implements IRequest to be handled by a specific handler.
    /// </summary>
    public class PostTransactionCommand : IRequest<IActionResult>
    {
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
