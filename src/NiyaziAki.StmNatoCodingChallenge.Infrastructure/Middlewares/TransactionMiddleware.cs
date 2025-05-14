// ************************************************************************
// <copyright file="TransactionMiddleware.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Infrastructure.Middlewares
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore.Storage;
    using NiyaziAki.StmNatoCodingChallenge.Infrastructure.Middlewares.Attributes;
    using NiyaziAki.StmNatoCodingChallenge.Persistence;

    /// <summary>
    /// Middleware responsible for managing database transactions during HTTP requests.
    /// This middleware begins a transaction if the request requires it and commits or rolls it back depending on the outcome of the request.
    /// </summary>
    public class TransactionMiddleware : IMiddleware
    {
        private readonly StmNatoCodingChallengeContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionMiddleware"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context used to manage transactions.</param>
        public TransactionMiddleware(StmNatoCodingChallengeContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Invokes the middleware to handle the HTTP request.
        /// Begins a transaction if required, and ensures proper commit or rollback based on request outcome.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="next">The next middleware in the pipeline to invoke.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Endpoint? endpoint = context.GetEndpoint();
            bool useTransaction = endpoint?.Metadata?.GetMetadata<UseTransactionAttribute>() != null;

            if ((HttpMethods.IsGet(context.Request.Method) ||
                HttpMethods.IsOptions(context.Request.Method)) &&
                !useTransaction)
            {
                await next(context);
                return;
            }

            await using IDbContextTransaction transaction = await this.databaseContext.Database.BeginTransactionAsync();

            try
            {
                await next(context);
                await this.databaseContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
