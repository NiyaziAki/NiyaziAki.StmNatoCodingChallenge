// ************************************************************************
// <copyright file="PostTransactionCommandHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.PostTransaction
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;

    /// <summary>
    /// Handles the execution of the PostTransactionCommand. This is responsible for processing the transaction creation request.
    /// </summary>
    public class PostTransactionCommandHandler : IRequestHandler<PostTransactionCommand, IActionResult>
    {
        private readonly ITransactionService transactionService;
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes the handler with the necessary dependencies: transaction service and HTTP context accessor.
        /// </summary>
        /// <param name="transactionService">The service to interact with transaction data.</param>
        /// <param name="httpContextAccessor">The HTTP context accessor to retrieve request details.</param>
        public PostTransactionCommandHandler(ITransactionService transactionService, IHttpContextAccessor httpContextAccessor)
        {
            this.transactionService = transactionService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Handles the PostTransactionCommand by creating a new transaction.
        /// </summary>
        /// <param name="request">The command containing transaction details.</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        public async Task<IActionResult> Handle(PostTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int newId = await this.transactionService.CreateNewTransaction(request.UserId, request.Amount, request.TransactionType, request.CreatedAt);
                HttpRequest? requestUrl = this.httpContextAccessor.HttpContext?.Request;

                string location = $"{requestUrl?.Scheme}://{requestUrl?.Host}{requestUrl?.Path}/{newId}";
                return new CreatedResult(location, newId);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return new BadRequestResult();
            }
        }
    }
}
