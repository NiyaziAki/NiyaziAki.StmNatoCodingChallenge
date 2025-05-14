// ************************************************************************
// <copyright file="PostUserCommand.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.PostUser
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents the command to create a new user.
    /// </summary>
    public class PostUserCommand : IRequest<IActionResult>
    {
        /// <summary>
        /// The full name of the user to be created.
        /// </summary>
        public string FullName { get; set; }
    }
}
