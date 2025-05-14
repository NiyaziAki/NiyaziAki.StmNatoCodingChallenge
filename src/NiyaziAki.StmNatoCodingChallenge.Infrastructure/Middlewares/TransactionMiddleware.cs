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
    using NiyaziAki.StmNatoCodingChallenge.Infrastructure.Middlewares.Attributes;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces;

    /// <summary>
    /// Middleware responsible for managing database transactions during HTTP requests.
    /// This middleware begins a transaction if the request requires it and commits or rolls it back depending on the outcome of the request.
    /// </summary>
    public class TransactionMiddleware : IMiddleware
    {
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionMiddleware"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to manage database transactions.</param>
        public TransactionMiddleware(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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

            await this.unitOfWork.BeginTransactionAsync();

            try
            {
                await next(context);
                await this.unitOfWork.SaveChangesAsync();
                await this.unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
