// ************************************************************************
// <copyright file="Program.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api
{
    /// <summary>
    /// The entry point class for the app.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point of the app.
        /// </summary>
        /// <param name="args">Additional arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
                                               .ConfigureWebHostDefaults(webBuilder =>
                                               {
                                                   webBuilder.UseKestrel()
                                                             .UseContentRoot(Directory.GetCurrentDirectory())
                                                             .UseUrls("http://+:1991"); //// STM was founded in 1991

                                                   webBuilder.UseStartup<Startup>();
                                               });

                hostBuilder.Build().Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
