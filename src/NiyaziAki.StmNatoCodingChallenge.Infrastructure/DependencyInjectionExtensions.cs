// ************************************************************************
// <copyright file="DependencyInjectionExtensions.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Infrastructure
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using NiyaziAki.StmNatoCodingChallenge.Persistence;

    /// <summary>
    /// Contains extension methods for configuring the infrastructure layer of the application.
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Registers the infrastructure services.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the infrastructure services are added.</param>
        /// <param name="configuration">The configuration object used to retrieve application settings.</param>
        /// <returns>The updated IServiceCollection with infrastructure services registered.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            DatabaseContextOptions databaseContextOptions = new DatabaseContextOptions();
            IConfigurationSection section = configuration.GetSection(nameof(DatabaseContextOptions));
            section.Bind(databaseContextOptions);

            services.AddSingleton<DatabaseContextOptions>(databaseContextOptions);

            services.AddScoped<StmNatoCodingChallengeContext>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "STM NATO Coding Challenge API",
                    Version = "v1",
                    Description = "API documentation for STM NATO Coding Challenge",
                    Contact = new OpenApiContact
                    {
                        Name = "Niyazi Akı",
                        Email = "niyazi.aki@runicbytes.com",
                    },
                });

                string xmlFile = $"NiyaziAki.StmNatoCodingChallenge.Api.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        /// <summary>
        /// Configures middleware for the infrastructure layer.
        /// </summary>
        /// <param name="applicationBuilder">The IApplicationBuilder used to configure middleware.</param>
        /// <param name="configuration">The configuration object used for application settings.</param>
        /// <returns>The updated IApplicationBuilder with infrastructure middleware configured.</returns>
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "STM NATO API v1");
                options.RoutePrefix = string.Empty;
            });

            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return applicationBuilder;
        }
    }
}
