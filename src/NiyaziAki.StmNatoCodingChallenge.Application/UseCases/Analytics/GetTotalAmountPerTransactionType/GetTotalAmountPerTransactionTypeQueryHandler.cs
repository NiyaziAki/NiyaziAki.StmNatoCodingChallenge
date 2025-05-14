// ************************************************************************
// <copyright file="GetTotalAmountPerTransactionTypeQueryHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetTotalAmountPerTransactionType
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.Models;

    /// <summary>
    /// Handles the <see cref="GetTotalAmountPerTransactionTypeQuery"/> request to calculate the total transaction amount
    /// grouped by transaction type (e.g., Debit, Credit).
    /// </summary>
    public class GetTotalAmountPerTransactionTypeQueryHandler : IRequestHandler<GetTotalAmountPerTransactionTypeQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTotalAmountPerTransactionTypeQueryHandler"/> class.
        /// </summary>
        /// <param name="dbConnection">Database connection used to execute SQL queries.</param>
        public GetTotalAmountPerTransactionTypeQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Handles the query to return the total amount of transactions for each transaction type.
        /// Ensures all types (e.g., Debit, Credit) are returned even if their total amount is zero.
        /// </summary>
        /// <param name="request">The query object (empty, but used for MediatR pipeline).</param>
        /// <param name="cancellationToken">Token used to cancel the operation.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing a list of transaction type summaries with total amounts.
        /// </returns>
        public async Task<IActionResult> Handle(GetTotalAmountPerTransactionTypeQuery request, CancellationToken cancellationToken)
        {
            string query = @"
WITH ""TransactionTypes"" AS (
    SELECT 1 AS ""Type"", 'Debit' AS ""Name""
    UNION ALL
    SELECT 2, 'Credit'
)
SELECT transactionTypes.""Type"", transactionTypes.""Name"", COALESCE(SUM(t.""Amount""), 0) AS ""TotalAmount""
FROM ""TransactionTypes"" transactionTypes
LEFT JOIN ""StmNato"".""Transaction"" transaction 
ON transaction.""TransactionType"" = transactionTypes.""Type""
GROUP BY transactionTypes.""Type"", transactionTypes.""Name"";
";

            IEnumerable<TransactionTypeAnalyticsModel> result = await this.dbConnection.QueryAsync<TransactionTypeAnalyticsModel>(query);

            return new OkObjectResult(result);
        }
    }
}
