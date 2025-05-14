// ************************************************************************
// <copyright file="DeleteUserCommand.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.DeleteUser
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Command to delete a user by their ID. The ID is provided as part of the route parameters.
    /// </summary>
    public class DeleteUserCommand : IRequest<IActionResult>
    {
        /// <summary>
        /// The unique identifier of the user to be deleted. This ID is provided as part of the URL route.
        /// </summary>
        [FromRoute(Name = "id")]
        public string Id { get; set; }
    }
}
