// ************************************************************************
// <copyright file="IUserService.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.Services
{
    using System.Threading.Tasks;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Defines methods for managing users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user with the specified full name.
        /// </summary>
        /// <param name="fullName">The full name of the user to create.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the newly created user.</returns>
        Task<string> CreateNewUser(string fullName);

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="user">The user to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        Task Delete(User user);

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous retrieval operation. The task result contains the user if found; otherwise, <c>null</c>.</returns>
        Task<User?> Get(string id);

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The user entity with updated information.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task Update(User user);
    }
}
