// ************************************************************************
// <copyright file="TotalAmountPerUserAnalyticsModel.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.Models
{
    /// <summary>
    /// Represents the analytics data for the total amount per user.
    /// </summary>
    public class TotalAmountPerUserAnalyticsModel
    {
        /// <summary>
        /// Represents the unique identifier of the user.
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// Full name of the user.
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Holds the total amount associated with the user.
        /// </summary>
        public decimal TotalAmount { get; set; }
    }
}
