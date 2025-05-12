// ************************************************************************
// <copyright file="DatabaseContextOptions.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Persistence
{
    /// <summary>
    /// Represents the configuration options required to connect to a database.
    /// </summary>
    public class DatabaseContextOptions
    {
        /// <summary>
        /// Host or IP address of the server.
        /// </summary>
        public string? Server { get; set; }

        /// <summary>
        /// Port of the database.
        /// </summary>
        public ushort? Port { get; set; }

        /// <summary>
        /// Name of the database.
        /// </summary>
        public string? Database { get; set; }

        /// <summary>
        /// Username required for the connection.
        /// </summary>
        public string? User { get; set; }

        /// <summary>
        /// Password required for the connection.
        /// </summary>
        public string? Password { get; set; }
    }
}
