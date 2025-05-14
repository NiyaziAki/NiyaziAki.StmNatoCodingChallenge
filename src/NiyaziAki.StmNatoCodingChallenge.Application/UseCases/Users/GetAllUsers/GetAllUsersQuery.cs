// ************************************************************************
// <copyright file="GetAllUsersQuery.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.GetAllUsers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// A query that retrieves all users with pagination support.
    /// </summary>
    public class GetAllUsersQuery : IRequest<IActionResult>
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
    }
}
