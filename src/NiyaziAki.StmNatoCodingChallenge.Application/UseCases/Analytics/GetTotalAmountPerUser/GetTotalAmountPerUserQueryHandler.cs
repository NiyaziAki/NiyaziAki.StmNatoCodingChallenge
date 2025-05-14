// ************************************************************************
// <copyright file="GetTotalAmountPerUserQueryHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetTotalAmountPerUser
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.Models;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Common;

    /// <summary>
    /// Handles the <see cref="GetTotalAmountPerUserQuery"/> request to calculate the total transaction amount for each user, with support for pagination.
    /// </summary>
    public class GetTotalAmountPerUserQueryHandler : IRequestHandler<GetTotalAmountPerUserQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTotalAmountPerUserQueryHandler"/> class.
        /// </summary>
        /// <param name="dbConnection">Database connection used to execute SQL queries.</param>
        public GetTotalAmountPerUserQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Handles the query to retrieve a paginated list of users along with the total amount of their transactions.
        /// </summary>
        /// <param name="request">The query parameters including page number and page size.</param>
        /// <param name="cancellationToken">Token used to cancel the operation if requested.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing a paginated list of users and their total transaction amounts.
        /// </returns>
        public async Task<IActionResult> Handle(GetTotalAmountPerUserQuery request, CancellationToken cancellationToken)
        {
            string countSql = @"
SELECT Count(*)
FROM ""StmNato"".""Transaction"" transaction
INNER JOIN ""User"" user
ON user.""Id"" = transaction.""UserId""
GROUP BY user.""Id"", user.""FullName""
";
            string querySql = @"
SELECT user.""Id"" AS ""UserId"", user.""FullName"", SUM(""Amount"") AS ""TotalAmount""
FROM ""StmNato"".""Transaction"" transaction
INNER JOIN ""User"" user
ON user.""Id"" = transaction.""UserId""
GROUP BY user.""Id"", user.""FullName""
ORDER BY user.""FullName""
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
";

            int totalCount = await this.dbConnection.ExecuteScalarAsync<int>(countSql);

            IEnumerable<TotalAmountPerUserAnalyticsModel> items = await this.dbConnection.QueryAsync<TotalAmountPerUserAnalyticsModel>(querySql, new
            {
                Offset = (request.PageNumber - 1) * request.PageSize,
                request.PageSize,
            });

            PagedResult<TotalAmountPerUserAnalyticsModel> pagedResult = new PagedResult<TotalAmountPerUserAnalyticsModel>
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
