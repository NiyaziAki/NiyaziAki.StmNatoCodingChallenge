// ************************************************************************
// <copyright file="AnalyticsController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetHighVolumeTransactions;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetTotalAmountPerTransactionType;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetTotalAmountPerUser;

    /// <summary>
    /// Controller for handling analytics.
    /// </summary>
    public class AnalyticsController : BaseController
    {

        /// <summary>
        /// Calculate the total transaction amount for each user.
        /// </summary>
        /// <param name="getTotalAmountPerUserQuery">Paging request payload.</param>
        /// <returns>Paged total transactions per user.</returns>
        [HttpGet]
        [Route("total-per-user", Name = "GetTotalAmountPerUserQuery")]
        public async Task<IActionResult> GetTotalPerUser([FromQuery] GetTotalAmountPerUserQuery getTotalAmountPerUserQuery)
        {
            return await this.GetMediator().Send(getTotalAmountPerUserQuery);
        }

        /// <summary>
        /// Calculate the total transaction amount for each transaction type.
        /// </summary>
        /// <returns>Returns total transactions per type.</returns>
        [HttpGet]
        [Route("total-per-type", Name = "GetTotalAmountPerTransactionTypeQuery")]
        public async Task<IActionResult> GetTotalPerTypeQuery()
        {
            return await this.GetMediator().Send(new GetTotalAmountPerTransactionTypeQuery());
        }

        /// <summary>
        /// Returns transactions above a certain threshold amount.
        /// </summary>
        /// <param name="getHighVolumeTransactionsQuery">The threshold request.</param>
        /// <returns>Paged total transactions above the given threshold.</returns>
        [HttpGet]
        [Route("high-volume", Name = "GetHighVolumeTransactionsQuery")]
        public async Task<IActionResult> GetHighVolumeTransactionsQuery([FromQuery] GetHighVolumeTransactionsQuery getHighVolumeTransactionsQuery)
        {
            return await this.GetMediator().Send(getHighVolumeTransactionsQuery);
        }
    }
}
