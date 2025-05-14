// ************************************************************************
// <copyright file="UserModel.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Users.Models
{
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Represents the data transfer object (DTO) for a user.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// The primary key of the user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The full name of the user.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Maps a <see cref="User"/> entity to a model of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">A model type that inherits from <see cref="UserModel"/> and has a parameterless constructor.</typeparam>
        /// <param name="user">The source <see cref="User"/> entity to map from.</param>
        /// <returns>An instance of <typeparamref name="T"/> populated with values from the given user.</returns>
        public static T Map<T>(User user)
            where T : UserModel, new()
        {
            T model = new T
            {
                Id = user.Id,
                FullName = user.FullName,
            };

            return model;
        }
    }
}
