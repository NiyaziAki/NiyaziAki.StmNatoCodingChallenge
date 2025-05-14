// ************************************************************************
// <copyright file="User.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Domain.Entities
{
    using NiyaziAki.StmNatoCodingChallenge.Domain.Interfaces;

    /// <summary>
    /// Represents a basic user for the coding challenge.
    /// </summary>
    public class User : IEntityWithPrimaryKey<string>
    {
        /// <summary>
        /// Creates an instance of <see cref="User"/>.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="fullName">The name of the user.</param>
        public User(string id, string fullName)
        {
            this.Id = id;
            this.FullName = fullName;
        }

        /// <summary>
        /// The primary key of the user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The transactions of the user.
        /// </summary>
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}
