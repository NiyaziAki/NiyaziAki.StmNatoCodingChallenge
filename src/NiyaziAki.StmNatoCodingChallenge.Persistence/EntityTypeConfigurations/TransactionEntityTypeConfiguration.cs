// ************************************************************************
// <copyright file="TransactionEntityTypeConfiguration.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Configurations for the <see cref="Transaction"/> entity.
    /// </summary>
    public class TransactionEntityTypeConfiguration : BaseEntityTypeConfiguration<Transaction, int>
    {
        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.Property(transaction => transaction.UserId)
                   .HasColumnOrder(1)
                   .IsRequired();

            builder.Property(transaction => transaction.Amount)
                   .HasColumnOrder(2)
                   .IsRequired();

            builder.Property(transaction => transaction.TransactionType)
                  .HasColumnOrder(3)
                  .IsRequired();

            builder.Property(transaction => transaction.CreatedAt)
                 .HasColumnOrder(4)
                 .IsRequired();

            builder.ToTable(
                nameof(Transaction),
                "StmNato",
                tableBuilder => tableBuilder.HasCheckConstraint("CK_Transaction_Amount_NonNegative", "\"Amount\" >= 0"));
        }
    }
}
