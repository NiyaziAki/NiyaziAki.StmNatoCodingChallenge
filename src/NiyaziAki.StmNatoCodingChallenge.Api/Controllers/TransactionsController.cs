// ************************************************************************
// <copyright file="TransactionsController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for handling transactions.
    /// </summary>
    public class TransactionsController : BaseController
    {
        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>All transactions.</returns>
        [HttpGet]
        [Route("", Name = "GetAllTransactions")]
        public async Task<IActionResult> Get()
        {
            return this.Ok();
        }

        /// <summary>
        /// Creates a new transaction.
        /// </summary>
        /// <returns>Returns the id of the newly created transaction with status 201.</returns>
        [HttpPost]
        [Route("", Name = "CreateNewTransaction")]
        public async Task<IActionResult> Post()
        {
            return this.Created();
        }

        /// <summary>
        /// Gets the transaction matching the given id.
        /// </summary>
        /// <param name="id">The id of the transaction.</param>
        /// <returns>The transaction or 404 if not found.</returns>
        [HttpGet]
        [Route("{id}", Name = "GetTransaction")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return this.Ok();
        }

        /// <summary>
        /// Updates the transaction matching the given id.
        /// </summary>
        /// <param name="id">The id of the transaction.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpPut]
        [Route("{id}", Name = "UpdateTransaction")]
        public async Task<IActionResult> Put([FromRoute] int id)
        {
            return this.Ok();
        }

        /// <summary>
        /// Deletes the transaction matching the given id.
        /// </summary>
        /// <param name="id">The id of the transaction.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpDelete]
        [Route("{id}", Name = "DeleteTransaction")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return this.Ok();
        }
    }
}
