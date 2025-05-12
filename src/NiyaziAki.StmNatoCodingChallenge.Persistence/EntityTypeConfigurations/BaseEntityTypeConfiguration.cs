// ************************************************************************
// <copyright file="BaseEntityTypeConfiguration.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence.EntityTypeConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NiyaziAki.StmNatoCodingChallenge.Domain.Entities;

    /// <summary>
    /// Base configuration for entities.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TPrivateKey">The type of primary key.</typeparam>
    public abstract class BaseEntityTypeConfiguration<TEntity, TPrivateKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity<TPrivateKey>
        where TPrivateKey : struct
    {
        /// <summary>
        /// Configures the entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the entity type.</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Id)
                   .HasColumnOrder(0)
                   .ValueGeneratedOnAdd()
                   .IsRequired();
        }
    }
}
