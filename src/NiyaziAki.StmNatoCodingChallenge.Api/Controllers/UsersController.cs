// ************************************************************************
// <copyright file="UsersController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.DeleteUser;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.GetAllUsers;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.GetUser;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.PostUser;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.PutUser;

    /// <summary>
    /// Controller for handling user related operations.
    /// </summary>
    public class UsersController : BaseController
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <param name="getAllUsersQuery">Pagination request.</param>
        /// <returns>All users.</returns>
        [HttpGet]
        [Route("", Name = "GetAllUsers")]
        public async Task<IActionResult> Get([FromQuery] GetAllUsersQuery getAllUsersQuery)
        {
            return await this.GetMediator().Send(getAllUsersQuery);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="postUserCommand">Payload.</param>
        /// <returns>Returns the id of the newly created user with status 201.</returns>
        [HttpPost]
        [Route("", Name = "CreateNewUser")]
        public async Task<IActionResult> Post([FromBody] PostUserCommand postUserCommand)
        {
            return await this.GetMediator().Send(postUserCommand);
        }

        /// <summary>
        /// Gets the user matching the given id.
        /// </summary>
        /// <param name="getUserQuery">The id of the user.</param>
        /// <returns>The transaction or 404 if not found.</returns>
        [HttpGet]
        [Route("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get([FromRoute] GetUserQuery getUserQuery)
        {
            return await this.GetMediator().Send(getUserQuery);
        }

        /// <summary>
        /// Updates the user matching the given id.
        /// </summary>
        /// <param name="putUserCommand">Payload.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpPut]
        [Route("{id}", Name = "UpdateUser")]
        public async Task<IActionResult> Put([FromBody] PutUserCommand putUserCommand)
        {
            return await this.GetMediator().Send(putUserCommand);
        }

        /// <summary>
        /// Deletes the users matching the given id.
        /// </summary>
        /// <param name="deleteUserCommand">The id of the user.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpDelete]
        [Route("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand deleteUserCommand)
        {
            return await this.GetMediator().Send(deleteUserCommand);
        }
    }
}
