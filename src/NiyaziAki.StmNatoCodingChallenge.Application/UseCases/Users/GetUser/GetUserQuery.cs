// ************************************************************************
// <copyright file="GetUserQuery.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.GetUser
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a query to retrieve a user by their unique identifier.
    /// </summary>
    public class GetUserQuery : IRequest<IActionResult>
    {
        /// <summary>
        /// The unique identifier of the user to retrieve.
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
}
