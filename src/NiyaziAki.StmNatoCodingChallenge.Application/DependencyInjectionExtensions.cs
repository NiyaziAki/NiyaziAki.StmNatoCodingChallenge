// ************************************************************************
// <copyright file="DependencyInjectionExtensions.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Contains extension methods for configuring the application layer of the solution.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Registers the application services.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the application services are added.</param>
        /// <returns>The updated IServiceCollection with application services registered.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            Type type = typeof(ApplicationAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(type.Assembly));

            return services;
        }
    }
}
