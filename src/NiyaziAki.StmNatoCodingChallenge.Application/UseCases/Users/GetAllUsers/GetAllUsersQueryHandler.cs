// ************************************************************************
// <copyright file="GetAllUsersQueryHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.GetAllUsers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Common;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.Models;

    /// <summary>
    /// Handles the retrieval of all users with pagination support.
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUsersQueryHandler"/> class.
        /// </summary>
        /// <param name="dbConnection">The database connection used to interact with the database.</param>
        public GetAllUsersQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Handles the GetAllUsersQuery to fetch a paginated list of users from the database.
        /// </summary>
        /// <param name="request">The query containing pagination information (page number and page size).</param>
        /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
        /// <returns>Returns an IActionResult with the paginated result of users.</returns>
        public async Task<IActionResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            string countSql = "SELECT COUNT(*) FROM \"User\"";
            string querySql = @"
SELECT *
FROM ""User""
OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY
"
            ;

            int totalCount = await this.dbConnection.ExecuteScalarAsync<int>(countSql);

            IEnumerable<UserModel> items = await this.dbConnection.QueryAsync<UserModel>(querySql, new
            {
                Offset = (request.PageNumber - 1) * request.PageSize,
                request.PageSize,
            });

            PagedResult<UserModel> pagedResult = new PagedResult<UserModel>
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
