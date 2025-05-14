// ************************************************************************
// <copyright file="UserService.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Infrastructure.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces;

    /// <summary>
    /// Service for managing user operations such as creating, deleting, retrieving, and updating users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User, string> userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to manage database transactions.</param>
        public UserService(IUnitOfWork unitOfWork)
        {
            this.userRepository = unitOfWork.GetRepository<User, string>();
        }

        /// <summary>
        /// Creates a new user and saves it to the database.
        /// </summary>
        /// <param name="fullName">The full name of the user.</param>
        /// <returns>The ID of the newly created user.</returns>
        public async Task<string> CreateNewUser(string fullName)
        {
            User user = new User(Guid.NewGuid().ToString(), fullName);
            return await this.userRepository.AddAsync(user);
        }

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        /// <param name="user">The user to be deleted.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(User user)
        {
            await this.userRepository.DeleteAsync(user);
        }

        /// <summary>
        /// Retrieves a user by their ID from the database.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        public async Task<User?> Get(string id)
        {
            return await this.userRepository.GetByIdAsync(id, users => users.Include(user => user.Transactions));
        }

        /// <summary>
        /// Updates an existing user in the database.
        /// </summary>
        /// <param name="user">The user to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Update(User user)
        {
            await this.userRepository.UpdateAsync(user);
        }
    }
}
