// ************************************************************************
// <copyright file="Startup.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api
{
    using NiyaziAki.StmNatoCodingChallenge.Infrastructure;

    /// <summary>
    /// Configures the application's services and HTTP request pipeline.
    /// </summary>
    public class Startup
    {
        private const string EnvironmentVariable = "ASPNETCORE_ENVIRONMENT";
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// Builds the application configuration by loading the base <c>appsettings.json</c>
        /// and an environment-specific settings file (e.g., <c>appsettings.Development.json</c>).
        /// </summary>
        public Startup()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory))
                                                                      .AddJsonFile("appsettings.json", optional: true);

            string? environment = Environment.GetEnvironmentVariable(EnvironmentVariable);
            string path = Path.Combine(AppContext.BaseDirectory, $"appsettings.{environment}.json");
            builder.AddJsonFile(path, optional: false);

            this.configuration = builder.Build();
        }

        /// <summary>
        /// Configures services and registers them to the dependency injection container.
        /// This method is called by the runtime before the application starts.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(this.configuration);
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// This method is called by the runtime after ConfigureServices.
        /// </summary>
        /// <param name="applicationBuilder">An IApplicationBuilder for configuring the middleware pipeline.</param>
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseInfrastructure(this.configuration);
        }
    }
}
