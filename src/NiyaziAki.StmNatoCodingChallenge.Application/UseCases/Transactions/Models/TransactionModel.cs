// ************************************************************************
// <copyright file="TransactionModel.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models
{
    using System;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Enums;

    /// <summary>
    /// Represents the model for a transaction, used to transfer transaction data.
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// The unique identifier of the transaction.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The private key of the user associated with the transaction.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        public TransactionType TransactionType { get; set; }

        /// <summary>
        /// The date and time of the transaction.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Manually maps a <see cref="Transaction"/> entity to a model of type <typeparamref name="T"/>.
        /// This method is a lightweight alternative to using AutoMapper, useful when avoiding external dependencies
        /// or when explicit control over mapping logic is desired.
        /// </summary>
        /// <typeparam name="T">A model type that inherits from <see cref="TransactionModel"/> and has a parameterless constructor.</typeparam>
        /// <param name="transaction">The source <see cref="Transaction"/> entity to map from.</param>
        /// <returns>An instance of <typeparamref name="T"/> populated with values from the given transaction.</returns>
        public static T Map<T>(Transaction transaction)
            where T : TransactionModel, new()
        {
            T model = new T
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                CreatedAt = transaction.CreatedAt,
                TransactionType = transaction.TransactionType,
                UserId = transaction.UserId,
            };

            return model;
        }
    }
}
