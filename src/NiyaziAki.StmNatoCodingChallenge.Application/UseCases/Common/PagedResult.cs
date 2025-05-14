// ************************************************************************
// <copyright file="PagedResult.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Application.UseCases.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a paginated result containing a collection of items and pagination metadata.
    /// </summary>
    /// <typeparam name="TResult">The type of items in the paginated result.</typeparam>
    public class PagedResult<TResult>
    {
        /// <summary>
        /// The current page number in the paginated result.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The number of rows per page in the paginated result.
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// The total number of rows in the full dataset.
        /// </summary>
        public int TotalRowCount { get; set; }

        /// <summary>
        /// The total number of pages based on the total row count and rows per page.
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((double)this.TotalRowCount / this.RowCount);

        /// <summary>
        /// The collection of items for the current page.
        /// </summary>
        public ICollection<TResult> Items { get; set; } = new List<TResult>();

        /// <summary>
        /// Indicates whether there is a previous page in the result.
        /// </summary>
        public bool HasPreviousPage => this.PageNumber > 1;

        /// <summary>
        /// Indicates whether there is a next page in the result.
        /// </summary>
        public bool HasNextPage => this.PageNumber < this.TotalPages;

        /// <summary>
        /// The index of the first item on the current page (1-based index).
        /// </summary>
        public int First => this.TotalRowCount == 0 ? 0 : ((this.PageNumber - 1) * this.RowCount) + 1;
    }
}
