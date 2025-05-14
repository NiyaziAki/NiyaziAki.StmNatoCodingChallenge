// ************************************************************************
// <copyright file="GetAllTransactionsQueryHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.GetAllTransactions
{
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Common;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models;

    /// <summary>
    /// Handles the GetAllTransactionsQuery by retrieving a paginated list of all transactions.
    /// </summary>
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the GetAllTransactionsQueryHandler.
        /// </summary>
        /// <param name="dbConnection">The database connection to execute queries against the database.</param>
        public GetAllTransactionsQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Handles the GetAllTransactionsQuery to retrieve a paginated list of transactions.
        /// </summary>
        /// <param name="request">The query containing pagination parameters.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult representing the paginated transaction result.</returns>
        public async Task<IActionResult> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            string countSql = "SELECT COUNT(*) FROM \"StmNato\".\"Transaction\"";
            string querySql = @"
SELECT ""Id"", ""UserId"", ""Amount"", ""TransactionType"", ""CreatedAt""
FROM ""StmNato"".""Transaction""
ORDER BY ""CreatedAt"" DESC
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
"
            ;

            int totalCount = await this.dbConnection.ExecuteScalarAsync<int>(countSql);

            IEnumerable<TransactionModel> items = await this.dbConnection.QueryAsync<TransactionModel>(querySql, new
            {
                Offset = (request.PageNumber - 1) * request.PageSize,
                request.PageSize,
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
