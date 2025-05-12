// ************************************************************************
// <copyright file="StmNatoCodingChallengeDesignTimeDbContextFactory.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence
{
    using Microsoft.EntityFrameworkCore.Design;

    /// <summary>
    /// The design-time factory used by Entity Framework Core tools for migrations.
    /// </summary>
    public sealed class StmNatoCodingChallengeDesignTimeDbContextFactory : IDesignTimeDbContextFactory<StmNatoCodingChallengeContext>
    {
        /// <summary>
        /// Creates a new instance of <see cref="StmNatoCodingChallengeContext"/>.
        /// </summary>
        /// <param name="args">Arguments passed by the EF tools.</param>
        /// <returns>An instance of <see cref="StmNatoCodingChallengeContext"/>.</returns>
        public StmNatoCodingChallengeContext CreateDbContext(string[] args)
        {
            DatabaseContextOptions databaseContextOptions = new DatabaseContextOptions
            {
                Server = "localhost",
                Port = 5432,
                Database = "StmNatoCodingChallenge",
                User = "sa",
                Password = "N@t0(1949)",
            };

            return new StmNatoCodingChallengeContext(databaseContextOptions);
        }
    }
}
