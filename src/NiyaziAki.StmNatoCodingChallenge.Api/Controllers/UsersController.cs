// ************************************************************************
// <copyright file="UsersController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for handling user related operations.
    /// </summary>
    public class UsersController : BaseController
    {
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>All users.</returns>
        [HttpGet]
        [Route("", Name = "GetAllUsers")]
        public async Task<IActionResult> Get()
        {
            return this.Ok();
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <returns>Returns the id of the newly created user with status 201.</returns>
        [HttpPost]
        [Route("", Name = "CreateNewUser")]
        public async Task<IActionResult> Post()
        {
            return this.Created();
        }

        /// <summary>
        /// Gets the user matching the given id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The transaction or 404 if not found.</returns>
        [HttpGet]
        [Route("{id}", Name = "GetUser")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return this.Ok();
        }

        /// <summary>
        /// Updates the user matching the given id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpPut]
        [Route("{id}", Name = "UpdateUser")]
        public async Task<IActionResult> Put([FromRoute] int id)
        {
            return this.Ok();
        }

        /// <summary>
        /// Deletes the users matching the given id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>200 or 404 if not found.</returns>
        [HttpDelete]
        [Route("{id}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return this.Ok();
        }
    }
}
