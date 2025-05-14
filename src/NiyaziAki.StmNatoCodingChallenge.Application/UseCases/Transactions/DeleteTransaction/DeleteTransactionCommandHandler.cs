// ************************************************************************
// <copyright file="DeleteTransactionCommandHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.DeleteTransaction
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Handles the deletion of a transaction based on the provided command.
    /// </summary>
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand, IActionResult>
    {
        private readonly ITransactionService transactionService;

        /// <summary>
        /// Initializes a new instance of the DeleteTransactionCommandHandler.
        /// </summary>
        /// <param name="transactionService">The service used to interact with transactions.</param>
        public DeleteTransactionCommandHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        /// <summary>
        /// Handles the DeleteTransactionCommand by deleting the transaction with the specified Id.
        /// </summary>
        /// <param name="request">The command containing the transaction Id to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult representing the outcome of the operation.</returns>
        public async Task<IActionResult> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            Transaction? transaction = await this.transactionService.Get(request.Id);

            if (transaction == null)
            {
                return new NotFoundResult();
            }

            await this.transactionService.Delete(transaction);

            return new OkResult();
        }
    }
}
