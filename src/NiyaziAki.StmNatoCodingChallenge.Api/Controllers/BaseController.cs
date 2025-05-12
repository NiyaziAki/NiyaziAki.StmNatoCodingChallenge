// ************************************************************************
// <copyright file="BaseController.cs" company="Niyazi Aki">
// Copyright (c) STM &amp; NATO Coding Challenge - Niyazi Aki - All rights reserved.
// </copyright>
// ************************************************************************

namespace NiyaziAki.StmNatoCodingChallenge.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// A base controller class that provides common functionality for all API controllers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        private static readonly object LockObject = new object();
        private IMediator? mediator;

        /// <summary>
        /// Retrieves an instance of <see cref="IMediator"/> for handling commands and queries.
        /// </summary>
        /// <returns>Returns the mediator service.</returns>
        /// <exception cref="ArgumentNullException">Throws an exception if the IMediator service cannot be found.</exception>
        protected IMediator GetMediator()
        {
            if (this.mediator == null)
            {
                lock (LockObject)
                {
                    if (this.mediator == null)
                    {
                        this.mediator = this.HttpContext.RequestServices.GetService<IMediator>();
                    }
                }
            }

            if (this.mediator == null)
            {
                throw new ArgumentNullException(nameof(IMediator), "IMediator not found.");
            }

            return this.mediator;
        }
    }
}
