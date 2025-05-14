// ************************************************************************
// <copyright file="GetUserQueryHandler.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.GetUser
{
    using System.Data;
    using System.Threading.Tasks;
    using AutoMapper;
    using Dapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.Models;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Handles the retrieval of a user based on the provided query.
    /// </summary>
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IActionResult>
    {
        private readonly IDbConnection dbConnection;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserQueryHandler"/> class.
        /// </summary>
        /// <param name="dbConnection">The database connection used to query user data.</param>
        /// <param name="mapper">The object mapper used to map entities to models.</param>
        public GetUserQueryHandler(IDbConnection dbConnection, IMapper mapper)
        {
            this.dbConnection = dbConnection;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the user query and returns the user data if found.
        /// </summary>
        /// <param name="request">The query request containing the user identifier.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>An <see cref="IActionResult"/> containing the user data or a not found result.</returns>
        public async Task<IActionResult> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            string getSQL = "SELECT * FROM \"User\" WHERE \"Id\" = @Id LIMIT 1";
            User? user = await this.dbConnection.QueryFirstOrDefaultAsync<User>(getSQL, new { Id = request.Id });

            if (user == null)
            {
                return new NotFoundResult();
            }

            UserModel model = this.mapper.Map<UserModel>(user);
            ////UserModel model = UserModel.Map<UserModel>(user); same as automapper

            return new OkObjectResult(model);
        }
    }
}
