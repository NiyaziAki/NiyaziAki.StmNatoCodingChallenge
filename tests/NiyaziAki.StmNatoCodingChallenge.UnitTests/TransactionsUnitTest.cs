// ************************************************************************
// <copyright file="TransactionsUnitTest.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.UnitTests
{
    using System;
    using System.Data;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NiyaziAki.StmNatoCodingChallenge.Application;
    using NiyaziAki.StmNatoCodingChallenge.Application.Services;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Common;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.GetAllTransactions;
    using NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Transactions.Models;
    using NiyaziAki.StmNatoCodingChallenge.Infrastructure.Services;
    using NiyaziAki.StmNatoCodingChallenge.Persistence;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.Interfaces;
    using Npgsql;

    /// <summary>
    /// Unit test class for transaction-related CQRS handlers using MediatR, AutoMapper, and dependency injection.
    /// </summary>
    [TestClass]
    public class TransactionsUnitTest
    {
        /// <summary>
        /// The service provider used to resolve dependencies via the built-in .NET dependency injection container during test execution.
        /// </summary>
        private IServiceProvider? serviceProvider;

        /// <summary>
        /// Initializes the test setup before each test method runs.
        /// Configures services including MediatR, AutoMapper, EF DbContext, and custom services with dependency injection.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();

            Type type = typeof(ApplicationAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(type.Assembly));
            services.AddAutoMapper(type.Assembly);

            DatabaseContextOptions databaseContextOptions = new DatabaseContextOptions
            {
                Server = "localhost",
                Port = 5432,
                Database = "StmNatoCodingChallenge",
                User = "sa",
                Password = "N@t0(1949)",
            };
            services.AddSingleton<DatabaseContextOptions>(databaseContextOptions);
            services.AddScoped<StmNatoCodingChallengeContext>();
            services.AddTransient<IDbConnection>(servicePovider => new NpgsqlConnection($"Host={databaseContextOptions.Server};Port={databaseContextOptions.Port};Username={databaseContextOptions.User};Password={databaseContextOptions.Password};Database={databaseContextOptions.Database}"));
            services.AddScoped<ITransactionService, TransactionService>()
                    .AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            this.serviceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        /// Tests the creation of a transaction using a CQRS command handler and verifies the returned result.
        /// Ensures that the returned IActionResult is a CreatedResult with a valid integer ID.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task GetAllTransactions_ShouldReturn_PagedListOfTransactions()
        {
            if (this.serviceProvider == null)
            {
                Assert.Fail("Service porvider not initialized.");
            }

            IMediator mediator = this.serviceProvider.GetRequiredService<IMediator>();
            GetAllTransactionsQuery getAllTransactionsQuery = new GetAllTransactionsQuery
            {
                PageNumber = 1,
                PageSize = 10,
            };

            IActionResult result = await mediator.Send(getAllTransactionsQuery);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            OkObjectResult? okObjectResult = result as OkObjectResult;

            Assert.IsNotNull(okObjectResult);
            Assert.AreEqual(200, okObjectResult.StatusCode ?? 0);

            Assert.IsNotNull(okObjectResult.Value);

            if (okObjectResult.Value is PagedResult<TransactionModel>)
            {
                return;
            }

            Assert.Fail("Result value is not a paged result of items TransactionModel.");
        }
    }
}
