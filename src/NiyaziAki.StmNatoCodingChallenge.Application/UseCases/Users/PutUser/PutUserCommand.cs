// ************************************************************************
// <copyright file="PutUserCommand.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.PutUser
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Command class representing the request to update a user's details.
    /// </summary>
    public class PutUserCommand : IRequest<IActionResult>
    {
        /// <summary>
        /// The unique identifier of the user to be updated. Retrieved from the route.
        /// </summary>
        [FromRoute(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The full name of the user. This will be used to update the user's name.
        /// </summary>
        public string FullName { get; set; }
    }
}
