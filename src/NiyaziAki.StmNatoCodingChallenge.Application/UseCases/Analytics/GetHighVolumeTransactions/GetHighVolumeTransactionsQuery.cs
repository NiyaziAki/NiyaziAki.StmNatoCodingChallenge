// ************************************************************************
// <copyright file="GetHighVolumeTransactionsQuery.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetHighVolumeTransactions
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a query to retrieve paginated high-volume transactions.
    /// </summary>
    public class GetHighVolumeTransactionsQuery : IRequest<IActionResult>
    {
        /// <summary>
        /// Page number to retrieve; used for pagination. Default is 1.
        /// </summary>
        [FromQuery(Name = "page")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Number of records to return per page. Default is 10.
        /// </summary>
        [FromQuery(Name = "size")]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Minimum transaction amount to be considered high volume.
        /// </summary>
        [FromQuery(Name = "threshold")]
        public decimal Threshold { get; set; }
    }
}
