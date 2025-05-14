// ************************************************************************
// <copyright file="UseTransactionAttribute.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Infrastructure.Middlewares.Attributes
{
    using System;

    /// <summary>
    /// Custom attribute used to mark classes for transaction handling.
    /// This attribute indicates that the class requires transaction management during its operations.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class UseTransactionAttribute : Attribute
    {
    }
}
