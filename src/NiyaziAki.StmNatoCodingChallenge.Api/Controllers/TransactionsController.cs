// ************************************************************************
// <copyright file="TransactionsController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.DeleteTransaction;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.GetAllTransactions;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.GetTransaction;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.PostTransaction;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.PutTransaction;

    /// <summary>
    /// Controller for handling transactions.
    /// </summary>
    public class TransactionsController : BaseController
    {
        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <param name="getAllTransactionsQuery">Pagign request.</param>
        /// <returns>All transactions.</returns>
        [HttpGet]
        [Route("", Name = "GetAllTransactions")]
        public async Task<IActionResult> Get([FromQuery] GetAllTransactionsQuery getAllTransactionsQuery)
        {
            return await this.GetMediator().Send(getAllTransactionsQuery);
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <param name="postTransactionCommand">Payload.</param>
        /// <returns>Returns the id of the newly created transaction with status 201.</returns>
        [HttpPost]
        [Route("", Name = "CreateNewTransaction")]
        public async Task<IActionResult> Post([FromBody] PostTransactionCommand postTransactionCommand)
        {
            return await this.GetMediator().Send(postTransactionCommand);
        }

        /// <summary>
        /// Gets the transaction matching the given id.
        /// </summary>
        /// <param name="getTransactionQuery">Request payload.</param>
        /// <returns>The transaction or 404 if not found.</returns>
        [HttpGet]
        [Route("{id}", Name = "GetTransaction")]
        public async Task<IActionResult> Get([FromRoute] GetTransactionQuery getTransactionQuery)
        {
            return await this.GetMediator().Send(getTransactionQuery);
        }

        /// <summary>
        /// Updates the transaction matching the given id.
        /// </summary>
        /// <param name="putTransactionCommand">Payload.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpPut]
        [Route("{id}", Name = "UpdateTransaction")]
        public async Task<IActionResult> Put([FromRoute] PutTransactionCommand putTransactionCommand)
        {
            return await this.GetMediator().Send(putTransactionCommand);
        }

        /// <summary>
        /// Deletes the transaction matching the given id.
        /// </summary>
        /// <param name="deleteTransactionCommand">The id of the transaction.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpDelete]
        [Route("{id}", Name = "DeleteTransaction")]
        public async Task<IActionResult> Delete([FromRoute] DeleteTransactionCommand deleteTransactionCommand)
        {
            return await this.GetMediator().Send(deleteTransactionCommand);
        }
    }
}
