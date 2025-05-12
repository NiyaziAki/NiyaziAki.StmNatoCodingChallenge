// ************************************************************************
// <copyright file="StmNatoCodingChallengeContext.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;
    using NiyaziAki.StmNatoCodingChallenge.Persistence.EntityTypeConfigurations;

    /// <summary>
    /// The EF Core DbContext for the STM NATO Coding Challenge application.
    /// </summary>
    public class StmNatoCodingChallengeContext : DbContext
    {
        /// <summary>
        /// Schema name used to store the EF Core migrations history table.
        /// </summary>
        protected const string MigrationTableSchema = "Migration";

        /// <summary>
        /// Name of the EF Core migrations history table.
        /// </summary>
        protected const string MigrationTableName = "MigrationsHistory";

        /// <summary>
        /// Initializes a new instance of the <see cref="StmNatoCodingChallengeContext"/>.
        /// </summary>
        /// <param name="databaseContextOptions">Database connection options.</param>
        public StmNatoCodingChallengeContext(DatabaseContextOptions databaseContextOptions)
        {
            this.ConnectionString = $"Host={databaseContextOptions.Server};Port={databaseContextOptions.Port};Database={databaseContextOptions.Database};Username={databaseContextOptions.User};Password={databaseContextOptions.Password};";
        }

        /// <summary>
        /// Represents the Transactions table in the database.
        /// </summary>
        public DbSet<Transaction>? Transactions { get; set; }

        /// <summary>
        /// The connection string.
        /// </summary>
        protected string ConnectionString { get; private set; }

        /// <summary>
        /// Configures the EF Core model and applies any entity configurations.
        /// </summary>
        /// <param name="builder">The model builder to configure entities and relationships.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TransactionEntityTypeConfiguration());
        }

        /// <summary>
        /// Configures the database connection for EF Core.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(this.ConnectionString, options =>
            {
                options.MigrationsHistoryTable(MigrationTableName, MigrationTableSchema);
            });
        }
    }
}
