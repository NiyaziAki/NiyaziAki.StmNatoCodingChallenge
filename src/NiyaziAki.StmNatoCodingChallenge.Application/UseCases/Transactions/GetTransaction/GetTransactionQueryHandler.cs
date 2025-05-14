// ************************************************************************
// <copyright file="GetTransactionQueryHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.GetTransaction
{
    using System.Data;
    using System.Threading.Tasks;
    using AutoMapper;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Handles the GetTransactionQuery to retrieve a transaction by its Id.
    /// </summary>
    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the GetTransactionQueryHandler.
        /// </summary>
        /// <param name="dbConnection">The database connection to execute queries against the database.</param>
        /// <param name="mapper">The mapper used to map the database entity to the model.</param>
        public GetTransactionQueryHandler(IDbConnection dbConnection, IMapper mapper)
        {
            this.dbConnection = dbConnection;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the GetTransactionQuery by retrieving a transaction based on the provided Id.
        /// </summary>
        /// <param name="request">The query containing the transaction Id to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An IActionResult containing the transaction model if found, or a NotFoundResult if the transaction doesn't exist.</returns>
        public async Task<IActionResult> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            string getSQL = "SELECT * FROM \"StmNato\".\"Transaction\" WHERE \"Id\" = @Id LIMIT 1";
            Transaction? transaction = await this.dbConnection.QueryFirstOrDefaultAsync<Transaction>(getSQL, new { Id = request.Id });

            if (transaction == null)
            {
                return new NotFoundResult();
            }

            TransactionModel model = this.mapper.Map<TransactionModel>(transaction);
            ////TransactionModel model = TransactionModel.Map<TransactionModel>(transaction); same as automapper

            return new OkObjectResult(model);
        }
    }
}
