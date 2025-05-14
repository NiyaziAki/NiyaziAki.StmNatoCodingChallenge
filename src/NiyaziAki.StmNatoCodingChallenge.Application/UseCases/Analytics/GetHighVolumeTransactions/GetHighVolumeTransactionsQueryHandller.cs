// ************************************************************************
// <copyright file="GetHighVolumeTransactionsQueryHandller.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetHighVolumeTransactions
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Common;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models;

    /// <summary>
    /// Handles the <see cref="GetHighVolumeTransactionsQuery"/> request to fetch paginated transactions exceeding a specified amount threshold.
    /// </summary>
    public class GetHighVolumeTransactionsQueryHandller : IRequestHandler<GetHighVolumeTransactionsQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetHighVolumeTransactionsQueryHandller"/> class.
        /// </summary>
        /// <param name="dbConnection">Database connection used to execute SQL queries.</param>
        public GetHighVolumeTransactionsQueryHandller(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Handles the query request by retrieving transactions above a given threshold, applying pagination.
        /// Returns a paginated result set wrapped in an <see cref="OkObjectResult"/>.
        /// </summary>
        /// <param name="request">The query parameters including page number, page size, and threshold.</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>An <see cref="IActionResult"/> containing the paginated list of transactions.</returns>
        public async Task<IActionResult> Handle(GetHighVolumeTransactionsQuery request, CancellationToken cancellationToken)
        {
            string countSql = "SELECT COUNT(*) FROM \"StmNato\".\"Transaction\" WHERE \"Amount\" > @Threshold";
            string querySql = @"
SELECT ""Id"", ""UserId"", ""Amount"", ""TransactionType"", ""CreatedAt""
FROM ""StmNato"".""Transaction""
WHERE ""Amount"" > @Threshold
ORDER BY ""CreatedAt"" DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
";

            int totalCount = await this.dbConnection.ExecuteScalarAsync<int>(countSql, request.Threshold);

            IEnumerable<TransactionModel> items = await this.dbConnection.QueryAsync<TransactionModel>(querySql, new
            {
                Offset = (request.PageNumber - 1) * request.PageSize,
                request.PageSize,
                request.Threshold,
            });

            PagedResult<TransactionModel> pagedResult = new PagedResult<TransactionModel>
            {
                PageNumber = request.PageNumber,
                RowCount = request.PageSize,
                TotalRowCount = totalCount,
                Items = items.ToList(),
            };

            return new OkObjectResult(pagedResult);
        }
    }
}
