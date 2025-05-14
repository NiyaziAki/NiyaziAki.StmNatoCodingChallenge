// ************************************************************************
// <copyright file="GetTotalAmountPerTransactionTypeQuery.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Analytics.GetTotalAmountPerTransactionType
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Represents a query to calculate the total transaction amount grouped by each transaction type (e.g., Debit, Credit).
    /// </summary>
    public class GetTotalAmountPerTransactionTypeQuery : IRequest<IActionResult>
    {
    }
}
