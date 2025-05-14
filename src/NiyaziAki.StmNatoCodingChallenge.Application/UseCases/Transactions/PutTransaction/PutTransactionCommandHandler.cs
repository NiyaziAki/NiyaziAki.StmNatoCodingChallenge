// ************************************************************************
// <copyright file="PutTransactionCommandHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.PutTransaction
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Handles the request to update an existing transaction.
    /// </summary>
    public class PutTransactionCommandHandler : IRequestHandler<PutTransactionCommand, IActionResult>
    {
        private readonly ITransactionService transactionService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PutTransactionCommandHandler"/> class.
        /// </summary>
        /// <param name="transactionService">The service used to interact with transactions.</param>
        /// <param name="mapper">The mapper used to convert transaction entities into models.</param>
        public PutTransactionCommandHandler(ITransactionService transactionService, IMapper mapper)
        {
            this.transactionService = transactionService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the request to update a transaction. It fetches the transaction by its ID, applies
        /// the updates from the request, and saves the updated transaction. Then, it returns a model of
        /// the updated transaction.
        /// </summary>
        /// <param name="request">The request containing the updated transaction information.</param>
        /// <param name="cancellationToken">The cancellation token to observe while processing the request.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the operation.</returns>
        public async Task<IActionResult> Handle(PutTransactionCommand request, CancellationToken cancellationToken)
        {
            Transaction? transaction = await this.transactionService.Get(request.Id);
            if (transaction == null)
            {
                return new NotFoundResult();
            }

            transaction.UserId = request.UserId;
            transaction.Amount = request.Amount;
            transaction.TransactionType = request.TransactionType;
            transaction.CreatedAt = request.CreatedAt;

            await this.transactionService.Update(transaction);

            TransactionModel model = this.mapper.Map<TransactionModel>(transaction);
            ////TransactionModel model = TransactionModel.Map<TransactionModel>(transaction); same as automapper

            return new OkObjectResult(model);
        }
    }
}
